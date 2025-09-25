using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace CanteenAIS_DB
{
    /// <summary>
    /// Базовый класс для взаимодействий с БД для любой сущности.
    /// </summary>
    /// <typeparam name="T">Класс сущности.</typeparam>
    public abstract class BasicEntityCRU<T> where T : Entity
    {
        /// <summary>
        /// Возвращаемое после некорректных операций исключение.
        /// </summary>
        public string exception = string.Empty;

        /// <summary>
        /// Имя таблицы в БД.
        /// </summary>
        protected abstract string TableName { get; }

        /// <summary>
        /// Запрос для создания нового экземпляра сущности в БД.
        /// </summary>
        protected virtual string QueryCreate => $"INSERT INTO {TableName} (`Name`) VALUES (@entityName);";

        /// <summary>
        /// Запрос для чтения всех данных из таблицы в БД.
        /// </summary>
        protected virtual string QueryRead => $"SELECT * FROM {TableName} ORDER BY `Id`;";

        /// <summary>
        /// Запрос для обновления полей с данными о сущности в БД.
        /// </summary>
        protected virtual string QueryUpdate => $"UPDATE {TableName} SET `Name`=@entityName WHERE `Id`=@entityId;";

        /// <summary>
        /// Заполняет параметры в команде <paramref name="command"/> полями сущности <paramref name="entity"/>.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        protected abstract MySqlParameterCollection FillParameters(T entity, MySqlCommand command, bool withId = false);
        /// <summary>
        /// Разбивает <paramref name="table"/> на строки и инициализирует на основе каждой строки 
        /// экземпляр <typeparamref name="TEntity"/>.
        /// </summary>
        /// <typeparam name="TEntity">Тип возвращаемого значения.</typeparam>
        /// <param name="table">Исходная таблица.</param>
        /// <returns>Список прочитанных сущностей.</returns>
        protected abstract IList<TEntity> AddFromRows<TEntity>(DataTable table) where TEntity : T, new();

        /// <summary>
        /// Отправляет в БД запрос для чтения всех данных таблицы для сущности <typeparamref name="T"/> и записывает их в список.
        /// </summary>
        /// <typeparam name="U">Дочерний класс <typeparamref name="T"/>, имеющий конструктор.</typeparam>
        /// <returns>Список значений из таблицы.</returns>
        public virtual IList<U> Read<U>() where U : T, new()
        {
            DataTable dataTable = DbConnection.GetInstance().ExecQuery(QueryRead, ref exception);
            return AddFromRows<U>(dataTable);
        }

        /// <summary>
        /// Отправляет в БД запрос для обновления данных заданной сущности <paramref name="entity"/>.
        /// </summary>
        /// <param name="entity">Новые значения полей.</param>
        public virtual void Update(T entity)
        {
            MySqlCommand command = new MySqlCommand(QueryUpdate);
            FillParameters(entity, command, true);
            DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
        }

        /// <summary>
        /// Преобразует <paramref name="row"/> в объект класса <typeparamref name="U"/>.
        /// </summary>
        /// <typeparam name="U">Дочерний класс <typeparamref name="T"/>, имеющий конструктор.</typeparam>
        /// <param name="row">Строка таблицы для преобразования.</param>
        /// <returns>Преобразованная в объект класса <typeparamref name="U"/> строка.</returns>
        public abstract U ParseEntity<U>(DataRow row) where U : T, new();
    }

    /// <summary>
    /// Базовый класс для взаимодействий с БД для любой сущности с первичным ключом в виде Id.
    /// </summary>
    /// <typeparam name="T">Класс сущности с первичным ключом в виде одного значения.</typeparam>
    public abstract class BasicSimpleCRUD<T> : BasicEntityCRU<T> where T : SimpleEntity
    {
        /// <summary>
        /// Запрос для удаления объекта из БД.
        /// </summary>
        protected virtual string QueryDelete => $"DELETE FROM {TableName} WHERE Id={IdQueryParam}";

        /// <summary>
        /// Имя параметра для первичного ключа.
        /// </summary>
        protected virtual string IdQueryParam => "@entityId";

        public virtual long Create(T entity)
        {
            MySqlCommand command = new MySqlCommand(QueryCreate);
            FillParameters(entity, command);
            DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
            return command.LastInsertedId;
        }

        /// <summary>
        /// Отправляет в БД запрос об удалении объекта с заданным id из таблицы.
        /// </summary>
        /// <param name="id">Первичный ключ объекта.</param>
        public virtual void Delete(uint id)
        {
            MySqlCommand command = new MySqlCommand(QueryDelete);
            command.Parameters.AddWithValue(IdQueryParam, id);
            DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
        }

        /// <summary>
        /// Запрос для чтения конкретного объекта из таблицы в БД.
        /// </summary>
        public virtual string ReadIdQuery =>
            QueryRead.TrimEnd(';') +
            $"WHERE `Id`={IdQueryParam};";

        /// <summary>
        /// Читает из таблицы в БД только объект с заданным id.
        /// </summary>
        /// <typeparam name="U">Дочерний класс <typeparamref name="T"/>, тип возвращаемого значения.</typeparam>
        /// <param name="id">Первичный ключ объекта.</param>
        /// <returns>Прочитанный объект.</returns>
        public virtual U ReadId<U>(uint id) where U : T, new()
        {
            MySqlCommand command = new MySqlCommand(ReadIdQuery);
            command.Parameters.AddWithValue(IdQueryParam, id);
            DataTable dataTable = DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
            if (dataTable.Rows.Count == 0)
                return null;
            return ParseEntity<U>(dataTable.Rows[0]);
        }
    }

    /// <summary>
    /// Базовый класс для взаимодействий с БД для любой сущности с первичным ключом в виде пары значений.
    /// </summary>
    /// <typeparam name="T">Класс сущности с первичным ключом в виде пары значений.</typeparam>
    public abstract class BasicDoubleCRUD<T> : BasicEntityCRU<T> where T : DoubleEntity
    {
        /// <summary>
        /// Запрос для удаления объекта из БД.
        /// </summary>
        protected abstract string QueryDelete { get; }

        public virtual void Create(T entity)
        {
            MySqlCommand command = new MySqlCommand(QueryCreate);
            FillParameters(entity, command);
            DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
        }

        /// <summary>
        /// Отправляет в БД запрос об удалении объекта с заданным PK из таблицы.
        /// </summary>
        /// <param name="firstId">Первое значение из PK-пары.</param>
        /// <param name="secondId">Второе значение из PK-пары.</param>
        public abstract void Delete(uint firstId, uint secondId);

        /// <summary>
        /// Запрос для чтения из таблицы в БД сущности с заданным PK.
        /// </summary>
        public virtual string ReadPKQuery =>
            QueryRead.TrimEnd(';') +
            $"WHERE `{FirstIdName}`={IdQueryParam1} AND" +
            $"`{SecondIdName}`={IdQueryParam2};";
        /// <summary>
        /// Запрос для чтения из таблицы в БД сущности с первым Id, равным заданному.
        /// </summary>
        public virtual string ReadId1Query =>
            QueryRead.TrimEnd(';') +
            $"WHERE `{FirstIdName}`={IdQueryParam1};";
        /// <summary>
        /// Запрос для чтения из таблицы в БД сущности со вторым Id, равным заданному.
        /// </summary>
        public virtual string ReadId2Query =>
            QueryRead.TrimEnd(';') +
            $"WHERE `{SecondIdName}`={IdQueryParam2};";

        /// <summary>
        /// Имя параметра для первого ключа.
        /// </summary>
        protected virtual string IdQueryParam1 => $"@entity{FirstIdName}";
        /// <summary>
        /// Имя параметра для второго ключа.
        /// </summary>
        protected virtual string IdQueryParam2 => $"@entity{SecondIdName}";

        /// <summary>
        /// Имя столбца для первого ключа.
        /// </summary>
        protected abstract string FirstIdName { get; }
        /// <summary>
        /// Имя столбца для второго ключа.
        /// </summary>
        protected abstract string SecondIdName { get; }

        /// <summary>
        /// Читает из таблицы в БД данные с заданным РК или с конкретными значениями каждой части ключа.
        /// </summary>
        /// <typeparam name="U">Дочерний класс <typeparamref name="T"/>, тип возвращаемых значений.</typeparam>
        /// <param name="firstId">Первое значение в ключе (null, чтобы игнорировать).</param>
        /// <param name="secondId">Второе значение в ключе (null, чтобы игнорировать).</param>
        /// <returns>Список прочитанных значений.</returns>
        public virtual IList<U> ReadId<U>(uint? firstId = null, uint? secondId = null)
            where U : T, new()
        {
            MySqlCommand command = new MySqlCommand();
            if (firstId is null)
            {
                if (secondId is null)
                    return null;
                command.CommandText = ReadId2Query;
                command.Parameters.AddWithValue(IdQueryParam2, secondId);
            }
            else if (secondId is null)
            {
                command.CommandText = ReadId1Query;
                command.Parameters.AddWithValue(IdQueryParam1, firstId);
            }
            else
            {
                command.CommandText = ReadPKQuery;
                command.Parameters.AddWithValue(IdQueryParam1, firstId);
                command.Parameters.AddWithValue(IdQueryParam2, secondId);
            }
            DataTable dataTable = DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
            IList<U> res = new List<U>();
            foreach (DataRow row in dataTable.Rows)
                res.Add(ParseEntity<U>(row));
            return res;
        }
    }
}
