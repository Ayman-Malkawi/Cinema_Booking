using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IData _data;
        public ContactController(IData data)
        {
            _data = data;
        }


        [HttpPost("FeedBack")]
        public IActionResult FeedBack([FromBody]ContactDTO Feedback)
        {

            if (Feedback == null)
            {
                return BadRequest();
            }


            var IsAdded = _data.AddFeedBack(Feedback);


            if(IsAdded == true)
            {
                return Ok();
            }


            return BadRequest();


        }


        [HttpGet("GetAllFeedback")]
        public IActionResult GetAllFeedback()
        {

           
            var Contact = _data.GetContacts();

            if (Contact == null)
            {
                return BadRequest();
            }


            return Ok(Contact);



        }


       

    }
}
