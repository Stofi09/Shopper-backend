using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/all")]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("/user/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var (user, errorMessage) = await _userService.GetUserByUsernameAsync(username);

            if (user == null)
            {
                return NotFound(new { Message = errorMessage });
            }

            return Ok(user);
        }

    }
}
