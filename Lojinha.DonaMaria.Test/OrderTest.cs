using System;
using System.Collections.Generic;
using System.Text;
using Lojinha.DonaMaria.Data.Service;
using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Helper;
using Lojinha.DonaMaria.Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lojinha.DonaMaria.Test
{
    [TestClass]
   public class OrderTest
    {
        private readonly OrderService _service;
        private readonly ProductService productService;
        private readonly CustomerService customerService;

        public OrderTest()
        {
            MapperConfig.RegisterMappings();
            _service = new OrderService();
            customerService = new CustomerService();

        }

        [TestMethod]
        public void deve_retornar_todos_as_vendas()
        {
            var temp = _service.All();
            Assert.IsTrue(temp != null);
        }

        [TestMethod]
        public void deve_adicionar_um_produto()
        {
            var order = new Order
            {
               Id = Guid.NewGuid(),
                Created_at = DateTime.Now,
                Total = 800,
                CustomerId = customerService.Add(new Customer{Id = Guid.NewGuid(), Created_at = DateTime.Now, Name = "NameForOrderTest", Cpf = CpfHelper.GenerateCpf(), Email = "EmailForOrderTest@test.com", Updated_At = DateTime.Now}),
                Status = "CONCLUDED",
            };

            var id = _service.Add(order);
            var temp = _service.Get(id);
            Assert.IsTrue(temp != null);
        }
    }
}
