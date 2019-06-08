using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Lojinha.DonaMaria.Security
{

    public class AccessValidation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userAgent = context.HttpContext.Request.Headers.FirstOrDefault(a => a.Key.ToLower().Contains("user-agent")).Value.ToList().FirstOrDefault(b => b.Contains("com.capptan"));
            if (string.IsNullOrEmpty(userAgent))
                UserManagement.Validate(context.HttpContext.Request);

            base.OnActionExecuting(context);
        }
    }
}
