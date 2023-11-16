using System.ComponentModel.DataAnnotations;

namespace AgendaDeContatos.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage ="E-mail é invalido, por favor revise os dados")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "*")]
        [Phone(ErrorMessage ="Celular informado invalido, por favor revise os dados")]
        public string Phone { get; set; } = string.Empty;
        [RegularExpression(@"^(?:[0-9]{8}|[0-9]{5}-[0-9]{3})$", ErrorMessage = "CEP informado inválido, por favor revise os dados")]
        public string CEP { get; set; } = string.Empty;
        [Required(ErrorMessage = "*")]
        public string Address { get; set; } = string.Empty;
        public string? Number { get; set; }
        public string? Complement {  get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public bool IsActive { get; set; } = true;

       
    }

}
