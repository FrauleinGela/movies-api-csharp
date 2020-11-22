using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Dto;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieBookingController : ControllerBase
    {
        private readonly MoviesDbContext _context;

        public MovieBookingController(MoviesDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieBooking
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetMovieBookings()
        {
            var userEntity = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bookings = await _context.MovieBookings.Where(mb => mb.UserID == userEntity).Include(mb => mb.Movie).ToListAsync();
            return Ok(bookings);
        }

        // GET: api/MovieBooking/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetMovieBooking([FromRoute] string id)
        {
            var userEntity = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var movieBooking = await _context.MovieBookings.Include(mb => mb.Movie).SingleOrDefaultAsync(mb => mb.UserID == userEntity && mb.MovieBookingID == id);

            if (movieBooking == null)
            {
                return NotFound();
            }

            return Ok(movieBooking);
        }

        // PUT: api/MovieBooking/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMovieBooking(string id, MovieBooking movieBooking)
        //{
        //    if (id != movieBooking.MovieBookingID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(movieBooking).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MovieBookingExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/MovieBooking
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateMovieBooking([FromBody] MovieBookingDto movieDto)
        {
            var movieID = movieDto.MovieID;
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(movieID))
                return BadRequest();
            var userMovieBooking = await _context.MovieBookings.Include(mb => mb.Movie).FirstOrDefaultAsync(mb=>mb.UserID == userID && mb.MovieID == movieID);
            if (userMovieBooking != null)
            {
                return Conflict();
            }
            var movie = await _context.Movies.FindAsync(movieID);
            var booking = new MovieBooking()
            {
                UserID = userID,
                Movie = movie
            };
            _context.MovieBookings.Add(booking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieBookingExists(booking.MovieBookingID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            var dto = new MovieBookingDto()
            {
                DatimeTimeUTC = booking.DatimeTimeUTC,
                MovieBookingID = booking.MovieBookingID,
                MovieID = booking.MovieID
            };
            return CreatedAtAction("CreateMovieBooking", dto);
        }

        // DELETE: api/MovieBooking/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<MovieBooking>> DeleteMovieBooking(string id)
        //{
        //    var movieBooking = await _context.MovieBookings.FindAsync(id);
        //    if (movieBooking == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.MovieBookings.Remove(movieBooking);
        //    await _context.SaveChangesAsync();

        //    return movieBooking;
        //}

        private bool MovieBookingExists(string id)
        {
            return _context.MovieBookings.Any(e => e.MovieBookingID == id);
        }
    }
}
