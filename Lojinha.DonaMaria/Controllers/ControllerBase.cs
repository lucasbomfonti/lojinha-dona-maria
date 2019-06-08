using Lojinha.DonaMaria.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using Tmss_Back_end.Data.Service.Interface.Base;

namespace Tmss_Back_end.Controllers.Base
{
    public class BaseController<T, Td, TId, TUd> : ControllerBase where T : class where Td : class where TId : class where TUd : class
    {
        protected readonly IBaseService<T> _service;

        public BaseController(IBaseService<T> baseService)
        {
            _service = baseService;
        }

        protected ActionResult Add(TId model)
        {
            if (!ModelState.IsValid)
                throw new Exception("Valores Inválidos");
            var entity = MapperHelper.Map<TId, T>(model);
            var response = _service.Add(entity);
            return Ok(response);
        }

        protected ActionResult Update(Guid id, TUd modelo)
        {
            if (!ModelState.IsValid)
                throw new Exception("Invalid model");
            var entity = MapperHelper.Map<TUd, T>(modelo);
            var response = _service.Update(entity);
            return Ok(response);
        }

        protected ActionResult Delete(Guid id)
        {
            _service.Remove(id);
            return Ok();
        }

        protected ActionResult Get(Guid id)
        {
            var response = _service.Get(id);
            if (response == null)
                return NotFound();
            return Ok(MapperHelper.Map<T, Td>(response));
        }

        protected ActionResult All()
        {
            var response = _service.All();
            return Ok(MapperHelper.CopyList<T, Td>(response));
        }
    }
}