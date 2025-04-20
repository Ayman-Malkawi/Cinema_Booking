using CoreApiProject.Server.IDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowFilmController : ControllerBase
    {
        private readonly IData _data;

        public ShowFilmController(IData data)
        {
            _data = data;
        }


        [HttpGet("GetAllMovies")]

        public IActionResult GetMovies()
        {
            var get = _data.GetMovies();

            return Ok(get);

        }

        [HttpGet("GetMoviesByCategory/{categoryId}")]
        public IActionResult GetMoviesByCategory(int categoryId)
        {
            var movies = _data.GetMoviesByCategory(categoryId);
            return Ok(movies);
        }


        [HttpGet("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var categories = _data.GetAllCategories();
            return Ok(categories);
        }


    }
}
