using MovieTicketBookingSystem_V3.Utils;
using System.Data.SQLite;

namespace MovieTicketBookingSystem_V3.DBQueries
{
    public static class TheatreQueries
    {
        public static Dictionary<int,string> DisplayTheatres()
        {
            /*DBConnectivity.OpenConnection();
            Dictionary<int,string> TheatresFromDB = new Dictionary<int,string>(); 
            SQLiteCommand command = new($"SELECT DISTINCT t.theatre_id, t.theatre_name FROM Theatre t JOIN Show s ON t.theatre_id = s.theatre_id AND s.movie_id={LocalDataStorage.movie.MovieId};", DBConnectivity.myConnection);
            SQLiteDataReader commandReader = command.ExecuteReader();
            var i = 1;

            while (commandReader.Read())
            {
                LocalDataStorage.TheatreList.Add(i, commandReader.GetInt32(0));
                TheatresFromDB.Add(i, Convert.ToString(commandReader["theatre_name"]));
                i++;
            }
            DBConnectivity.CloseConnection();
            return TheatresFromDB;*/

            Dictionary<int, string> TheatresFromDB = new Dictionary<int, string>();
            var i = 1;
            using (SQLiteConnection connection = new SQLiteConnection(DBConnectivity.myDBConnection))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"SELECT DISTINCT t.theatre_id, t.theatre_name FROM Theatre t JOIN Show s ON t.theatre_id = s.theatre_id AND s.movie_id={LocalDataStorage.movie.MovieId};";
                    using (SQLiteDataReader commandReader = command.ExecuteReader())
                    {
                        while (commandReader.Read())
                        {
                            LocalDataStorage.TheatreList.Add(i, commandReader.GetInt32(0));
                            TheatresFromDB.Add(i, Convert.ToString(commandReader["theatre_name"]));
                            i++;
                        }
                    }
                }
            }
            return TheatresFromDB;
        }
        public static void FindTheatreId(int theatreId)
        {
            /*DBConnectivity.OpenConnection();
            SQLiteCommand command = new($"SELECT theatre_id, theatre_name FROM Theatre WHERE theatre_id={theatreId};", DBConnectivity.myConnection);
            SQLiteDataReader commandReader = command.ExecuteReader();
            while (commandReader.Read())
            {
                LocalDataStorage.theatre.TheatreId = commandReader.GetInt32(0);
                LocalDataStorage.theatre.TheatreName = (string)commandReader["theatre_name"];
            }
            DBConnectivity.CloseConnection();*/

            using (SQLiteConnection connection = new SQLiteConnection(DBConnectivity.myDBConnection))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"SELECT theatre_id, theatre_name FROM Theatre WHERE theatre_id={theatreId};";
                    using (SQLiteDataReader commandReader = command.ExecuteReader())
                    {
                        while (commandReader.Read())
                        {
                            LocalDataStorage.theatre.TheatreId = commandReader.GetInt32(0);
                            LocalDataStorage.theatre.TheatreName = (string)commandReader["theatre_name"];
                        }
                    }
                }
            }
        }
    }
}
