using System.ComponentModel.DataAnnotations;

namespace Lojinha.DonaMaria.Dto.Customer
{
    public class CustomerInsertDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
    }
}
