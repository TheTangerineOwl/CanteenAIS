using CanteenAIS_DB;
using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_Models.Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CanteenAIS_Models
{   
    public abstract class TableModel<TEntity>
        where TEntity : Entity
    {
        public abstract string TableName { get; }
        protected IDictionary<DataRow, TEntity> DataValues;

        private DataTable _table;
        public DataTable Table
        {
            get => _table;
            set => _table = value;
        }

        protected DataRow Selected { get; set; }

        private readonly BasicEntityCRU<TEntity> TableContext;

        protected TableModel(BasicEntityCRU<TEntity> contextInstance)
        {
            TableContext = contextInstance;
            _table = new DataTable();
        }

        protected virtual void FillDataValues<TEntityType>(DataTable table, IList<TEntityType> values) where TEntityType : TEntity
        {
            Table = table;
            DataValues = new Dictionary<DataRow, TEntity>();
            for (int i = 0; i < values.Count; i++)
                DataValues.Add(table.Rows[i], values[i]);
        }

        public virtual IList<TEntityType> FetchValues<TEntityType>() where TEntityType : TEntity, new()
        {
            return TableContext.Read<TEntityType>();//.ToList();
        }

        public virtual DataTable GetTable<TEntityType>() where TEntityType : TEntity, new()
        {
            List<TEntityType> values = FetchValues<TEntityType>().ToList();
            DataTable table = DataTableConverter.ToDataTable(values);
            FillDataValues(table, values);
            return table;
        }

        public virtual DataTable FetchAndFilter<TEntityType>(Predicate<TEntityType> predicate) where TEntityType : TEntity, new()
        {
            List<TEntityType> allValues = FetchValues<TEntityType>().ToList();
            List<TEntityType> result = allValues.Where(e => predicate(e)).ToList();
            DataTable table = DataTableConverter.ToDataTable(result);
            FillDataValues(table, result);
            return table;
        }

        public abstract int CompareEntities(TEntity first, TEntity second);
        public abstract bool ContainsString(TEntity entity, string sample);

        public virtual DataTable GetSearchResult<TEntityType>(string search) where TEntityType : TEntity, new()
        {
            return FetchAndFilter<TEntityType>(v => ContainsString(v, search));
        }

        public virtual DataTable GetFiltered<TEntityType>(TEntityType filter) where TEntityType : TEntity, new()
        {
            if (filter == null)
                return GetTable<TEntityType>();
            return FetchAndFilter<TEntityType>(v => CompareEntities(v, filter) == 0);
        }

        public virtual UserPermEntity GetPerms<TUserPerm>(uint elementId)
            where TUserPerm : UserPermEntity, new()
        {
            return DBContext.GetInstance().GetCurrentPerm<UserPerm>(elementId);
        }

        public virtual TResult GetEntity<TResult>(DataRow row)
            where TResult : TEntity, new()
        {
            return DataValues[row] as TResult;
        }

        public abstract void Add<TResultType>(TEntity info) where TResultType : TEntity, new();
        public abstract void Update<TResultType>(DataRow row, TEntity info) where TResultType : TEntity, new();
        public abstract void DeleteRow(DataRow row);
    }

    public abstract class SimpleModel<TEntity> : TableModel<TEntity>
        where TEntity : SimpleEntity
    {
        protected BasicSimpleCRUD<TEntity> TableContext;

        public SimpleModel(BasicSimpleCRUD<TEntity> contextInstance) : base(contextInstance)
        {
            TableContext = contextInstance;
        }

        public uint GetId(DataRow row)
        {
            return DataValues[row].Id;
        }

        public DataRow GetRowById(uint id)
        {
            return DataValues.First(pair => pair.Value.Id == id).Key;
        }

        public override void DeleteRow(DataRow row)
        {
            TableContext.Delete(GetId(row));
        }

        public override int CompareEntities(TEntity first, TEntity second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            return first.Id.CompareTo(second.Id);
        }
    }

    public abstract class DoubleModel<TEntity> : TableModel<TEntity>
        where TEntity : DoubleEntity
    {
        protected BasicDoubleCRUD<TEntity> TableContext;

        public DoubleModel(BasicDoubleCRUD<TEntity> contextInstance) : base(contextInstance)
        {
            TableContext = contextInstance;
        }

        public (uint, uint) GetPK(DataRow row)
        {
            TEntity entity = DataValues[row];
            return (entity.FirstId, entity.SecondId);
        }

        public DataRow GetRowByPK(uint firstId, uint secondId)
        {
            return DataValues.First(pair =>
                pair.Value.FirstId == firstId &&
                pair.Value.SecondId == secondId
            ).Key;
        }

        public override void DeleteRow(DataRow row)
        {
            (uint firstId, uint secondId) = GetPK(row);
            TableContext.Delete(firstId, secondId);
        }

        public override int CompareEntities(TEntity first, TEntity second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.FirstId.CompareTo(second.FirstId);
            if (compared != 0)
                first.SecondId.CompareTo(second.SecondId);
            return 0;
        }
    }
}
