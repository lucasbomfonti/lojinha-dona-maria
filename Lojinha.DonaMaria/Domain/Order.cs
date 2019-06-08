using System;
using System.ComponentModel.DataAnnotations;

namespace Lojinha.DonaMaria.Domain
{
    public class Order : BaseEntity
    {
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
