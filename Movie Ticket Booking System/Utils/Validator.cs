namespace MovieTicketBookingSystem_V3.Utils
{
    public class Validator
    {
        public static bool InvalidUserName(string userName)
        {
            if (!userName.All(Char.IsLetter) || userName=="")
            {
                return true;
            }
            else
            {
                if (userName.Length >= 3) { return false; }
                else { return true; }
            }
        }
        public static bool InvalidMovieSelection()
        {
            if (LocalDataStorage.movie.MovieId == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool InvalidTheatreSelection(int theatreChosen)
        {
            if (LocalDataStorage.TheatreList.ContainsKey(theatreChosen))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool InvalidShowDateSelection(int showDateChosen)
        {
            if (LocalDataStorage.ShowDateList.ContainsKey(showDateChosen))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool InvalidShowTimeSelection(int showTimeChosen)
        {
            if (LocalDataStorage.ShowTimeList.ContainsKey(showTimeChosen))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool InvalidSeatSelection(int seat)
        {
            if (LocalDataStorage.SeatList.Contains(seat) || seat > 30 || seat <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool CheckContinueBooking(char bookAnotherTime)
        {
            bool continueBookingTickets;
            if (bookAnotherTime == 'Y')
            {
                continueBookingTickets = true;
            }
            else if (bookAnotherTime == 'N')
            {
                continueBookingTickets = false;
            }
            else
            {
                OutputProvider.PrintErrorMessageForContinueBookingTickets();
                continueBookingTickets = CheckContinueBooking(InputReader.GetInputToContinueBookingTickets());
            }

            return continueBookingTickets;
        }
    }
}
