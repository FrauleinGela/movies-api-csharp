using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Controllers;
using MoviesApi.Models;
using MoviesApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MoviesApi.Test
{
    public class MoviesControllerTest
    {

        private readonly DbContextOptions<MoviesDbContext> _dbContextOptions;
        private int moviesCount = 10;
        public MoviesControllerTest()
        {
            _dbContextOptions = new DbContextOptionsBuilder<MoviesDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        }

        public MoviesController CreateController(MoviesDbContext context)
        {
            var repository = new MoviesRepository(context);
            var controller = new MoviesController(repository);
            return controller;
        }

        private void SeedDummyData()
        {
            using (var moviesDbContext = new MoviesDbContext(_dbContextOptions))
            {
                for (var i = 0; i < moviesCount; i++)
                {
                    moviesDbContext.Movies.Add(new Movie
                    {
                        Title = $"Movie title {i}",
                        Year = "1975",
                        Rated = "R",
                        Released = "19 Nov 1975",
                        Runtime = "133 min",
                        Genre = "Drama",
                        Director = "Milos Forman",
                        Writer = "Lawrence Hauben (screenplay), Bo Goldman (screenplay), Ken Kesey (based on the novel by), Dale Wasserman (the play version= \"One Flew Over the Cuckoo's Nest\" by)",
                        Actors = "Michael Berryman, Peter Brocco, Dean R. Brooks, Alonzo Brown",
                        Plot = "A criminal pleads insanity and is admitted to a mental institution, where he rebels against the oppressive nurse and rallies up the scared patients.",
                        Language = "English, Spanish",
                        Country = "USA, France",
                        Awards = "Won 5 Oscars. Another 30 wins & 15 nominations.",
                        Poster = "https=//m.media-amazon.com/images/M/MV5BZjA0OWVhOTAtYWQxNi00YzNhLWI4ZjYtNjFjZTEyYjJlNDVlL2ltYWdlL2ltYWdlXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_SX300.jpg",
                        ImdbRating = "8.7",
                        ImdbID = $"tt0073486-{i}"
                    });
                }
                moviesDbContext.SaveChanges();
            }
        }
        [Fact]
        public void GetAllMoviesShouldReturnOkResult()
        {
            SeedDummyData();
            using (var moviesDbContext = new MoviesDbContext(_dbContextOptions))
            {
                var controller = CreateController(moviesDbContext);
                var actionResult = controller.GetMovies(null, null, null, null);
                var result = actionResult.Result as OkObjectResult;
                var movies = (List<Movie>)result.Value;
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(moviesCount, movies.Count);
            }

        }

        [Fact]
        public void GetMoviesWithTitleFilteringReturnOkResult()
        {
            SeedDummyData();
            using (var moviesDbContext = new MoviesDbContext(_dbContextOptions))
            {
                var controller = CreateController(moviesDbContext);
                var actionResult = controller.GetMovies("Movie title 1", "", "", "");
                var result = actionResult.Result as OkObjectResult;
                var movies = (List<Movie>)result.Value;
                Assert.IsType<OkObjectResult>(result);
                Assert.Single(movies);
            }

        }

        [Fact]
        public void GetMoviesWithInsensitiveCaseReturnOkResult()
        {
            SeedDummyData();
            using (var moviesDbContext = new MoviesDbContext(_dbContextOptions))
            {
                var controller = CreateController(moviesDbContext);
                var actionResult = controller.GetMovies("movie tiTle 1", "", "", "");
                var result = actionResult.Result as OkObjectResult;
                var movies = (List<Movie>)result.Value;
                Assert.IsType<OkObjectResult>(result);
                Assert.Single(movies);
            }

        }

        [Fact]
        public void GetMoviesWithLanguangeFilteringReturnOkResult()
        {
            SeedDummyData();
            using (var moviesDbContext = new MoviesDbContext(_dbContextOptions))
            {
                var controller = CreateController(moviesDbContext);
                var actionResult = controller.GetMovies("", "", "English, Spanish", "");
                var result = actionResult.Result as OkObjectResult;
                var movies = (List<Movie>)result.Value;
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(10, movies.Count);

                var actionResult2 = controller.GetMovies("", "", "Spanish", "");
                var result2 = actionResult2.Result as OkObjectResult;
                var movies2 = (List<Movie>)result2.Value;
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(10, movies2.Count);
            }

        }
        [Fact]
        public void GetMoviesWithCountryFilteringReturnOkResult()
        {
            SeedDummyData();
            using (var moviesDbContext = new MoviesDbContext(_dbContextOptions))
            {
                var controller = CreateController(moviesDbContext);
                var actionResult = controller.GetMovies("", "USA, France", "", "");
                var result = actionResult.Result as OkObjectResult;
                var movies = (List<Movie>)result.Value;
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(10, movies.Count);
            }
        }

        [Fact]
        public void GetMoviesSortedDescendingReturnOkResult()
        {
            SeedDummyData();
            using (var moviesDbContext = new MoviesDbContext(_dbContextOptions))
            {
                var controller = CreateController(moviesDbContext);
                var actionResult = controller.GetMovies("", "", "", "DESC");
                var result = actionResult.Result as OkObjectResult;
                var movies = (List<Movie>)result.Value;
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal("tt0073486-9", movies.First().ImdbID);
                Assert.Equal("tt0073486-0", movies.Last().ImdbID);
            }

        }


        [Fact]
        public void GetMoviesSortedAscendingReturnOkResult()
        {
            SeedDummyData();
            using (var moviesDbContext = new MoviesDbContext(_dbContextOptions))
            {
                var controller = CreateController(moviesDbContext);
                var actionResult = controller.GetMovies("", "", "", "ASC");
                var result = actionResult.Result as OkObjectResult;
                var movies = (List<Movie>)result.Value;
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal("tt0073486-0", movies.First().ImdbID);
                Assert.Equal("tt0073486-9", movies.Last().ImdbID);
            }

        }

        [Fact]
        public async void GetMovieReturnOkResult()
        {
            SeedDummyData();
            using (var moviesDbContext = new MoviesDbContext(_dbContextOptions))
            {
                var imdbId = "tt0073486-9";
                var controller = CreateController(moviesDbContext);
                var actionResult = await controller.GetMovieAsync(imdbId);
                var result = actionResult.Result as OkObjectResult;
                var movie = result.Value as Movie;
                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(200, result.StatusCode);
                Assert.NotNull(movie);
                Assert.Equal(imdbId, movie.ImdbID);
            }

        }
        [Fact]
        public async void GetMovieReturnNotFoundResult()
        {
            SeedDummyData();
            using (var moviesDbContext = new MoviesDbContext(_dbContextOptions))
            {
                var imdbId = "xxxxx";
                var controller = CreateController(moviesDbContext);
                var actionResult = await controller.GetMovieAsync(imdbId);
                var result = actionResult.Result as NotFoundObjectResult;
                Assert.Equal(404, result.StatusCode);
            }

        }
    }
}
