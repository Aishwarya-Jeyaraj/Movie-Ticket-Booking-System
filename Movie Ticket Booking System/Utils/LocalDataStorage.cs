using MovieTicketBookingSystem_V3.Models;

namespace MovieTicketBookingSystem_V3.Utils
{
    public static class LocalDataStorage
    {
        public static User user = new();
        public static Movie movie = new();
        public static Theatre theatre = new();
        public static Show show = new();
        public static Ticket ticket = new();

        public static Dictionary<int, int> TheatreList = new();
        public static Dictionary<int, int> ShowDateList = new();
        public static Dictionary<int, int> ShowTimeList = new();
        public static List<int> SeatList = new();

        public static List<int> SeatsBooked = new();
        public static List<int> SeatsFailedToBook = new();
        public static void ResetLocalDataStorage()
        {
            TheatreList.Clear();
            ShowDateList.Clear();
            ShowTimeList.Clear();
            SeatList.Clear();
            SeatsBooked.Clear();
            SeatsFailedToBook.Clear();
            ticket.SeatNumber.Clear();
        }
    }
}
