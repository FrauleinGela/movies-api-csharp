using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("{imdbId}")]

        public async Task<ActionResult<Task<Movie>>> GetMovieAsync([FromRoute] string imdbId)
        {
            var movie = await _moviesRepository.GetMovie(imdbId);
            if (movie != null) return Ok(movie);
            return NotFound(new { message = "Item not found" });
        }

        // TODO: Validate parameters
    }
}
