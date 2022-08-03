using MovieTicketBookingSystem_V3.Controllers;
using MovieTicketBookingSystem_V3.Controllers.Driver;
using MovieTicketBookingSystem_V3.Controllers.Interface;
using MovieTicketBookingSystem_V3.Utils;
using MovieTicketBookingSystem_V3.Views.Interface;

namespace MovieTicketBookingSystem_V3.Views
{
    public class UserView
    {
        readonly UserController userController = new();
        public void RenderSelectAction()
        {
            OutputProvider.PrintMessageToGetUsername();
            var userName = InputReader.GetInputForUsername();
            userController.CreateUser(userName);
        }
    }
}
