using Lojinha.DonaMaria.Data.Service;
using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Helper;
using Lojinha.DonaMaria.Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lojinha.DonaMaria.Test
{
    [TestClass]
    public class CustomerTest
    {
        private readonly CustomerService _service;
        public CustomerTest()
        {
            MapperConfig.RegisterMappings();
            _service = new CustomerService();
        }

        [TestMethod]
        public void deve_retornar_todos_os_clientes()
        {
            var temp = _service.All();
            Assert.IsTrue(temp != null);
        }

        [TestMethod]
        public void deve_adicionar_um_clientes()
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "NameTest",
                Created_at = DateTime.Now,
                Cpf = CpfHelper.GenerateCpf(),
                Email = "NameTest@test.com.br"
            };

            var id =_service.Add(customer);
            var user = _service.Get(id);
            Assert.IsTrue(user != null);
        }

    }
}
