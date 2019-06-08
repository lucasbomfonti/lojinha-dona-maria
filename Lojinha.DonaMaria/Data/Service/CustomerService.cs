using System;
using Lojinha.DonaMaria.Data.Repository.Interface;
using Lojinha.DonaMaria.Data.Service.Interface;
using Lojinha.DonaMaria.Domain;
using Tmss_Back_end.Data.Repository.Interface.Base;
using Tmss_Back_end.Data.Service.Base;

namespace Lojinha.DonaMaria.Data.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService()
        {
        }

        public CustomerService(ICustomerRepository baseRepository) : base(baseRepository)
        {
        }

        public override Guid Add(Customer entity)
        {

            if (((ICustomerRepository)_repository).validadeEntity(entity) != null)
                throw new System.Exception("cliente ja cadastrado na nossa base de dados");
            entity.Updated_At = DateTime.Now;
            return base.Add(entity);
        }
    }
}
