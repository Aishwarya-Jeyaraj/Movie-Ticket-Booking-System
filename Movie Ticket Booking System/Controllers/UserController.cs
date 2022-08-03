using MovieTicketBookingSystem_V3.DBQueries;
using MovieTicketBookingSystem_V3.Utils;

namespace MovieTicketBookingSystem_V3.Controllers
{
    public class UserController
    {
        public void CreateUser(string userName)
        {
            if (Validator.InvalidUserName(userName))
            {
                OutputProvider.PrintMessageForInvalidUserName();
                var userNameInput = InputReader.GetInputForUsername();
                CreateUser(userNameInput);
            }
            else
            {
                UserQueries.CreateNewUser(userName);
            }
        }
    }
}
