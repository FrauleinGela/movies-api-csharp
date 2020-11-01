using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Repository;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;
        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        [HttpGet]
        public ActionResult<List<Movie>> GetMovies(
            [FromQuery(Name = "title")] string title,
            [FromQuery(Name = "country")] string country,
            [FromQuery(Name = "language")] string language,
            [FromQuery(Name = "sortDirection")] string sortDirection)
        {
            var result = _moviesRepository.GetMovies(title, country, language, sortDirection).ToList();
            return Ok(result);
        }

        // TODO: Validate parameters
    }
}
