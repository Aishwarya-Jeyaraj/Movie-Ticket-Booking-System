using MovieTicketBookingSystem_V3.Controllers.Interface;
using MovieTicketBookingSystem_V3.DBQueries;
using MovieTicketBookingSystem_V3.Utils;

namespace MovieTicketBookingSystem_V3.Controllers
{
    public class ShowDateController : IController
    {
        public Dictionary<int, string> ExecuteDisplayAction()
        {
            Dictionary<int,string> ShowDatesFromDB = ShowQueries.DisplayShowDates();
            return ShowDatesFromDB;
        }

        public void ExecuteSelectAction(int showDateChosen)
        {
            bool isInvalidInput = false;
            if (showDateChosen != 0)
            {
                if (Validator.InvalidShowDateSelection(showDateChosen))
                {
                    isInvalidInput = true;
                }
                else
                {
                    ShowQueries.FindShowDate(showDateChosen);
                }
            }
            else
            {
                isInvalidInput = true;
            }
            if (isInvalidInput)
            {
                OutputProvider.PrintMessageForInvalidInput();
                var showDateChoice = InputReader.GetInputForUserChoices();
                ExecuteSelectAction(showDateChoice);
            }
        }
    }
}
