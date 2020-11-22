using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Controllers;
using MoviesApi.Dto;
using MoviesApi.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace MoviesApi.Test
{
    public class MovieBookingControllerTest
    {
        private readonly DbContextOptions<MoviesDbContext> _dbContextOptions;
        private MoviesDbContext _dbContext;
        public MovieBookingControllerTest()
        {
            _dbContextOptions = new DbContextOptionsBuilder<MoviesDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        }

        private MovieBookingController GetController(MoviesDbContext context)
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
    new Claim(ClaimTypes.Name, "user test"),
    new Claim(ClaimTypes.NameIdentifier, "user1"),
    new Claim("custom-claim", "example claim value"),
}, "mock"));
            var controller = new MovieBookingController(context);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
            return controller;
        }

        private void SeedDummyData()
        {
            _dbContext = new MoviesDbContext(_dbContextOptions);
            _dbContext.MovieBookings.Add(new MovieBooking()
            {
                UserID = "user2",
                MovieID = "movie1"
            });
            _dbContext.MovieBookings.Add(new MovieBooking()
            {
                UserID = "user1",
                MovieID = "movie3"
            });
            _dbContext.MovieBookings.Add(new MovieBooking()
            {
                UserID = "user1",
                MovieID = "movie2",
                MovieBookingID = "movieBooking1"
            });
            _dbContext.SaveChanges();
        }

        [Fact]
        public void GetMovieBookingsShouldReturnOkResult()
        {
            SeedDummyData();
            var moviesDbContext = new MoviesDbContext(_dbContextOptions);
            var controller = GetController(_dbContext);
            var result = controller.GetMovieBookings();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var bookings = (List<MovieBooking>)okResult.Value;
            Assert.Equal(2, bookings.Count);
        }

        [Fact]
        public void GetMovieBookingShouldReturnOkResult()
        {
            SeedDummyData();
            var moviesDbContext = new MoviesDbContext(_dbContextOptions);
            var controller = GetController(_dbContext);
            var result = controller.GetMovieBooking("movieBooking1");
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var booking = (MovieBooking)okResult.Value;
            Assert.Equal("movie2", booking.MovieID);
        }

        [Fact]
        public void GetMovieBookingShouldReturnNotFound()
        {
            SeedDummyData();
            var moviesDbContext = new MoviesDbContext(_dbContextOptions);
            var controller = GetController(_dbContext);
            var result = controller.GetMovieBooking("movieBooking3");
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateMovieBookingShouldReturnOkResult()
        {
            SeedDummyData();
            var moviesDbContext = new MoviesDbContext(_dbContextOptions);
            var controller = GetController(moviesDbContext);
            var result = controller.CreateMovieBooking(new MovieBookingDto()
            {
                MovieID = "movie4"
            });
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public void CreateMovieBookingShouldReturnBadRequestResult()
        {
            SeedDummyData();
            var moviesDbContext = new MoviesDbContext(_dbContextOptions);
            var controller = GetController(moviesDbContext);
            var result = controller.CreateMovieBooking(new MovieBookingDto()
            {
                MovieID = ""
            });
            Assert.IsType<BadRequestResult>(result.Result);
        }

    }
}
