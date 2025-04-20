using CoreApiProject.Server.Models;

namespace CoreApiProject.Server.DataService
{
    public class DataS : IDataService.IData
    {
        private readonly MyDbContext _context;

        public DataS(MyDbContext context)
        {

            _context = context;

        }


        public List<Movie> GetMovies()
        {

            var gets = _context.Movies.ToList();
            return gets;

        }

        public List<Movie> GetMoviesByCategory(int categoryId)
        {

            var movies = _context.Movies.Where(m => m.CategoryId == categoryId).ToList();

            return movies;


        }

        public List<MovieCategory> GetAllCategories()
        {
            return _context.MovieCategories.ToList();
        }

    }
}
