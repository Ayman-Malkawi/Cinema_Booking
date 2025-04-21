using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly IData _data;

        public SignUpController(IData data)
        {
            _data = data;
        }

        [HttpPost("signUp")]
        public IActionResult SignUp([FromBody] SignUpDTO user)
        {


            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                var register = _data.SignUp(user);
                if (register)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }


        }
    }
}
