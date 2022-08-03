namespace MovieTicketBookingSystem_V3.Controllers.Interface
{
    public interface IController
    {
        public Dictionary<int,string> ExecuteDisplayAction();
        public void ExecuteSelectAction(int i);

    }
}
