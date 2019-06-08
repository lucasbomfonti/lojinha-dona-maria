using System;
using System.ComponentModel.DataAnnotations;

namespace Lojinha.DonaMaria.Domain
{
    public class OrderItens
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public double price_unit { get; set; }
        [Required]
        public double Total { get; set; }
    }
}
