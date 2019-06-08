using Lojinha.DonaMaria.Data.Repository.Interface;
using Lojinha.DonaMaria.Data.Service.Interface;
using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Dto.Order;
using System;
using System.Collections.Generic;
using Tmss_Back_end.Data.Service.Base;

namespace Lojinha.DonaMaria.Data.Service
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService()
        {
        }

        public OrderService(IOrderRepository baseRepository) : base(baseRepository)
        {
            _repository = baseRepository;
        }

        public Guid AddOrder(OrderInsertDto dto)
        {
            var Order = _repository.AddOrder(dto);
            return Order;
        }

        public List<OrderDto> GetOrder()
        {
            
            var orders = _repository.GetOrder();


            orders.ForEach(f =>
            {
                var temp = _repository.GetAll(f.Id);
                f.Itens.AddRange(temp);
            });

            return orders;
        }

        public void UpdateOrder(Guid Id, string status)
        {
            _repository.UpdateOrder(Id, status);
        }
    }
}
