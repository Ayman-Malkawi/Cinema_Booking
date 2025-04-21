using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IData _data;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(IData data, IHttpContextAccessor httpContextAccessor)
        {
            _data = data;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("logIn")]
        public IActionResult LogIn([FromBody] LoginDTO user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var loginUser = _data.LogIn(user, _httpContextAccessor);

            if (loginUser != null)
            {
                return Ok(new { id = loginUser.Id, message = "Login successful" });
            }
            else
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }
        }
    }

    }
