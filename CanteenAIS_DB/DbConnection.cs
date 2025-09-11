using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CanteenAIS_DB
{
    /// <summary>
    /// Менеджер подключения к MySQL БД.
    /// </summary>
    public class DbConnection
    {
        /// <summary>
        /// Имя базы данных.
        /// </summary>
        public readonly static string dbName = "canteen";

        /// <summary>
        /// Строка подключения.
        /// </summary>
        private readonly static string connectionString = $"SERVER=localhost;DATABASE={dbName};UID=admin;PASSWORD=1234567890;";

        /// <summary>
        /// Подключение к базе данных.
        /// </summary>
        private readonly MySqlConnection connection;

        /// <summary>
        /// Инициализированный менеджер.
        /// </summary>
        private static DbConnection instance;

        /// <summary>
        /// Инициализация менеджера подключения.
        /// </summary>
        private DbConnection()
        {
            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Получить экземпляр менеджера подключения к БД.
        /// </summary>
        /// <returns>Экземпляр менеджера подключения.</returns>
        public static DbConnection GetInstance()
        {
            if (instance == null)
                instance = new DbConnection();
            return instance;
        }

        /// <summary>
        /// Пытается выполнить MySql-команду <paramref name="command"/>,
        /// в случае возникновения ошибки записывает сообщение с информацией о ней в <paramref name="exception"/>.
        /// </summary>
        /// <param name="command">MySql-команда с заполненными запросом и параметрами.</param>
        /// <param name="exception">Хранилище для сообщения об ошибке.</param>
        /// <returns>Результат выполнения запроса.</returns>
        public DataTable ExecMySqlQuery(MySqlCommand command, ref string exception)
        {
            if (connection == null)
            {
                exception = "Подключение к базе данных не установлено!";
                return null;
            }
            connection.Open();
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

        /// <summary>
        /// Пытается выполнить SQL-запрос, заданный <paramref name="query"/>.
        /// В случае возникновения ошибки записывает сообщение с информацией о ней в <paramref name="exception"/>.
        /// </summary>
        /// <param name="query">SQL-запрос.</param>
        /// <param name="exception">Хранилище для сообщения об ошибке.</param>
        /// <returns>Результат выполнения запроса.</returns>
        public DataTable ExecQuery(string query, ref string exception)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                return ExecMySqlQuery(command, ref exception);
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
