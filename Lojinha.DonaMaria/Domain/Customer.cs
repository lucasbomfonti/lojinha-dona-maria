using System;
using System.ComponentModel.DataAnnotations;

namespace Lojinha.DonaMaria.Domain
{
    public class Customer : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime Updated_At { get; set; }
    }
}
