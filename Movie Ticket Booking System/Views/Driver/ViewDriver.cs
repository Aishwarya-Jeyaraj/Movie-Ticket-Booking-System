using MovieTicketBookingSystem_V3.Views.Interface;

namespace MovieTicketBookingSystem_V3.Views.Driver
{
    public class ViewDriver
    {
        private IView _view;
        public ViewDriver(IView view)
        {
            _view = view;
        }
        public void RenderDisplayAction()
        {
            _view.RenderDisplayAction();
        }
        public void RenderSelectAction()
        {
            _view.RenderSelectAction();
        }
    }
}
