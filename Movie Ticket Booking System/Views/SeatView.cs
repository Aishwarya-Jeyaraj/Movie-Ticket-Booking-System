using MovieTicketBookingSystem_V3.Controllers;
using MovieTicketBookingSystem_V3.Controllers.Driver;
using MovieTicketBookingSystem_V3.Controllers.Interface;
using MovieTicketBookingSystem_V3.Utils;
using MovieTicketBookingSystem_V3.Views.Interface;

namespace MovieTicketBookingSystem_V3.Views
{
    public class SeatView : IView
    {
        readonly SeatController seatController = new();
        public void RenderDisplayAction()
        {
            OutputProvider.PrintMessageToDisplaySeats();
            List<int> SeatsFromDB = seatController.ExecuteDisplayAction();
            for (int i = 1; i <= 30; i++)
            {
                if (i % 5 == 0)
                {
                    if (SeatsFromDB.Contains(i))
                    {
                        Console.WriteLine("*");
                    }
                    else
                    {
                        Console.WriteLine(i);
                    }
                }
                else
                {
                    if (SeatsFromDB.Contains(i))
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write($"{i} ");
                    }
                }
            }
        }
        public void RenderSelectAction()
        {
            OutputProvider.PrintMessageToGetSeatInput();
            var seatsChosen = InputReader.GetInputForSeatChoice();
            List<string> InvalidSeatInputs = new();
            foreach (var seat in seatsChosen)
            {
                try
                {
                    if (!LocalDataStorage.SeatsBooked.Contains(Int32.Parse(seat)))
                    {
                        seatController.ExecuteSelectAction(Convert.ToInt32(seat));
                    }
                }
                catch (FormatException)
                {
                    if (seat != "")
                    {
                        InvalidSeatInputs.Add(seat);
                    }
                }
            }

            if (LocalDataStorage.SeatsFailedToBook.Count > 0)
            {
                OutputProvider.PrintMessageForFailedTicketBooking();

            }
            if (LocalDataStorage.SeatsBooked.Count > 0)
            {
                LocalDataStorage.ticket.UserId = LocalDataStorage.user.UserId;
                LocalDataStorage.ticket.ShowId = LocalDataStorage.show.ShowId;
                OutputProvider.PrintMessageForSeatsBooked();
                OutputProvider.PrintTicket ();
            }
            if(LocalDataStorage.SeatsBooked.Count == 0 && LocalDataStorage.SeatsFailedToBook.Count==0 && InvalidSeatInputs.Count <= 0)
            {
                OutputProvider.PrintMessageForNoSeatsBooked();
            }
            else if (InvalidSeatInputs.Count > 0)
            {
                OutputProvider.PrintMessageForInvalidSeatInput(InvalidSeatInputs);
            }
        }
    }
}
