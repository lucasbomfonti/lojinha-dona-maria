using Lojinha.DonaMaria.Data.Service;
using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lojinha.DonaMaria.Test
{
    [TestClass]
    public class ProductTest
    {
        private readonly ProductService _service;
        public ProductTest()
        {
            MapperConfig.RegisterMappings();
            _service = new ProductService();
        }

        [TestMethod]
        public void deve_retornar_todos_os_produtos()
        {
            var temp = _service.All();
            Assert.IsTrue(temp != null);
        }

        [TestMethod]
        public void deve_adicionar_um_produto()
        {
            var product = new Product
            {
               Id = Guid.NewGuid(),
                Name = "ProductTest",
                Created_at = DateTime.Now,
                Sku = Guid.NewGuid(),
                Updated_at = DateTime.Now,
                Price = 800
            };

            var id = _service.Add(product);
            var temp = _service.Get(id);
            Assert.IsTrue(temp != null);
        }
    }
}
