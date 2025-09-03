using CanteenAIS_DB;
using CanteenAIS_Models;
using System;
using System.Data;
using System.Windows.Input;

namespace CanteenAIS_ViewModel.BasicViewModels
{
    public abstract class BasicActionVM<TEntityBase, TEntity> : PropChanged
        where TEntityBase : Entity
        where TEntity : TEntityBase, new()
    {
        protected virtual TableModel<TEntityBase> Model { get; private set; }

        private DataTable table;
        protected DataTable Table
        {
            get => table;
            set => Set(ref table, value);
        }

        public Action OnApply;
        public Action OnCancel;

        public abstract string WindowTitle { get; }
        public abstract string ButtonContent { get; }
        public virtual string TableTitle => Model.TableName;

        public virtual TEntity Fields { get; protected set; }

        protected BasicActionVM(TableModel<TEntityBase> tableModel)
        {
            Model = tableModel;
            Fields = new TEntity();
        }

        public virtual ICommand ClickApply
        {
            get => new Command((obj) =>
                {
                    OnApply?.Invoke();
                });
        }

        public virtual ICommand ClickCancel
        {
            get => new Command((obj) =>
                {
                    OnCancel?.Invoke();
                });
        }

        public virtual void Cancel() => Clear();

        protected abstract void Clear();

        public abstract void ParseFields();
    }

    public abstract class BasicAddVM<TEntityBase, TEntity> : BasicActionVM<TEntityBase, TEntity>
        where TEntityBase : Entity
        where TEntity : TEntityBase, new()
    {
        public override string WindowTitle => $"Добавление в таблицу: {TableTitle}";
        public override string ButtonContent => "Добавить";

        protected BasicAddVM(TableModel<TEntityBase> tableModel) : base(tableModel)
        {
            Fields = new TEntity();
        }

        public virtual void Add()
        {
            ParseFields();
            Model.Add<TEntity>(Fields);
            Table = Model.GetTable<TEntity>();
            Clear();
        }
    }

    public abstract class BasicEditVM<TEntityBase, TEntity> : BasicActionVM<TEntityBase, TEntity>
        where TEntityBase : Entity
        where TEntity : TEntityBase, new()
    {
        public override string WindowTitle => $"Изменение таблицы: {TableTitle}";
        public override string ButtonContent => "Изменить";

        protected DataRow Row;
        protected BasicEditVM(DataRow row, TableModel<TEntityBase> tableModel) : base(tableModel)
        {
            Row = row;
            Fields = Model.GetEntity<TEntity>(row);
        }

        public virtual void Edit()
        {
            ParseFields();
            Model.Update<TEntity>(Row, Fields);
            Table = Model.GetTable<TEntity>();
        }
    }

    public abstract class BasicFilterVM<TEntityBase, TEntity> : BasicActionVM<TEntityBase, TEntity>
        where TEntityBase : Entity
        where TEntity : TEntityBase, new()
    {
        public override string WindowTitle => $"Фильтровать: {TableTitle}";
        public override string ButtonContent => "Фильтр";

        protected BasicFilterVM(TableModel<TEntityBase> tableModel) : base(tableModel) { }

        public virtual void Filter()
        {
            Table = Model.GetFiltered(Fields);
        }
    }
}
