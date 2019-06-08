using System;
using System.Collections.Generic;
using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Dto.Order;
using Tmss_Back_end.Data.Repository.Interface.Base;

namespace Lojinha.DonaMaria.Data.Repository.Interface
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Guid AddOrder(OrderInsertDto dto);
        List<Product> GetAll(Guid orders);
        List<OrderDto> GetOrder();
        void UpdateOrder(Guid Id, string status);
    }
}
