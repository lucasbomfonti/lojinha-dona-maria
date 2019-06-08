using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Helper;
using Tmss_Back_end.Data.Repository.Context;

namespace Lojinha.DonaMaria
{
    public static class OrderSeed
    {
        public static void Run(DataContext context)
        {
            if (context.Set<Order>().Any())
                return;
            var product = context.Set<Product>().Add(new Product()
            {
                Id = Guid.NewGuid(),
                Created_at = DateTime.Now,
                Name = "ProductName",
                Sku = Guid.NewGuid(),
                Updated_at = DateTime.Now,
                Price = 1000
            });

            var customer = context.Set<Customer>().Add(new Customer()
            {
                Id = Guid.NewGuid(),
                Created_at = DateTime.Now,
                Name = "CustomerName",
                Cpf = CpfHelper.GenerateCpf(),
                Email = "EmailName@name.com.br",
                Updated_At = DateTime.Now
            });

            var order = context.Set<Order>().Add(new Order()
            {
                Id = Guid.NewGuid(),
                Created_at = DateTime.Now,
                Total = 1000,
                Status = "CONCLUDED",
                CustomerId = customer.Entity.Id
            });

            var orderItens = context.Set<OrderItens>().Add(new OrderItens()
            {
                Id = Guid.NewGuid(),
                OrderId = order.Entity.Id,
                Total = 1000,
                ProductId = product.Entity.Id,
                Amount = 1,
                price_unit = 1000
            });
            
            context.SaveChanges();
        }
    }
}
