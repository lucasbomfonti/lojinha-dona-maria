using System.Linq;
using Lojinha.DonaMaria.Data.Repository.Interface;
using Lojinha.DonaMaria.Domain;
using Tmss_Back_end.Data.Repository.Base;
using Tmss_Back_end.Data.Repository.Context;

namespace Lojinha.DonaMaria.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }

        public Product validadeEntity(Product product)
        {
            return _context.Set<Product>().FirstOrDefault(f => f.Name.Equals(product.Name));
        }
    }
}
