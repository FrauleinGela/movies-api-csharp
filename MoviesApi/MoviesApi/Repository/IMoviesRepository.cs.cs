using MoviesApi.Models;
using System.Linq;

namespace MoviesApi.Repository
{
    public interface IMoviesRepository
    {
        IQueryable<Movie> GetMovies();
    }
}
