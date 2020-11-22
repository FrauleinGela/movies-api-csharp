using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApi.Models
{
    public class MovieBooking
    {
        public MovieBooking()
        {
            DatimeTimeUTC = DateTimeOffset.Now;
        }
        public string UserID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MovieBookingID { get; set; }
        public DateTimeOffset DatimeTimeUTC { get; set; }

        [ForeignKey("Movie")]
        public string MovieID { get; set; }
        public Movie Movie { get; set; }
    }
}
