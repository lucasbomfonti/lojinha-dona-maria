using Lojinha.DonaMaria.Domain;
using Tmss_Back_end.Data.Repository.Interface.Base;

namespace Lojinha.DonaMaria.Data.Repository.Interface
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product validadeEntity(Product product);
    }
}
