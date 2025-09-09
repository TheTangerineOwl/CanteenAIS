using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace CanteenAIS_DB
{
    public abstract class BasicEntityCRU<T> where T : Entity
    {
        public string exception = string.Empty;

        protected abstract string TableName { get; }

        protected virtual string QueryCreate => $"INSERT INTO {TableName} (`Id`, `Name`) VALUES (@entityId, @entityName);";

        protected virtual string QueryRead => $"SELECT * FROM {TableName} ORDER BY `Id`;";

        protected virtual string QueryUpdate => $"UPDATE {TableName} SET `Name`=@entityName WHERE `Id`=@entityId;";

        protected abstract MySqlParameterCollection FillParameters(T entity, MySqlCommand command);
        protected abstract IList<TEntity> AddFromRows<TEntity>(DataTable table) where TEntity : T, new();

        public virtual void Create(T entity)
        {
            MySqlCommand command = new MySqlCommand(QueryCreate);
            FillParameters(entity, command);
            DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
        }

        public virtual IList<U> Read<U>() where U : T, new()
        {
            DataTable dataTable = DbConnection.GetInstance().ExecQuery(QueryRead, ref exception);
            return AddFromRows<U>(dataTable);
        }

        public virtual void Update(T entity)
        {
            MySqlCommand command = new MySqlCommand(QueryUpdate);
            FillParameters(entity, command);
            DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
        }

        public abstract U ParseEntity<U>(DataRow row) where U : T, new();
    }

    public abstract class BasicSimpleCRUD<T> : BasicEntityCRU<T> where T : SimpleEntity
    {
        protected virtual string QueryDelete => $"DELETE FROM {TableName} WHERE Id={IdQueryParam}";

        protected virtual string IdQueryParam => "@entityId";

        public virtual void Delete(uint id)
        {
            MySqlCommand command = new MySqlCommand(QueryDelete);
            command.Parameters.AddWithValue(IdQueryParam, id);
            DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
        }

        public virtual string ReadIdQuery =>
            QueryRead.TrimEnd(';') +
            $"WHERE `Id`={IdQueryParam};";

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

    public abstract class BasicDoubleCRUD<T> : BasicEntityCRU<T> where T : DoubleEntity
    {
        protected abstract string QueryDelete { get; }

        public abstract void Delete(uint firstId, uint secondId);

        public virtual string ReadPKQuery =>
            QueryRead.TrimEnd(';') +
            $"WHERE `{FirstIdName}`={IdQueryParam1} AND" +
            $"`{SecondIdName}`={IdQueryParam2};";
        public virtual string ReadId1Query =>
            QueryRead.TrimEnd(';') +
            $"WHERE `{FirstIdName}`={IdQueryParam1};";
        public virtual string ReadId2Query =>
            QueryRead.TrimEnd(';') +
            $"WHERE `{SecondIdName}`={IdQueryParam2};";

        protected virtual string IdQueryParam1 => $"@entity{FirstIdName}";
        protected virtual string IdQueryParam2 => $"@entity{SecondIdName}";

        protected abstract string FirstIdName { get; }
        protected abstract string SecondIdName { get; }

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
