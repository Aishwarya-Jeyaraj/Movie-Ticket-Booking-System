using MovieTicketBookingSystem_V3.Controllers;
using MovieTicketBookingSystem_V3.Controllers.Driver;
using MovieTicketBookingSystem_V3.Controllers.Interface;
using MovieTicketBookingSystem_V3.Utils;
using MovieTicketBookingSystem_V3.Views.Interface;

namespace MovieTicketBookingSystem_V3.Views
{
    public class TheatreView : IView
    {
        readonly IController theatreController = new TheatreController();
        public void RenderDisplayAction()
        {
            OutputProvider.PrintMessageToDisplayTheatres();
            IView.controllerDriver = new ControllerDriver(theatreController);
            Dictionary<int, string> TheatresFromDB = IView.controllerDriver.ExecuteDisplayAction();
            foreach (KeyValuePair<int, string> theatres in TheatresFromDB)
            {
                Console.WriteLine($"{theatres.Key}. {theatres.Value}");
            }
        }

        public void RenderSelectAction()
        {
            OutputProvider.PrintMessageToGetTheatreInput();
            var theatreChosen = InputReader.GetInputForUserChoices();
            IView.controllerDriver = new ControllerDriver(theatreController);
            IView.controllerDriver.ExecuteSelectAction(theatreChosen);
        }
    }
}
