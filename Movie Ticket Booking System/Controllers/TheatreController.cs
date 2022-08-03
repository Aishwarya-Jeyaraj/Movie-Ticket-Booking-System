using MovieTicketBookingSystem_V3.Controllers.Interface;
using MovieTicketBookingSystem_V3.DBQueries;
using MovieTicketBookingSystem_V3.Utils;

namespace MovieTicketBookingSystem_V3.Controllers
{
    public class TheatreController : IController
    {
        public Dictionary<int, string> ExecuteDisplayAction()
        {
            Dictionary<int,string> TheatresFromDB = TheatreQueries.DisplayTheatres();
            return TheatresFromDB;
        }

        public void ExecuteSelectAction(int theatreChosen)
        {
            bool isInvalidInput = false;
            if (theatreChosen != 0)
            {
                if (Validator.InvalidTheatreSelection(theatreChosen))
                {
                    isInvalidInput = true;
                }
                else
                {
                    TheatreQueries.FindTheatreId(LocalDataStorage.TheatreList[theatreChosen]);
                }
            }
            else
            {
                isInvalidInput = true;
            }
            if (isInvalidInput)
            {
                OutputProvider.PrintMessageForInvalidInput();
                var theatreChoice = InputReader.GetInputForUserChoices();
                ExecuteSelectAction(theatreChoice);
            }
        }
    }
}
