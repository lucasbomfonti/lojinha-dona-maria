using System;
using Lojinha.DonaMaria.Dto.Customer;
using Lojinha.DonaMaria.Dto.OrderItens;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lojinha.DonaMaria.Dto.Order
{
    public class OrderInsertDto
    {
        [Required]
        public string Status { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public Guid BuyerId { get; set; }
        [Required]
        public List<OrderItemDto> Itens { get; set; }
    }
}
