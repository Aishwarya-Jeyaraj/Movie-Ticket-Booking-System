using MovieTicketBookingSystem_V3.Utils;
using System.Data.SQLite;

namespace MovieTicketBookingSystem_V3.DBQueries
{
    public static class TicketQueries
    {
        public static void BookTicket(int seat)
        {
            /*DBConnectivity.OpenConnection();
            SQLiteCommand command = new($"INSERT INTO Ticket (user_id,show_id, seat_number) VALUES ({LocalDataStorage.user.UserId},{LocalDataStorage.show.ShowId},{seat})", DBConnectivity.myConnection);
            command.ExecuteNonQuery();
            DBConnectivity.CloseConnection();*/
            using (SQLiteConnection connection = new SQLiteConnection(DBConnectivity.myDBConnection))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"INSERT INTO Ticket (user_id,show_id, seat_number) VALUES ({LocalDataStorage.user.UserId},{LocalDataStorage.show.ShowId},{seat});";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
