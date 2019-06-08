using Lojinha.DonaMaria.Exception;
using Lojinha.DonaMaria.Request;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Threading.Tasks;

namespace Lojinha.DonaMaria.Helper
{
    public class HandleExceptionHelper
    {
        private readonly RequestDelegate _next;

        public HandleExceptionHelper(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception e)
            {
                await HandleException(context, e);
            }
        }

        private static Task HandleException(HttpContext context, System.Exception exception)
        {
            HttpStatusCode code;
            object response = exception.Message;

            switch (exception)
            {

                case TokenException _:
                    code = HttpStatusCode.Forbidden;
                    response = new TokenException(exception.Message);
                    break;

                default:
                    code = HttpStatusCode.InternalServerError;
                    response = new InternalServerErrorResponseModel(exception.Message);
                    break;

            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
        }
    }
}
