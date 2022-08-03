namespace MovieTicketBookingSystem_V3.Models
{
    public class Show
    {
        public int ShowId { get; set; }
        public int TheatreId { get; set; }
        public int MovieId { get; set; }
        public DateOnly ShowDate { get; set; }
        public TimeOnly ShowTime { get; set; }
    }
}
