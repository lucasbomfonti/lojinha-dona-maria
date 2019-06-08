using System.Linq;
using Lojinha.DonaMaria.Data.Repository.Interface;
using Lojinha.DonaMaria.Domain;
using Tmss_Back_end.Data.Repository.Base;
using Tmss_Back_end.Data.Repository.Context;

namespace Lojinha.DonaMaria.Data.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context)
        {
        }

        public Customer validadeEntity(Customer entity)
        {
            return _context.Set<Customer>()
                .FirstOrDefault(w => w.Cpf.Equals(entity.Cpf) || w.Email.Equals(entity.Email));
        }
    }
}
