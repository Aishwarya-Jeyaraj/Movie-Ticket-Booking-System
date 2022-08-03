using MovieTicketBookingSystem_V3.Views;
using MovieTicketBookingSystem_V3.Views.Driver;
using MovieTicketBookingSystem_V3.Views.Interface;

namespace MovieTicketBookingSystem_V3.Utils
{
    public static class TicketBookingSystem
    {
        static ViewDriver viewDriver;

        static readonly IView movieView = new MovieView();
        static readonly IView theatreView = new TheatreView();
        static readonly IView showDateView = new ShowDateView();
        static readonly IView showTimeView = new ShowTimeView();
        static readonly IView seatView = new SeatView();
        public static void SelectUser()
        {
            UserView userView = new UserView();
            userView.RenderSelectAction();
        }
        public static void DisplayMovies()
        {
            viewDriver = new ViewDriver(movieView);
            viewDriver.RenderDisplayAction();
        }
        public static void SelectMovie()
        {
            viewDriver = new ViewDriver(movieView);
            viewDriver.RenderSelectAction();
        }
        public static void DisplayTheatres()
        {
            viewDriver = new ViewDriver(theatreView);
            viewDriver.RenderDisplayAction();
        }
        public static void SelectTheatre()
        {
            viewDriver = new ViewDriver(theatreView);
            viewDriver.RenderSelectAction();
        }
        public static void DisplayShowDates()
        {
            viewDriver = new ViewDriver(showDateView);
            viewDriver.RenderDisplayAction();
        }
        public static void SelectShowDate()
        {
            viewDriver = new ViewDriver(showDateView);
            viewDriver.RenderSelectAction();
        }
        public static void DisplayShowTimes()
        {
            viewDriver = new ViewDriver(showTimeView);
            viewDriver.RenderDisplayAction();
        }
        public static void SelectShowTime()
        {
            viewDriver = new ViewDriver(showTimeView);
            viewDriver.RenderSelectAction();
        }
        public static void DisplaySeats()
        {
            SeatView seatView = new SeatView();
            seatView.RenderDisplayAction();
        }
        public static void SelectSeats()
        {
            viewDriver = new ViewDriver(seatView);
            viewDriver.RenderSelectAction();
        }
        public static void SystemRefresh()
        {
            LocalDataStorage.ResetLocalDataStorage();
        }
        public static void SystemReset()
        {
            DBConnectivity.ResetDBData();
        }
    }
}
