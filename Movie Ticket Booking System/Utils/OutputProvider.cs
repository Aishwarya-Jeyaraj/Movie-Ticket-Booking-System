namespace MovieTicketBookingSystem_V3.Utils
{
    public static class OutputProvider
    {
        public static void PrintWelcomeMessage()
        {
            PrintBorder();
            Console.WriteLine("     --- Welcome To BookYourShow ----");
            PrintBorder();
        }
        public static void PrintMessageToGetUsername()
        {
            Console.WriteLine("\nPlease Enter Your Name:");
        }
        public static void PrintMessageForInvalidUserName()
        {
            Console.WriteLine("\n---Please Enter a valid User Name. Username should contain only alphabets and should atleast be of length 3---");
        }
        public static void PrintMessageToDisplayMovies()
        {
            Console.WriteLine("\nPlease select a Movie:\n");
        }
        public static void PrintMessageToGetMovieInput()
        {
            Console.WriteLine("\nEnter your choice:");
        }
        public static void PrintMessageForInvalidInput()
        {
            Console.WriteLine("\n---Please Enter a valid input---");
        }
        public static void PrintMessageToDisplayTheatres()
        {
            Console.WriteLine("\nPlease select a Theatre:\n");
        }
        public static void PrintMessageToGetTheatreInput()
        {
            Console.WriteLine("\nEnter your Theatre Choice:");
        }
        public static void PrintMessageToDisplayShowDates()
        {
            Console.WriteLine("\nPlease select a Date:\n");
        }
        public static void PrintMessageToGetShowDateInput()
        {
            Console.WriteLine("\nEnter your Date Choice:");
        }
        public static void PrintMessageToDisplayShowTimings()
        {
            Console.WriteLine("\nPlease select a Show Time:\n");
        }
        public static void PrintMessageToGetShowTimeInput()
        {
            Console.WriteLine("\nEnter your Show Choice:");
        }
        public static void PrintMessageToDisplaySeats()
        {
            Console.WriteLine($"\nPlease Select your seat(s) for {LocalDataStorage.show.ShowTime} {LocalDataStorage.show.ShowTime.ToString("tt")} show in {LocalDataStorage.theatre.TheatreName} for {LocalDataStorage.movie.MovieName} movie:");
        }
        public static void PrintMessageToGetSeatInput()
        {
            Console.WriteLine("\nEnter your Seat Selection:");
        }
        public static void PrintMessageForSeatsBooked()
        {
            Console.Write($"\n---Congrats! Your ticket(s) ");
            for (int i = 0; i < LocalDataStorage.SeatsBooked.Count; i++)
            {
                Console.Write($"{LocalDataStorage.SeatsBooked[i]} ");
            }
            Console.Write($"has been booked in {LocalDataStorage.theatre.TheatreName}!----\n");
        }
        public static void PrintMessageForInvalidSeatInput(List<string> seats)
        {
            Console.Write($"\nInvalid seat Selection - ");
            for(int i=0;i< seats.Count; i++)
            {
                Console.Write($"{seats[i]} ");
            }
            Console.WriteLine();
        }
        public static void PrintMessageForFailedTicketBooking()
        {
            Console.Write($"\n---Sorry! Seat(s) ");
            for (int i = 0; i < LocalDataStorage.SeatsFailedToBook.Count; i++)
            {
                Console.Write($"{LocalDataStorage.SeatsFailedToBook[i]} ");
            }
            Console.Write("cannot be booked! Seat(s) Unavailable!----\n");
        }
        public static void PrintMessageForNoSeatsBooked()
        {
            Console.WriteLine("Please select a Seat!!");
        }
        public static void PrintTicket()
        {
            OutputProvider.PrintTicketHeader();
            Console.WriteLine("              ---Show Details---\n");
            Console.WriteLine($"        Movie: {LocalDataStorage.movie.MovieName}");
            Console.WriteLine($"        Theatre: {LocalDataStorage.theatre.TheatreName}");
            Console.WriteLine($"        Date: {LocalDataStorage.show.ShowDate}");
            Console.WriteLine($"        Show Time: {LocalDataStorage.show.ShowTime} {(LocalDataStorage.show.ShowTime).ToString("tt")}");
            OutputProvider.PrintBorder();
            Console.WriteLine("              ---Booking Details---\n");
            Console.WriteLine($"        Name: {LocalDataStorage.user.UserName}");
            Console.Write("        Seat Number(s): ");
            for (int i = 0; i < LocalDataStorage.ticket.SeatNumber.Count; i++)
            {
                Console.Write($"{LocalDataStorage.ticket.SeatNumber[i]} ");
            }
            Console.WriteLine("\n");
            OutputProvider.PrintBorder();
        }
        public static void PrintBorder()
        {
            Console.WriteLine("=============================================");
        }
        public static void PrintTicketHeader()
        {
            Console.WriteLine("\n               ---Your Ticket---              ");
            PrintBorder();
            Console.WriteLine("                 BookYourShow                ");
            PrintBorder();
        }
        public static void PrintMessageForContinueBookingTickets()
        {
            Console.WriteLine("\nWant to book another time (Y or N)? ");
        }
        public static void PrintErrorMessageForContinueBookingTickets()
        {
            Console.WriteLine("\n---Please enter a valid input (Y or N)---");
        }
        public static void PrintMessageForProgramExit()
        {
            Console.WriteLine("\n---Program exits---");
        }
    }
}
