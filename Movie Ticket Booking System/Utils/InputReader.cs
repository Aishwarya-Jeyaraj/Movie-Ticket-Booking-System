namespace MovieTicketBookingSystem_V3.Utils
{
    public static class InputReader
    {
        public static string GetInputForUsername()
        {
            return Console.ReadLine();
        }
        public static int GetInputForUserChoices()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                return 0;
            }
        }
        public static string[] GetInputForSeatChoice()
        {
            return Console.ReadLine().Split(",");
        }
        public static char GetInputToContinueBookingTickets()
        {
            try
            {
                return char.ToUpper(Console.ReadLine()[0]);
            }
            catch (IndexOutOfRangeException)
            {
                return ' ';
            }
        }
    }
}
