using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenAIS_DB
{
    public class DbConnect
    {
        public readonly static string dbName = "canteen";
        private readonly static string connectionString = $"SERVER=localhost;DATABASE={dbName};UID=admin;PASSWORD=1234567890;";
        private readonly MySqlConnection connection;

        private static DbConnect instance;

        private DbConnect()
        {
            connection = new MySqlConnection(connectionString);
        }

        public static DbConnect GetInstance()
        {
            if (instance == null)
                instance = new DbConnect();
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
