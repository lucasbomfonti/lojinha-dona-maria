using System;
using System.ComponentModel.DataAnnotations;

namespace Lojinha.DonaMaria.Domain
{
    public class Product : BaseEntity
    {
        [Required]
        public Guid Sku { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime Updated_at { get; set; }
    }
}
