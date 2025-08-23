using CanteenAIS_DB;
using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_DB.Database.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CanteenAIS_Models
{   
    public abstract class TableModel<TEntity> where TEntity : class
    {
        public abstract string TableName { get; }
        protected IDictionary<DataRow, TEntity> DataValues;
        //protected DataRow Selected { get; set; }

        protected virtual void FillDataValues(DataTable table, IList<TEntity> values)
        {
            DataValues = new Dictionary<DataRow, TEntity>();
            for (int i = 0; i < values.Count; i++)
                DataValues.Add(table.Rows[i], values[i]);
        }

        protected abstract IList<TEntity> FetchValues();

        public virtual DataTable GetTable()
        {
            List<TEntity> values = FetchValues().ToList();
            DataTable table = DataTableConverter.ToDataTable(values);
            /*            table.Columns.Remove(table.Columns[0]);
                        table.Columns.Remove(table.Columns[1]);
                        table.Columns.Remove(table.Columns[2]);*/

            FillDataValues(table, values);
            return table;
        }

        public abstract DataTable GetSearchResult(string search);

        //public abstract DataTable GetFiltered(IAssortmentGroup search)
        //{
        //    List<IAssortmentGroup> allValues = FetchValues().ToList();
        //    List<IAssortmentGroup> result = allValues.Where(v =>
        //       !string.IsNullOrEmpty(search.Name) &&
        //       search.Name.Contains(v.Name.ToString())
        //    ).ToList();
        //    DataTable table = DataTableConverter.ToDataTable(result);
        //    FillDataValues(table, result);
        //    return table;
        //}

        public virtual IUserPerm GetPerms(uint elementId)
        {
            IUserPerm perms;
            List<IUserPerm> userPerms = DBContext.GetInstance().UserPerms.Read().ToList();
            IUser currentUser = DBContext.GetInstance().CurrentUser;
            perms = userPerms.Find(up => up.UserId == currentUser.Id && up.ElementId == elementId);
            if (perms.UserId != currentUser.Id)
                perms = new UserPerm(currentUser.Id, elementId);
            return perms;
        }
    }

    public abstract class SimpleModel<TEntity, TQueryClass> : TableModel<TEntity>
        where TEntity : class
        where TQueryClass : BasicSimpleCRUD<TEntity>
    {
        protected readonly TQueryClass TableContext;

        protected SimpleModel(TQueryClass contextInstance)
        {
            TableContext = contextInstance;
        }

        protected override IList<TEntity> FetchValues()
        {
            return TableContext.Read().ToList();
        }

        
    }
}
