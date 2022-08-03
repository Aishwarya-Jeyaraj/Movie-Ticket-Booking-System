using MovieTicketBookingSystem_V3.Utils;
using System.Data.SQLite;

namespace MovieTicketBookingSystem_V3.DBQueries
{
    public static class UserQueries
    {
        public static void CreateNewUser(string userName)
        {
            /*DBConnectivity.OpenConnection();
            SQLiteCommand command = new($"INSERT INTO UserInfo(user_name) VALUES('{userName}');", DBConnectivity.myConnection);
            command.ExecuteNonQuery();

            command = new($"SELECT user_id,user_name FROM UserInfo WHERE user_name='{userName}';", DBConnectivity.myConnection);
            SQLiteDataReader commandReader = command.ExecuteReader();
            while (commandReader.Read())
            {
                LocalDataStorage.user.UserId = commandReader.GetInt32(0);
                LocalDataStorage.user.UserName = (string)commandReader["user_name"];
            }
            DBConnectivity.CloseConnection();*/

            using (SQLiteConnection sqConnection = new SQLiteConnection(DBConnectivity.myDBConnection))
            {
                sqConnection.Open();
                using (SQLiteTransaction myTrans = sqConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    using (SQLiteCommand sqCommand = sqConnection.CreateCommand())
                    {
                        sqCommand.CommandText = $"INSERT INTO UserInfo(user_name) VALUES('{userName}');";
                        sqCommand.ExecuteNonQuery();
                        sqCommand.CommandText = $"SELECT user_id,user_name FROM UserInfo WHERE user_name='{userName}';";
                        using (SQLiteDataReader commandReader = sqCommand.ExecuteReader())
                        {
                            while (commandReader.Read())
                            {
                                LocalDataStorage.user.UserId = commandReader.GetInt32(0);
                                LocalDataStorage.user.UserName = (string)commandReader["user_name"];
                            }
                        }
                        myTrans.Commit();
                    }
                }
            }

        }
    }
}
