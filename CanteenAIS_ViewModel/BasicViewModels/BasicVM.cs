using CanteenAIS_DB;
using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_Models;
using System;
using System.Data;
using System.Windows.Input;

namespace CanteenAIS_ViewModel.BasicViewModels
{
    public abstract class BasicVM<TEntityBase, TEntity> : PropChanged
        where TEntityBase : Entity
        where TEntity : TEntityBase, new()

    {
        protected BasicVM(TableModel<TEntityBase> tableModel, uint menuElementId)
        {
            Model = tableModel;
            table = Model.GetTable<TEntity>();
            Perm = Model.GetPerms<UserPerm>(menuElementId);
            writeVisible = Perm.CanWrite;
            editVisible = false;
            deleteVisible = false;
            selectedIndex = -1;
        }

        protected virtual UserPermEntity Perm { get; set; }
        protected virtual TableModel<TEntityBase> Model { get; set; }

        protected DataTable table;
        public virtual DataTable Table
        {
            get => table;
            set => Set(ref table, value);
        }

        public virtual string Title
        {
            get => Model.TableName;
        }

        protected string searchSample;
        public virtual string SearchSample
        {
            get => searchSample;
            set
            {
                Set(ref searchSample, value);
                Table = Model.GetSearchResult<TEntity>(searchSample);
            }
        }

        protected int selectedIndex;
        public virtual int SelectedIndex
        {
            get => selectedIndex;
            set => Set(ref selectedIndex, value);
        }

        protected bool writeVisible;
        public virtual bool WriteVisibility
        {
            get => writeVisible;
            set => Set(ref writeVisible, value);
        }

        protected bool editVisible;
        public virtual bool EditVisibility
        {
            get => editVisible;
            set => Set(ref editVisible, value);
        }

        protected bool deleteVisible;
        public virtual bool DeleteVisibility
        {
            get => deleteVisible;
            set => Set(ref deleteVisible, value);
        }

        public Action OnChangeSelection;
        public Action<TableModel<TEntityBase>> OnFilter;
        public Action<TableModel<TEntityBase>> OnAdd;
        public Action<DataRow, TableModel<TEntityBase>> OnEdit;
        public Action<DataRow, TableModel<TEntityBase>> OnDelete;

        public virtual ICommand ChangeSelection
        {
            get => new Command((obj) =>
                {
                    OnChangeSelection?.Invoke();
                });
        }

        protected TEntity filter;
        public virtual TEntity FilterIn
        {
            get => filter;
            set
            {
                Set(ref filter, value);
                Table = Model.GetFiltered(filter);
            }
        }

        public virtual ICommand ClickFilter
        {
            get => new Command((obj) =>
                {
                    OnFilter?.Invoke(Model);
                });
        }

        public virtual ICommand ClickAdd
        {
            get => new Command((obj) =>
                {
                    OnAdd?.Invoke(Model);
                });
        }

        public virtual ICommand ClickEdit
        {
            get => new Command((obj) =>
                {
                    if (SelectedIndex >= 0 && SelectedIndex < Table.Rows.Count)
                        OnEdit?.Invoke(Table.Rows[SelectedIndex], Model);
                });
        }

        public virtual ICommand ClickDelete
        {
            get => new Command((obj) =>
                {
                    if (SelectedIndex >= 0 && SelectedIndex < Table.Rows.Count)
                        OnDelete?.Invoke(Table.Rows[SelectedIndex], Model);
                });
        }

        public virtual void DataTableMouseDown()
        {
            EditVisibility = Perm.CanEdit;
            DeleteVisibility = Perm.CanDelete;
        }

        public virtual void DataTableMouseLeave()
        {
            EditVisibility = false;
            DeleteVisibility = false;
        }

        public virtual void Delete()
        {
            Model.DeleteRow(Table.Rows[SelectedIndex]);
            UpdateDataTable();
        }

        public virtual void UpdateDataTable()
        {
            Table = Model.GetTable<TEntity>();
        }
    }
}
