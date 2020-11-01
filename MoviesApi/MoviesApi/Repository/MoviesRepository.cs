using MoviesApi.Models;
using System.Linq;

namespace MoviesApi.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MoviesDbContext _dbContext;
        public MoviesRepository(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Movie> GetMovies()
        {
            return _dbContext.Movies;
        }
    }
}
