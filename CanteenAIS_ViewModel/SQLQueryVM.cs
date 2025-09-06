using CanteenAIS_DB;
using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_Models;
using System;
using System.Data;
using System.Windows.Input;

namespace CanteenAIS_ViewModel
{
    public class SQLqueryVM : PropChanged
    {
        private readonly UserPermEntity Perm;

        public SQLqueryVM(uint elementId)
        {
            Perm = DBContext.GetInstance().GetCurrentPerm<UserPerm>(elementId);
        }

        public string Title => "SQL-запрос";

        private DataTable dataTable = new DataTable();
        public DataTable DataBaseTable
        {
            get => dataTable;
            set => Set(ref dataTable, value);
        }

        private string query = "";
        public string Query
        {
            get => query;
            set => Set(ref query, value);
        }

        public bool ValidPermsForQuery()
        {
            if (!Perm.CanRead && Query.Contains("SELECT"))
                return false;
            if (!Perm.CanWrite && Query.Contains("INSERT"))
                return false;
            if (!Perm.CanEdit && Query.Contains("UPDATE"))
                return false;
            if (!Perm.CanDelete && (Query.Contains("DROP") || Query.Contains("ALTER")))
                return false;
            return true;
        }

        //public enum QueryResult { GOOD, INVALPERM, EXCEPTION }
        //public QueryResult Result { get; private set; }
        private string exception;
        public string Exception { get => exception; }

        public ICommand ClickClear
        {
            get => new Command((obj) =>
                {
                    OnClear?.Invoke();
                });
        }

        public Action OnExecuteQuery;
        public Action OnClear;

        public ICommand ClickExecuteQuery
        {
            get
            {
                return new Command((obj) =>
                {
                    OnExecuteQuery?.Invoke();
                });
            }
        }

        public void Execute()
        {
            if (Query == null || Query == string.Empty)
            {
                //Result = QueryResult.GOOD;
                exception = "Запрос пуст";
            }
            else if (!ValidPermsForQuery())
            {
                //Result = QueryResult.INVALPERM;
                exception = "Запрос недопустим при данных правах пользователя!";
            }
            else
            {
                exception = string.Empty;
                DataTable table = DbConnection.GetInstance().ExecQuery(
                    Query, ref exception
                );

                if (exception != string.Empty)
                {
                    DataBaseTable.Clear();
                    //Result = QueryResult.EXCEPTION;
                }
                else
                {
                    DataBaseTable = table;
                    //Result = QueryResult.GOOD;
                }
            }
        }

        public void Clear()
        {
            Query = string.Empty;
        }
    }

}
