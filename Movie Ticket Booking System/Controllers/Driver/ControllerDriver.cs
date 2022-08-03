using MovieTicketBookingSystem_V3.Controllers.Interface;

namespace MovieTicketBookingSystem_V3.Controllers.Driver
{
    public class ControllerDriver
    {
        private readonly IController _controller;
        public ControllerDriver(IController controller)
        {
            _controller = controller;
        }
        public Dictionary<int,string> ExecuteDisplayAction()
        {
           return _controller.ExecuteDisplayAction();
        }
        public void ExecuteSelectAction(int i)
        {
            _controller.ExecuteSelectAction(i);
        }
    }
}
