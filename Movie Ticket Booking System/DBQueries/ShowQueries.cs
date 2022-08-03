using MovieTicketBookingSystem_V3.Utils;
using System.Data.SQLite;

namespace MovieTicketBookingSystem_V3.DBQueries
{
    public static class ShowQueries
    {
        public static Dictionary<int, string> DisplayShowDates()
        {
            /*DBConnectivity.OpenConnection();
            Dictionary<int, string> ShowDatesFromDB = new Dictionary<int, string>();
            SQLiteCommand command = new($"SELECT DISTINCT show_id,show_date FROM Show WHERE movie_id = {LocalDataStorage.movie.MovieId} AND theatre_id = {LocalDataStorage.theatre.TheatreId};", DBConnectivity.myConnection);
            SQLiteDataReader commandReader = command.ExecuteReader();
            var i = 1;
            var DateList = new List<string>();

            while (commandReader.Read())
            {
                if (!DateList.Contains(commandReader["show_date"]))
                {
                    LocalDataStorage.ShowDateList.Add(i, commandReader.GetInt32(0));
                    DateList.Add(Convert.ToString(commandReader["show_date"]));
                    ShowDatesFromDB.Add(i, Convert.ToString(commandReader["show_date"]));
                    i++;
                }
            }
            DBConnectivity.CloseConnection();
            return ShowDatesFromDB;*/

            Dictionary<int, string> ShowDatesFromDB = new Dictionary<int, string>();
            var DateList = new List<string>();
            var i = 1;
            using (SQLiteConnection connection = new SQLiteConnection(DBConnectivity.myDBConnection))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"SELECT DISTINCT show_id,show_date FROM Show WHERE movie_id = {LocalDataStorage.movie.MovieId} AND theatre_id = {LocalDataStorage.theatre.TheatreId};";
                    using (SQLiteDataReader commandReader = command.ExecuteReader())
                    {
                        while (commandReader.Read())
                        {
                            if (!DateList.Contains(commandReader["show_date"]))
                            {
                                LocalDataStorage.ShowDateList.Add(i, commandReader.GetInt32(0));
                                DateList.Add(Convert.ToString(commandReader["show_date"]));
                                ShowDatesFromDB.Add(i, Convert.ToString(commandReader["show_date"]));
                                i++;
                            }
                        }
                    }
                }
            }
            return ShowDatesFromDB;
        }
        public static void FindShowDate(int showDate)
        {
            /*DBConnectivity.OpenConnection();
            SQLiteCommand command = new($"SELECT DISTINCT show_date FROM Show WHERE movie_id = {LocalDataStorage.movie.MovieId} AND theatre_id = {LocalDataStorage.theatre.TheatreId} AND show_id='{LocalDataStorage.ShowDateList[showDate]}';", DBConnectivity.myConnection);
            SQLiteDataReader commandReader = command.ExecuteReader();
            while (commandReader.Read())
            {
                LocalDataStorage.show.ShowDate = DateOnly.Parse((string)commandReader["show_date"]);
            }
            DBConnectivity.CloseConnection();*/

            using (SQLiteConnection connection = new SQLiteConnection(DBConnectivity.myDBConnection))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"SELECT DISTINCT show_date FROM Show WHERE movie_id = {LocalDataStorage.movie.MovieId} AND theatre_id = {LocalDataStorage.theatre.TheatreId} AND show_id='{LocalDataStorage.ShowDateList[showDate]}';";
                    using (SQLiteDataReader commandReader = command.ExecuteReader())
                    {
                        while (commandReader.Read())
                        {
                            LocalDataStorage.show.ShowDate = DateOnly.Parse((string)commandReader["show_date"]);
                        }
                    }
                }
            }

        }
        public static Dictionary<int, string> DisplayShowTimes()
        {
            /*DBConnectivity.OpenConnection();
            Dictionary<int, string> ShowTimesFromDB = new Dictionary<int, string>();
            SQLiteCommand command = new($"SELECT DISTINCT show_id,show_time FROM Show WHERE movie_id = {LocalDataStorage.movie.MovieId} AND theatre_id = {LocalDataStorage.theatre.TheatreId} AND show_Date='{Convert.ToString(LocalDataStorage.show.ShowDate)}';", DBConnectivity.myConnection);
            SQLiteDataReader commandReader = command.ExecuteReader();
            var i = 1;
            while (commandReader.Read())
            {
                LocalDataStorage.ShowTimeList.Add(i, commandReader.GetInt32(0));
                ShowTimesFromDB.Add(i, Convert.ToString(commandReader["show_time"]));
                i++;
            }
            DBConnectivity.CloseConnection();
            return ShowTimesFromDB;*/

            Dictionary<int, string> ShowTimesFromDB = new Dictionary<int, string>();
            var i = 1;
            using (SQLiteConnection connection = new SQLiteConnection(DBConnectivity.myDBConnection))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"SELECT DISTINCT show_id,show_time FROM Show WHERE movie_id = {LocalDataStorage.movie.MovieId} AND theatre_id = {LocalDataStorage.theatre.TheatreId} AND show_Date='{Convert.ToString(LocalDataStorage.show.ShowDate)}';";
                    using (SQLiteDataReader commandReader = command.ExecuteReader())
                    {
                        while (commandReader.Read())
                        {
                            LocalDataStorage.ShowTimeList.Add(i, commandReader.GetInt32(0));
                            ShowTimesFromDB.Add(i, Convert.ToString(commandReader["show_time"]));
                            i++;
                        }
                    }
                }
            }
            return ShowTimesFromDB;
        }
        public static void FindShowTime(int showTime)
        {
            /*DBConnectivity.OpenConnection();
            SQLiteCommand command = new($"SELECT DISTINCT show_time FROM Show WHERE movie_id = {LocalDataStorage.movie.MovieId} AND theatre_id = {LocalDataStorage.theatre.TheatreId} AND show_date='{Convert.ToString(LocalDataStorage.show.ShowDate)}' AND show_id='{LocalDataStorage.ShowTimeList[showTime]}';", DBConnectivity.myConnection);
            SQLiteDataReader commandReader = command.ExecuteReader();
            while (commandReader.Read())
            {
                LocalDataStorage.show.ShowTime = TimeOnly.Parse((string)commandReader["show_time"]);
            }
            DBConnectivity.CloseConnection();*/

            using (SQLiteConnection connection = new SQLiteConnection(DBConnectivity.myDBConnection))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"SELECT DISTINCT show_time FROM Show WHERE movie_id = {LocalDataStorage.movie.MovieId} AND theatre_id = {LocalDataStorage.theatre.TheatreId} AND show_date='{Convert.ToString(LocalDataStorage.show.ShowDate)}' AND show_id='{LocalDataStorage.ShowTimeList[showTime]}';";
                    using (SQLiteDataReader commandReader = command.ExecuteReader())
                    {
                        while (commandReader.Read())
                        {
                            LocalDataStorage.show.ShowTime = TimeOnly.Parse((string)commandReader["show_time"]);
                        }
                    }
                }
            }
        }
        public static List<int> DisplaySeats()
        {
            /*DBConnectivity.OpenConnection();
            List<int> SeatListFromDB = new List<int>(); 
            SQLiteCommand command = new($"SELECT seat_number FROM Ticket WHERE show_id = {LocalDataStorage.show.ShowId}", DBConnectivity.myConnection);
            SQLiteDataReader commandReader = command.ExecuteReader();
            while (commandReader.Read())
            {
                LocalDataStorage.SeatList.Add(commandReader.GetInt32(0));
                SeatListFromDB.Add(Convert.ToInt32(commandReader.GetInt32(0)));
            }
            DBConnectivity.CloseConnection();
            return SeatListFromDB;*/

            List<int> SeatListFromDB = new List<int>();
            using (SQLiteConnection connection = new SQLiteConnection(DBConnectivity.myDBConnection))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"SELECT seat_number FROM Ticket WHERE show_id = { LocalDataStorage.show.ShowId };";
                    using (SQLiteDataReader commandReader = command.ExecuteReader())
                    {
                        while (commandReader.Read())
                        {
                            LocalDataStorage.SeatList.Add(commandReader.GetInt32(0));
                            SeatListFromDB.Add(Convert.ToInt32(commandReader.GetInt32(0)));
                        }
                    }
                }
            }
            return SeatListFromDB;
        }
    }
}
