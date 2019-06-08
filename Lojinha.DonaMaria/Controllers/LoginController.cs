using Lojinha.DonaMaria.Data.Service;
using Lojinha.DonaMaria.Dto.User;
using Lojinha.DonaMaria.Security;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Lojinha.DonaMaria.Controllers
{
    [Route("user/")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _adminProfileService;

        public LoginController(LoginService adminProfileService)
        {
            _adminProfileService = adminProfileService;
        }

        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            var login = _adminProfileService.login(dto.Name, dto.Password);
            var token = UserManagement.RegisterUser(login);
            return Ok(token);
        }
    }
}
