using ChatChit.Data;
using ChatChit.Models;
using ChatChit.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using BC = BCrypt.Net.BCrypt;

namespace ChatChit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> getAllUser()
        {
            try
            {
                return Ok(await _userService.GetAllUser());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            UserModel findUser = await _userService.GetUser(id);
            if (findUser == null)
            {
                return NotFound();
            }
            return Ok(findUser);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserModel user)
        {
            var hashedPassword = BC.HashPassword(user.password);
            UserModel newUser = new UserModel();
            newUser.fullName = user.fullName;
            newUser.email = user.email;
            newUser.password = hashedPassword;
            newUser.createdAt = DateTime.Now.ToUniversalTime();
            newUser.updatedAt = DateTime.Now.ToUniversalTime();


                await _userService.AddUser(newUser);
                return Ok(newUser);

        }
    }
}
