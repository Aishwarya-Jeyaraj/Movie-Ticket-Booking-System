using MovieTicketBookingSystem_V3.Controllers;
using MovieTicketBookingSystem_V3.Controllers.Driver;
using MovieTicketBookingSystem_V3.Controllers.Interface;
using MovieTicketBookingSystem_V3.Utils;
using MovieTicketBookingSystem_V3.Views.Interface;

namespace MovieTicketBookingSystem_V3.Views
{
    public class MovieView : IView
    {
        readonly IController movieController = new MovieController();
        public int InvalidInput { get; set; }
        public void RenderDisplayAction()
        {
            OutputProvider.PrintMessageToDisplayMovies();
            IView.controllerDriver = new ControllerDriver(movieController);
            Dictionary<int,string> MoviesFromDB = IView.controllerDriver.ExecuteDisplayAction();
            foreach (KeyValuePair<int, string> movie in MoviesFromDB)
            {
                Console.WriteLine($"{movie.Key}. {movie.Value}");
            }

        }

        public void RenderSelectAction()
        {
            OutputProvider.PrintMessageToGetMovieInput();
            var movieChosen = InputReader.GetInputForUserChoices();
            IView.controllerDriver = new ControllerDriver(movieController);
            IView.controllerDriver.ExecuteSelectAction(movieChosen);
        }
    }
}
