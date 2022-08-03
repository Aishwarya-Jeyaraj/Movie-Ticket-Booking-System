using MovieTicketBookingSystem_V3.Utils;

namespace MovieTicketBookingSystem_V3
{
    class Program
    {
        public static void Main(String[] args)
        {
            bool continueBookingTickets;
            OutputProvider.PrintWelcomeMessage();
            do
            {
                TicketBookingSystem.SelectUser();
                TicketBookingSystem.DisplayMovies();
                TicketBookingSystem.SelectMovie();
                TicketBookingSystem.DisplayTheatres();
                TicketBookingSystem.SelectTheatre();
                TicketBookingSystem.DisplayShowDates();
                TicketBookingSystem.SelectShowDate();
                TicketBookingSystem.DisplayShowTimes();
                TicketBookingSystem.SelectShowTime();
                TicketBookingSystem.DisplaySeats();
                TicketBookingSystem.SelectSeats();
                TicketBookingSystem.SystemRefresh();
                OutputProvider.PrintMessageForContinueBookingTickets();
                continueBookingTickets = Validator.CheckContinueBooking(InputReader.GetInputToContinueBookingTickets());
                OutputProvider.PrintBorder();
            } while (continueBookingTickets);
            OutputProvider.PrintMessageForProgramExit();
            TicketBookingSystem.SystemReset(); // Uncomment To Reset the DataBase
        }
    }
}
