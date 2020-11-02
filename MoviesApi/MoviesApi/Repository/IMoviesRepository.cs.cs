using MoviesApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApi.Repository
{
    public interface IMoviesRepository
    {
        IQueryable<Movie> GetMovies(string title, string country, string language, string sortDirection);
        Task<Movie> GetMovie(string imdbId);
    }
}
