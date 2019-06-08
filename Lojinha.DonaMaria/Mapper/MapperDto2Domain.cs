using AutoMapper;
using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Dto.Customer;
using Lojinha.DonaMaria.Dto.Product;

namespace Lojinha.DonaMaria.Mapper
{
    public class MapperDto2Domain : Profile
    {
        public MapperDto2Domain()
        {
            CreateMap<ProductInsertDto, Product>();
            CreateMap<CustomerInsertDto, Customer>();
        }
    }
}
