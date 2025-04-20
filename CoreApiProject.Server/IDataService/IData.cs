using System.Collections.Generic;
using CoreApiProject.Server.Models;

namespace CoreApiProject.Server.IDataService
{
    public interface IData
    {
        public List<Movie> GetMovies();

        public List<Movie> GetMoviesByCategory(int categoryId);
        public List<MovieCategory> GetAllCategories();

    }
}
