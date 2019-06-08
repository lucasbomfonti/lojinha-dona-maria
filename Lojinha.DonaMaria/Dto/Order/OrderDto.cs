using System;
using System.Collections.Generic;

namespace Lojinha.DonaMaria.Dto.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime cancelDate { get; set; }
        public string Status { get; set; }
        public double Total { get; set; }
        public Domain.Customer Buyer { get; set; }
        public List<Domain.Product> Itens { get; set; }
    }
}
