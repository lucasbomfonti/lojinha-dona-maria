using Lojinha.DonaMaria.Data.Repository.Interface;
using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using Tmss_Back_end.Data.Repository.Base;
using Tmss_Back_end.Data.Repository.Context;
using Product = Lojinha.DonaMaria.Domain.Product;

namespace Lojinha.DonaMaria.Data.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {

        public OrderRepository(DataContext context) : base(context)
        {
        }

        public List<OrderDto> GetOrder()
        {
            var temp = new List<OrderDto>();

            var query =
                from order in _context.Set<Order>().AsQueryable()
                join customer in _context.Set<Customer>().AsQueryable() on order.CustomerId equals customer.Id
                select new OrderDto
                {
                    Id = order.Id,
                    Total = order.Total,
                    Created_at = order.Created_at,
                    Status = order.Status,
                    Buyer = customer,
                    Itens = new List<Product>()
                };
            temp = query.GroupBy(g => g.Id).Select(s => s.FirstOrDefault()).ToList();
            return ExtractItemFromContext(temp);
        }

        public List<Product> GetAll(Guid orders)
        {
            var productList = new List<Product>();

            var query =
                from orderItem in _context.Set<OrderItens>().AsQueryable()
                join product in _context.Set<Product>().AsQueryable() on orderItem.ProductId equals product.Id
                where orderItem.OrderId == orders
                select new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Sku = product.Sku,
                    Created_at = product.Created_at,
                    Updated_at = product.Updated_at,
                    Price = product.Price
                };
            productList.AddRange(query.ToList());

            return ExtractItemFromContext(productList);
        }


        public Guid AddOrder(OrderInsertDto dto)
        {
            using (_context)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var temp = new Order()
                        {
                            Id = new Guid(),
                            Created_at = DateTime.Now,
                            CustomerId = dto.BuyerId,
                            Status = dto.Status,
                            Total = dto.Total
                        };
                        var order = _context.Set<Order>().Add(temp);
                        var listItens = new List<OrderItens>();
                        dto.Itens.ForEach(f =>
                        {
                            listItens.Add(new OrderItens()
                            {
                                Total = f.Total,
                                Id = new Guid(),
                                Amount = f.Amount,
                                OrderId = temp.Id,
                                ProductId = f.ProductId,
                                price_unit = f.price_unit
                            });
                        });
                        _context.Set<OrderItens>().AddRange(listItens);
                        _context.SaveChanges();
                        transaction.Commit();
                        return order.Entity.Id;

                    }
                    catch (System.Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

        public void UpdateOrder(Guid Id, string status)
        {
            using (_context)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {

                        var temp = _context.Set<Order>().FirstOrDefault(w => w.Id.Equals(Id));
                        temp.Status = status;
                        _context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (System.Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

    }
}