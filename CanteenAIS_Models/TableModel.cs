using CanteenAIS_DB;
using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_Models.Statics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CanteenAIS_Models
{   
    public abstract class TableModel<TEntity, TEntityInfo>
        where TEntity : class, IEntity
        where TEntityInfo : Info
    {
        public abstract string TableName { get; }
        protected IDictionary<DataRow, TEntity> DataValues;
        protected DataRow Selected { get; set; }

        protected readonly BasicEntityCRU<TEntity> TableContext;

        protected TableModel(BasicEntityCRU<TEntity> contextInstance)
        {
            TableContext = contextInstance;
        }

        protected virtual void FillDataValues(DataTable table, IList<TEntity> values)
        {
            DataValues = new Dictionary<DataRow, TEntity>();
            for (int i = 0; i < values.Count; i++)
                DataValues.Add(table.Rows[i], values[i]);
        }

        protected virtual IList<TEntity> FetchValues()
        {
            return TableContext.Read().ToList();
        }

        public virtual DataTable GetTable()
        {
            List<TEntity> values = FetchValues().ToList();
            DataTable table = DataTableConverter.ToDataTable(values);
            FillDataValues(table, values);
            return table;
        }

        public virtual DataTable FetchAndFilter(Predicate<TEntity> predicate)
        {
            List<TEntity> allValues = FetchValues().ToList();
            List<TEntity> result = allValues.Where(e => predicate(e)).ToList();
            DataTable table = DataTableConverter.ToDataTable(result);
            FillDataValues(table, result);
            return table;
        }

        public abstract int CompareEntities(TEntity first, TEntity second);
        public abstract bool ContainsString(TEntity entity, string sample);

        public virtual DataTable GetSearchResult(string search)
        {
            return FetchAndFilter(v => ContainsString(v, search));
        }

        public virtual DataTable GetFiltered(TEntity filter)
        {
            return FetchAndFilter(v => CompareEntities(v, filter) == 0);
        }

        public virtual IUserPerm GetPerms(uint elementId)
        {
            IUserPerm perms;
            List<IUserPerm> userPerms = DBContext.GetInstance().UserPerms.Read().ToList();
            IUser currentUser = DBContext.GetInstance().CurrentUser;
            perms = userPerms.Find(up => up.UserId == currentUser.Id && up.ElementId == elementId);
            if (perms.UserId != currentUser.Id)
                perms = new UserPerm(
                    new UserPermInfo
                    {
                        UserId = currentUser.Id,
                        ElementId = elementId
                    }
                );
            return perms;
        }

        public abstract void Add(TEntityInfo info);
        public abstract void Update(DataRow row, TEntityInfo info);
        public abstract void DeleteRow(DataRow row);
    }

    public abstract class SimpleModel<TEntity, TEntityInfo> : TableModel<TEntity, TEntityInfo>
        where TEntity : class, ISimpleEntity
        where TEntityInfo : SimpleInfo
    {
        public SimpleModel(BasicSimpleCRUD<TEntity> contextInstance) : base(contextInstance) { }

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
            ((BasicSimpleCRUD<TEntity>)TableContext).Delete(GetId(row));
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

    public abstract class DoubleModel<TEntity, TEntityInfo> : TableModel<TEntity, TEntityInfo>
        where TEntity : class, IDoubleEntity
        where TEntityInfo : DoubleInfo
    {
        public DoubleModel(BasicDoubleCRUD<TEntity> contextInstance) : base(contextInstance) { }

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
            ((BasicDoubleCRUD<TEntity>)TableContext).Delete(firstId, secondId);
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
