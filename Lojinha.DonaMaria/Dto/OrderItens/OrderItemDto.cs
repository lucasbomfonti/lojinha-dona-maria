using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lojinha.DonaMaria.Dto.Product;

namespace Lojinha.DonaMaria.Dto.OrderItens
{
    public class OrderItemDto
    {
        public int Amount { get; set; }
        public double price_unit { get; set; }
        public double Total { get; set; }
        public Guid ProductId { get; set; }
    }
}
