using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace CanteenAIS_DB
{
    public abstract class BasicEntityCRU<T> where T : class
    {
        //protected string query = null;
        public string exception = string.Empty;

        protected abstract string TableName { get; }

        protected virtual string QueryCreate
        {
            get
            {
                return $"INSERT INTO {TableName} (`Name`) VALUES (@entityName);";
            }
        }

        protected virtual string QueryRead
        {
            get
            {
                return $"SELECT * FROM {TableName} ORDER BY `Id`;";
            }
        }

        protected virtual string QueryUpdate
        {
            get
            {
                return $"UPDATE {TableName} SET `Name`=@entityName WHERE `Id`=@entityId;";
            }
        }

        protected abstract MySqlParameterCollection FillParameters(T entity, MySqlCommand command, bool withId = true);
        protected abstract IList<T> AddFromRows(DataTable table);

        public virtual void Create(T entity)
        {
            MySqlCommand command = new MySqlCommand(QueryRead);
            FillParameters(entity, command, false);
            DbConnect.GetInstance().ExecQuery(command, ref exception);
        }

        public virtual IList<T> Read()
        {
            DataTable dataTable = DbConnect.GetInstance().ExecQuery(QueryRead, ref exception);
            return AddFromRows(dataTable);
        }

        public virtual void Update(T entity)
        {
            MySqlCommand command = new MySqlCommand(QueryUpdate);
            FillParameters(entity, command);
            DbConnect.GetInstance().ExecQuery(command, ref exception);
        }
    }

    public abstract class BasicSimpleCRUD<T> : BasicEntityCRU<T> where T : class
    {
        protected virtual string QueryDelete
        {
            get
            {
                return $"DELETE FROM {TableName} WHERE Id={IdQueryParam}";
            }
        }

        protected virtual string IdQueryParam
        {
            get
            {
                return "@entityId";
            }
        }

        public virtual void Delete(uint id)
        {
            MySqlCommand command = new MySqlCommand(QueryDelete);
            command.Parameters.AddWithValue(IdQueryParam, id);
            DbConnect.GetInstance().ExecQuery(command, ref exception);
        }
    }

    public abstract class BasicDoubleCRUD<T> : BasicEntityCRU<T> where T : class
    {
        protected abstract string QueryDelete { get; }

        public abstract void Delete(uint firstId, uint secondId);
    }
}
