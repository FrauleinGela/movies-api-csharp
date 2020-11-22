using Microsoft.EntityFrameworkCore;

namespace MoviesApi.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieBooking> MovieBookings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasKey(m => new { m.ImdbID });
            modelBuilder.Entity<MovieBooking>().HasKey(mb => mb.MovieBookingID);
            modelBuilder.Entity<Movie>().HasMany(m => m.MovieBookings).WithOne(mb=> mb.Movie);
        }

    }
}
