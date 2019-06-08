using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Dto.Order;
using System;
using System.Collections.Generic;
using Tmss_Back_end.Data.Service.Interface.Base;

namespace Lojinha.DonaMaria.Data.Service.Interface
{
    public interface IOrderService : IBaseService<Order>
    {
        Guid AddOrder(OrderInsertDto dto);
        List<OrderDto> GetOrder();
        void UpdateOrder(Guid Id, string status);
    }
}
