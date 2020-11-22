using System;

namespace MoviesApi.Dto
{
    public class MovieBookingDto
    {
        public string MovieBookingID { get; set; }
        public DateTimeOffset DatimeTimeUTC { get; set; }
        public string MovieID { get; set; }
    }
}
