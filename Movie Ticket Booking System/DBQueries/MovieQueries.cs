using MovieTicketBookingSystem_V3.Utils;
using System.Data.SQLite;

namespace MovieTicketBookingSystem_V3.DBQueries
{
    public static class MovieQueries
    {
        public static Dictionary<int,string> DisplayMovies()
        {
            /*DBConnectivity.OpenConnection();
            SQLiteCommand command = new($"SELECT movie_id,movie_name FROM Movie;", DBConnectivity.myConnection);
            SQLiteDataReader commandReader = command.ExecuteReader();
            Dictionary<int,string> MoviesFromDB = new();
            while (commandReader.Read())
            {
                MoviesFromDB.Add(Convert.ToInt32(commandReader["movie_id"]), Convert.ToString(commandReader["movie_name"]));
            }
            DBConnectivity.CloseConnection();
            return MoviesFromDB;*/
            Dictionary<int, string> MoviesFromDB = new();

            using (SQLiteConnection connection = new SQLiteConnection(DBConnectivity.myDBConnection))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"SELECT movie_id,movie_name FROM Movie;";
                    using (SQLiteDataReader commandReader = command.ExecuteReader())
                    {
                        while (commandReader.Read())
                        {
                            MoviesFromDB.Add(Convert.ToInt32(commandReader["movie_id"]), Convert.ToString(commandReader["movie_name"]));
                        }
                    }
                }
            }
            return MoviesFromDB;
        }
        public static void FindMovieId(int movieId)
        {
            /*DBConnectivity.OpenConnection();
            bool movieFound = false;
            SQLiteCommand command = new($"SELECT movie_id,movie_name FROM Movie WHERE movie_id={movieId};", DBConnectivity.myConnection);
            SQLiteDataReader commandReader = command.ExecuteReader();
            while (commandReader.Read())
            {
                LocalDataStorage.movie.MovieId = commandReader.GetInt32(0);
                LocalDataStorage.movie.MovieName = (string)commandReader["movie_name"];
                movieFound = true;
            }
            DBConnectivity.CloseConnection();
            if (!movieFound)
            {
                LocalDataStorage.movie.MovieId = 0;
            }*/

            bool movieFound = false;
            using (SQLiteConnection connection = new SQLiteConnection(DBConnectivity.myDBConnection))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"SELECT movie_id,movie_name FROM Movie WHERE movie_id={movieId};";
                    using (SQLiteDataReader commandReader = command.ExecuteReader())
                    {
                        while (commandReader.Read())
                        {
                            LocalDataStorage.movie.MovieId = commandReader.GetInt32(0);
                            LocalDataStorage.movie.MovieName = (string)commandReader["movie_name"];
                            movieFound = true;
                        }
                    }
                }
            }
            if (!movieFound)
            {
                LocalDataStorage.movie.MovieId = 0;
            }
        }
    }
}
