using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CanteenAIS_DB
{
    public class DbConnection
    {
        public readonly static string dbName = "canteen";
        private readonly static string connectionString = $"SERVER=localhost;DATABASE={dbName};UID=admin;PASSWORD=1234567890;";
        private readonly MySqlConnection connection;

        private static DbConnection instance;

        private DbConnection()
        {
            connection = new MySqlConnection(connectionString);
        }

        public static DbConnection GetInstance()
        {
            if (instance == null)
                instance = new DbConnection();
            return instance;
        }

        public DataTable ExecQuery(MySqlCommand command, ref string exception)
        {
            if (connection == null)
            {
                exception = "Подключение к базе данных не установлено!";
                return null;
            }
            connection.Open();
            //MySqlCommand command = new MySqlCommand(query, connection);
            command.Connection = connection;

            MySqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                exception = ex.Message;
                connection.Close();
                return null;
            }

            exception = string.Empty;
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            connection.Close();
            return dataTable;
        }

        public DataTable ExecQuery(string query, ref string exception)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                return ExecQuery(command, ref exception);
            }
            catch (Exception ex)
            {
                exception = ex.Message;
                connection.Close();
                return null;
            }
        }
    }
}
