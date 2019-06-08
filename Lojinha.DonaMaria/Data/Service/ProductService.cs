using Lojinha.DonaMaria.Data.Repository.Interface;
using Lojinha.DonaMaria.Data.Service.Interface;
using Lojinha.DonaMaria.Domain;
using System;
using Tmss_Back_end.Data.Service.Base;

namespace Lojinha.DonaMaria.Data.Service
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService()
        {
        }

        public ProductService(IProductRepository baseRepository) : base(baseRepository)
        {
        }

        public override Guid Add(Product entity)
        {
            if (((IProductRepository)_repository).validadeEntity(entity) != null)
                throw new System.Exception("Não eh possivel adicionar um produto de nome repetido");

            entity.Sku = Guid.NewGuid();
            entity.Updated_at = DateTime.Now;

            return base.Add(entity);
        }

    }
}
