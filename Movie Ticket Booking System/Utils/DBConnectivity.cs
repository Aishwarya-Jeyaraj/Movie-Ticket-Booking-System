using System.Data.SQLite;

namespace MovieTicketBookingSystem_V3.Utils
{
    public static class DBConnectivity
    {
        public static SQLiteConnection myConnection;
        public static string myDBConnection = "Data Source=DataBase.sqlite3";
        static DBConnectivity()
        {
            myConnection = new SQLiteConnection("Data Source=DataBase.sqlite3");
            if (!File.Exists("./DataBase.sqlite3"))
            {
                SQLiteConnection.CreateFile("DataBase.sqlite3");
            }
        }

        public static void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public static void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }

        public static void ResetDBData()
        {
            /*using SQLiteConnection connection = myConnection;
            OpenConnection();
            using SQLiteCommand command = new(connection);
            command.CommandText = "BEGIN TRANSACTION";
            command.ExecuteNonQuery();
            command.CommandText = "DELETE FROM UserInfo;";
            command.ExecuteNonQuery();
            command.CommandText = "DELETE FROM Ticket;";
            command.ExecuteNonQuery();
            command.CommandText = "UPDATE sqlite_sequence SET SEQ=99 WHERE NAME='Ticket';";
            command.ExecuteNonQuery();
            command.CommandText = "UPDATE sqlite_sequence SET SEQ=0 WHERE NAME='UserInfo';";
            command.ExecuteNonQuery();
            command.CommandText = "COMMIT";
            command.ExecuteNonQuery();*/

            using (SQLiteConnection sqConnection = new SQLiteConnection(myDBConnection))
            {
                sqConnection.Open();
                using (SQLiteTransaction myTrans = sqConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    using(SQLiteCommand sqCommand = sqConnection.CreateCommand())
                    {
                        sqCommand.CommandText = "DELETE FROM UserInfo;";
                        sqCommand.ExecuteNonQuery();
                        sqCommand.CommandText = "DELETE FROM Ticket;";
                        sqCommand.ExecuteNonQuery();
                        sqCommand.CommandText = "UPDATE sqlite_sequence SET SEQ=99 WHERE NAME='Ticket';";
                        sqCommand.ExecuteNonQuery();
                        sqCommand.CommandText = "UPDATE sqlite_sequence SET SEQ=0 WHERE NAME='UserInfo';";
                        sqCommand.ExecuteNonQuery();
                        myTrans.Commit();
                    }
                }
            }
        }
    }
}
