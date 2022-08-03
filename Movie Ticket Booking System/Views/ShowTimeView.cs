using MovieTicketBookingSystem_V3.Controllers;
using MovieTicketBookingSystem_V3.Controllers.Driver;
using MovieTicketBookingSystem_V3.Controllers.Interface;
using MovieTicketBookingSystem_V3.Utils;
using MovieTicketBookingSystem_V3.Views.Interface;

namespace MovieTicketBookingSystem_V3.Views
{
    public class ShowTimeView : IView
    {
        readonly IController showTimeController = new ShowTimeController();
        public void RenderDisplayAction()
        {
            OutputProvider.PrintMessageToDisplayShowDates();
            IView.controllerDriver = new ControllerDriver(showTimeController);
            Dictionary<int, string> ShowTimesFromDB = IView.controllerDriver.ExecuteDisplayAction();
            foreach (KeyValuePair<int, string> showTime in ShowTimesFromDB)
            {
                Console.WriteLine($"{showTime.Key}. {showTime.Value}");
            }
        }

        public void RenderSelectAction()
        {
            OutputProvider.PrintMessageToGetShowTimeInput();
            var showTimeChosen = InputReader.GetInputForUserChoices();
            IView.controllerDriver = new ControllerDriver(showTimeController);
            IView.controllerDriver.ExecuteSelectAction(showTimeChosen);
        }
    }
}
