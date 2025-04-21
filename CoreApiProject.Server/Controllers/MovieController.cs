using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IData _data;
        public MovieController(IData data)
        {
            _data = data;
        }

        [HttpGet("getAllMovies")]
        public IActionResult GetAllMovies()
        {
            var allMovies = _data.GetAllMovies(); // استدعاء الدالة من الـ Data Service
            return Ok(allMovies); // إرجاع الأفلام بشكل JSON
        }




        [HttpPost("addMovie")]
        public IActionResult AddMovie([FromBody] MovieDTO dto)
        {
            var result = _data.AddMovie(dto);

            if (result)
            {
                return Ok("Movie added successfully.");
            }

            return BadRequest("Failed to add movie. Please check the category ID and try again.");
        }



        [HttpPut("editMovie/{id}")]
        public IActionResult EditMovie(int id, [FromBody] MovieDTO dto)
        {
            var result = _data.EditMovie(id, dto);
            if (!result)
            {
                return NotFound("Movie not found or category doesn't exist.");
            }

            return Ok("Movie updated successfully");
        }



        [HttpPut("toggleViable/{id}")]
        public IActionResult ToggleViable(int id)
        {
            var success = _data.ToggleMovieViable(id);
            if (!success)
                return NotFound("Movie not found");

            return Ok("Movie viable status updated");
        }



        [HttpGet("getMovieById/{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            var movie = _data.GetMovieById(id);
            if (movie == null)
            {
                return NotFound("Movie not found");
            }
            return Ok(movie);
        }
    }
}
