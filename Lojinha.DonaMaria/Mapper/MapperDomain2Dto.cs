using AutoMapper;
using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Dto.Customer;
using Lojinha.DonaMaria.Dto.Product;

namespace Lojinha.DonaMaria.Mapper
{
    public class MapperDomain2Dto : Profile
    {
        public MapperDomain2Dto()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Customer, CustomerDto>();

        }
    }
}
