using MovieTicketBookingSystem_V3.Controllers.Interface;
using MovieTicketBookingSystem_V3.DBQueries;
using MovieTicketBookingSystem_V3.Utils;

namespace MovieTicketBookingSystem_V3.Controllers
{
    public class ShowTimeController : IController
    {
        public Dictionary<int, string> ExecuteDisplayAction()
        {
            Dictionary<int,string> ShowTimeFromDB = ShowQueries.DisplayShowTimes();
            return ShowTimeFromDB;
        }

        public void ExecuteSelectAction(int showTimeChosen)
        {
            bool isInvalidInput = false;
            if (showTimeChosen != 0)
            {
                if (Validator.InvalidShowTimeSelection(showTimeChosen))
                {
                    isInvalidInput = true;
                }
                else
                {
                    ShowQueries.FindShowTime(showTimeChosen);
                    LocalDataStorage.show.ShowId = LocalDataStorage.ShowTimeList[showTimeChosen];
                }
            }
            else
            {
                isInvalidInput = true;
            }
            if (isInvalidInput)
            {
                OutputProvider.PrintMessageForInvalidInput();
                var showTimeChoice = InputReader.GetInputForUserChoices();
                ExecuteSelectAction(showTimeChoice);
            }
        }
    }
}
