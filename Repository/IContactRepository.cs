using AgendaDeContatos.Integration.Response;
using AgendaDeContatos.Models;

namespace AgendaDeContatos.Repository
{
    public interface IContactRepository
    {
        ContactModel GetById(int id);
        List<ContactModel> GetAll();
        ContactModel Register(ContactModel contact);
        ContactModel Alter(ContactModel contact);
        bool Delete(int id);
        ContactModel GetViaCepAPIData(ContactModel contact);

    }
}
