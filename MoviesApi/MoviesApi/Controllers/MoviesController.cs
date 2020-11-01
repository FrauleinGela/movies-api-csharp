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
        public ActionResult<List<Movie>> GetMovies()
        {
            return Ok(_moviesRepository.GetMovies().ToList());
        }

    }
}
