using Lojinha.DonaMaria.Domain;
using Tmss_Back_end.Data.Repository.Interface.Base;

namespace Lojinha.DonaMaria.Data.Repository.Interface
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer validadeEntity(Customer entity);
    }
}
