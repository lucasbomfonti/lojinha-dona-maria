using Lojinha.DonaMaria.Data.Service.Interface;
using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Dto.Customer;
using Lojinha.DonaMaria.Request;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Lojinha.DonaMaria.Security;
using Tmss_Back_end.Controllers.Base;

namespace Lojinha.DonaMaria.Controllers
{
    [Route("api/v1/customer")]
    public class CustomerController : BaseController<Customer, CustomerDto, CustomerInsertDto, CustomerUpdateDto>
    {
        public CustomerController(ICustomerService baseService) : base(baseService)
        {
        }

        [HttpPost()]
        [AccessValidation]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(InternalServerErrorResponseModel), (int)HttpStatusCode.InternalServerError)]
        public new ActionResult Post([FromBody] CustomerInsertDto dto)
        {
            return Add(dto);
        }

        [HttpGet()]
        [AccessValidation]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerErrorResponseModel), (int)HttpStatusCode.InternalServerError)]
        public ActionResult Get()
        {
            return All();
        }

    }
}
