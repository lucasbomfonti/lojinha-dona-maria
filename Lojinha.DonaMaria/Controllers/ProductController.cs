using Lojinha.DonaMaria.Data.Service.Interface;
using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Dto.Product;
using Lojinha.DonaMaria.Security;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tmss_Back_end.Controllers.Base;

namespace Lojinha.DonaMaria.Controllers
{
    [Route("api/v1/product")]
    public class ProductController : BaseController<Product, ProductDto, ProductInsertDto, ProductUpdateDto>
    {
        public ProductController(IProductService baseService) : base(baseService)
        {
        }


        [HttpPost()]
        [AccessValidation]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public new ActionResult Post([FromBody] ProductInsertDto dto)
        {
            return Add(dto);
        }

        [HttpGet()]
        [AccessValidation]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult Get()
        {
            return All();
        }
    }
}
