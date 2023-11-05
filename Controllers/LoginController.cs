using ChatChit.Models;
using ChatChit.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatChit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            IActionResult response = Unauthorized();
            if (login.email != null && login.password != null && login.email != "" && login.password != "")
            {
                var user = await _loginService.CheckInformation(login.email, login.password);
                if (user != null)
                {
                    var tokenString = _loginService.GenerateJSONWebToken(user);
                    response = Ok(new { token = tokenString });
                    return response;
                }
                else
                {
                    var result = new
                    {
                        auth = false,
                        message = "Wrong username/password!",
                    };
                    return NotFound(result);
                }
            }
            else
            {
                var result = new
                {
                    auth = false,
                    message = "Empty email/password"
                };
                return NotFound(result);
            }
        }
    }
}
