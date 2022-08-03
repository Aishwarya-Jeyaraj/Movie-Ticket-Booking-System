using MovieTicketBookingSystem_V3.Controllers.Driver;

namespace MovieTicketBookingSystem_V3.Views.Interface
{
    public interface IView
    {
        protected static ControllerDriver controllerDriver;
        public void RenderDisplayAction();
        public void RenderSelectAction();
    }
}
