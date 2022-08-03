using MovieTicketBookingSystem_V3.Controllers.Interface;
using MovieTicketBookingSystem_V3.DBQueries;
using MovieTicketBookingSystem_V3.Utils;

namespace MovieTicketBookingSystem_V3.Controllers
{
    public class MovieController : IController
    { 
        public Dictionary<int,string> ExecuteDisplayAction()
        {
            Dictionary<int,string> MoviesFromDB = MovieQueries.DisplayMovies();
            return MoviesFromDB;
        }
        public void ExecuteSelectAction(int movieChosen)
        {
            bool isInvalidInput = false;
            if (movieChosen != 0)
            {
                MovieQueries.FindMovieId(movieChosen);
                if (Validator.InvalidMovieSelection())
                {
                    isInvalidInput = true;
                }
            }
            else
            {
                isInvalidInput = true;
            }
            if (isInvalidInput)
            {
                OutputProvider.PrintMessageForInvalidInput();
                var movieChoice = InputReader.GetInputForUserChoices();
                ExecuteSelectAction(movieChoice);
            }
        }
    }
}