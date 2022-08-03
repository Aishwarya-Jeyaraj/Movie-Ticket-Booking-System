using MovieTicketBookingSystem_V3.Controllers.Interface;
using MovieTicketBookingSystem_V3.DBQueries;
using MovieTicketBookingSystem_V3.Utils;

namespace MovieTicketBookingSystem_V3.Controllers
{
    public class SeatController

    {
        public List<int> ExecuteDisplayAction()
        {
            List<int> SeatListFromDB = ShowQueries.DisplaySeats();
            return SeatListFromDB;
        }

        public void ExecuteSelectAction(int seat)
        {
            if (Validator.InvalidSeatSelection(seat))
            {
                if (!LocalDataStorage.SeatsFailedToBook.Contains(seat))
                {
                    LocalDataStorage.SeatsFailedToBook.Add(seat);
                }
            }
            else
            {
                TicketQueries.BookTicket(seat);
                LocalDataStorage.SeatsBooked.Add(seat);
                LocalDataStorage.ticket.SeatNumber.Add(seat);
            }
        }
    }
}
