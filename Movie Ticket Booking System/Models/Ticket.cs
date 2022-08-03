namespace MovieTicketBookingSystem_V3.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public int ShowId { get; set; }
        public List<int> SeatNumber { get; set; }
        public Ticket()
        {
            SeatNumber = new List<int>();
        }
    }
}
