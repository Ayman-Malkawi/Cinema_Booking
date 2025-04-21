using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IData _data;
        public UserController(IData data)
        {
            _data = data;
        }


        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var allUsers = _data.GetAllUsers();

            return Ok(allUsers);
        }


        [HttpGet("getUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _data.GetUserById(id);
            if (user == null) return NotFound("User not found");
            return Ok(user);
        }


        [HttpPost("addToBlacklist")]
        public IActionResult AddToBlacklist([FromBody] BlacklistDTO dto)
        {
            _data.AddToBlacklist(dto);
            return Ok("User added to blacklist");
        }






        [HttpPut("updateUser")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            _data.UpdateUser(user);
            return Ok("User updated successfully");
        }


		



    }
}
