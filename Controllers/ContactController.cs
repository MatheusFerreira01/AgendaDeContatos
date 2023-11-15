using AgendaDeContatos.Models;
using AgendaDeContatos.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AgendaDeContatos.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRep;

        public ContactController(IContactRepository contactRep)
        {
            _contactRep = contactRep;
        }

        #region Metodos vinculados a View
        public IActionResult Alter(int id)
        {
            ContactModel contact = _contactRep.GetById(id);
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            ContactModel existentContact = _contactRep.GetById(id);
            return View(existentContact);
        }

        public IActionResult Index()
        {
            List<ContactModel> contactList = _contactRep.GetAll().Where(x => x.IsActive).ToList();
            return View(contactList);
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult RegisterWithContent(ContactModel contact)
        {
            return View("Register", contact);
        }

        #endregion

        #region Metodos Action
        public IActionResult CepConsultAction(ContactModel contact)
        {
            ContactModel test = new ContactModel();

            test.Address = "Rua Exemplo, 123";
            test.Name = "Zeeeeeeee";

            //ContactModel contactWAddress = _contactRep.GetViaCepAPIData(contact);
            return View("RegisterWithContent", test);
        }

        [HttpPost]
        public IActionResult RegisterAction(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRep.Register(contact);
                    TempData["SucessMessage"] = "Novo contato inserido com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Register", contact);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Problema ao CADASTRAR o contato: {ex.Message}";
                return RedirectToAction("Index");

            }

        }

        [HttpPost]
        public IActionResult AlterAction(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRep.Alter(contact);
                    TempData["SucessMessage"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Problema ao ATUALIZAR os dados: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult DeleteAction(int id)
        {
            try
            {
                bool isDeleted = _contactRep.Delete(id);

                if (isDeleted)
                    TempData["SucessMessage"] = "Contato apagado com sucesso!";
                else
                    TempData["ErrorMessage"] = "Não foi possivel apagar o contato!";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Problema ao APAGAR os dados: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}
