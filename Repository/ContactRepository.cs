using AgendaDeContatos.DataBase;
using AgendaDeContatos.Integration.Common;
using AgendaDeContatos.Integration.Response;
using AgendaDeContatos.Models;
using Newtonsoft.Json;
using RestSharp;

namespace AgendaDeContatos.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataBaseContext _dbContext;
        public ContactRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ContactModel GetById(int id)
        {
            return _dbContext.TblContacts.FirstOrDefault(x => x.Id == id);
        }
        public List<ContactModel> GetAll()
        {
            return _dbContext.TblContacts.ToList();
        }

        public ContactModel Register(ContactModel contact)
        {
            _dbContext.TblContacts.Add(contact);
            _dbContext.SaveChanges();
            return contact;
        }

        public ContactModel Alter(ContactModel contact)
        {
            ContactModel existentContact = GetById(contact.Id);

            if (existentContact is null) throw new Exception("Ocorreu um problema ao atualizar dados do contato");
          
            existentContact.Name = contact.Name;
            existentContact.Email = contact.Email;
            existentContact.Phone = contact.Phone;      
            existentContact.CEP = contact.CEP;
            existentContact.Address = contact.Address;

            _dbContext.TblContacts.Update(existentContact);
            _dbContext.SaveChanges();
            return existentContact;
        }

        public bool Delete(int id)
        {
            ContactModel existentContact = GetById(id);

            if (existentContact is null) throw new Exception("Ocorreu um problema ao apagar o contato");

            existentContact.IsActive = false;

            _dbContext.TblContacts.Update(existentContact);
            _dbContext.SaveChanges();
            return true;
        }

        public ContactModel GetViaCepAPIData(ContactModel contact)
        {
            contact.Address = "Teste";
            contact.Name = "Teste2";
            return contact;
            string routeBuilt = CommonApi.ViaCepUri.Replace("{cep}", contact.CEP);

            var client = new RestClient(CommonApi.ViaCepUri + routeBuilt);

            var request = new RestRequest(Method.GET);
            try
            {
                IRestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    if (response.Content != null)
                    {
                        ViaCepResponse? result = JsonConvert.DeserializeObject<ViaCepResponse>(response.Content);

                        contact.Address = result.Bairro;
                        contact.Name = result.Uf;

                        return contact;
                    }
                }
                else
                {
                    Console.WriteLine($"Erro na solicitação. Código de status: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }

            return null;
        }
    }
}
