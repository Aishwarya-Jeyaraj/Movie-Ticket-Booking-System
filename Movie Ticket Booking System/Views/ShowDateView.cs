using MovieTicketBookingSystem_V3.Controllers;
using MovieTicketBookingSystem_V3.Controllers.Driver;
using MovieTicketBookingSystem_V3.Controllers.Interface;
using MovieTicketBookingSystem_V3.Utils;
using MovieTicketBookingSystem_V3.Views.Interface;

namespace MovieTicketBookingSystem_V3.Views
{
    public class ShowDateView : IView
    {
        readonly IController showDateController = new ShowDateController();
        public void RenderDisplayAction()
        {
            OutputProvider.PrintMessageToDisplayShowDates();
            IView.controllerDriver = new ControllerDriver(showDateController);
            Dictionary<int, string> ShowDatesFromDB =  IView.controllerDriver.ExecuteDisplayAction();
            foreach (KeyValuePair<int, string> showDate in ShowDatesFromDB)
            {
                Console.WriteLine($"{showDate.Key}. {showDate.Value}");
            }
        }

        public void RenderSelectAction()
        {
            OutputProvider.PrintMessageToGetShowDateInput();
            var showDateChosen = InputReader.GetInputForUserChoices();
            IView.controllerDriver = new ControllerDriver(showDateController);
            IView.controllerDriver.ExecuteSelectAction(showDateChosen);
        }
    }
}
