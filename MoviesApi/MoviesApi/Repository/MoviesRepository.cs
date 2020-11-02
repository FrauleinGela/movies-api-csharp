using MoviesApi.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MoviesApi.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MoviesDbContext _dbContext;
        public MoviesRepository(MoviesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Movie> GetMovies(string title, string country, string language, string sortDirection)
        {
            var moviesRoot = _dbContext.Movies;
            Expression<Func<Movie, bool>> filterByTitle, filterByCountry, filterByLanguage;
            filterByTitle = item => item.Title.ToLower().Contains(string.IsNullOrEmpty(title) ? "" : title.ToLower().Trim());
            filterByCountry = item => item.Country.Contains(string.IsNullOrEmpty(country) ? "" : country.Trim());
            filterByLanguage = item => item.Language.Contains(string.IsNullOrEmpty(language) ? "" : language.Trim());
            var itemsExpression = moviesRoot.Where(filterByTitle)
                .Where(filterByCountry)
                .Where(filterByLanguage);
            if (sortDirection == "DESC")
                itemsExpression = itemsExpression.OrderByDescending(item => item.Title);
            else
                itemsExpression = itemsExpression.OrderBy(item => item.Title);

            return itemsExpression;
        }
    }
}
