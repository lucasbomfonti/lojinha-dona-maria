using Lojinha.DonaMaria.Data.Service.Interface;
using Lojinha.DonaMaria.Domain;
using Lojinha.DonaMaria.Dto.Order;
using Lojinha.DonaMaria.Request;
using Lojinha.DonaMaria.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using Tmss_Back_end.Controllers.Base;

namespace Lojinha.DonaMaria.Controllers
{
    [Route("api/v1/order")]
    public class OrderController : BaseController<Order, OrderDto, OrderInsertDto, OrderUpdateDto>
    {
        public OrderController(IOrderService baseService) : base(baseService)
        {
        }

        [HttpPost()]
        [AccessValidation]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(InternalServerErrorResponseModel), (int)HttpStatusCode.InternalServerError)]
        public new ActionResult Post([FromBody] OrderInsertDto dto)
        {
            var temp = ((IOrderService)_service).AddOrder(dto);
            return Ok(temp);
        }


        [HttpPut()]
        [AccessValidation]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponseModel), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(InternalServerErrorResponseModel), (int)HttpStatusCode.InternalServerError)]
        public new ActionResult Put(Guid id, string status)
        {
           ((IOrderService)_service).UpdateOrder(id, status);
            return Ok();
        }


        [HttpGet()]
        [AccessValidation]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(InternalServerErrorResponseModel), (int)HttpStatusCode.InternalServerError)]
        public ActionResult Get()
        {
            var temp = ((IOrderService)_service).GetOrder();
            return Ok(temp);
        }


    }
}
