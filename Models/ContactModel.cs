using System.ComponentModel.DataAnnotations;

namespace AgendaDeContatos.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome do contato é obrigatório")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "E-mail do contato é obrigatório")]
        [EmailAddress(ErrorMessage ="E-mail é invalido, por favor revise os dados")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Celular do contato é obrigatório")]
        [Phone(ErrorMessage ="Ceular informado invalido, por favor revise os dados")]
        public string? Phone { get; set; }
        public string? CEP { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;
    }

}
