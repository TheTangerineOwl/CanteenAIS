using CanteenAIS_DB;
using CanteenAIS_Models;
using System;
using System.Data;
using System.Windows.Input;

namespace CanteenAIS_ViewModel.BasicViewModels
{
    public abstract class BasicActionVM<TEntity> : PropChanged
        where TEntity : Entity, new()
    {
        protected TableModel<TEntity> Model;

        public Action OnApply;
        public Action OnCancel;

        public abstract string WindowTitle { get; }
        public abstract string ButtonContent { get; }
        public virtual string TableTitle => Model.TableName;

        public virtual TEntity Fields { get; protected set; }

        protected BasicActionVM(TableModel<TEntity> tableModel)
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
    }

    public abstract class BasicAddVM<TEntity> : BasicActionVM<TEntity>
        where TEntity : Entity, new()
    {
        public override string WindowTitle => $"Добавление в таблицу: {TableTitle}";
        public override string ButtonContent => "Добавить";

        protected BasicAddVM(TableModel<TEntity> tableModel) : base(tableModel)
        {
            Fields = new TEntity();
        }

        public abstract void Add();
    }

    public abstract class BasicEditVM<TEntity> : BasicActionVM<TEntity>
        where TEntity : Entity, new()
    {
        public override string WindowTitle => $"Добавление в таблицу: {TableTitle}";
        public override string ButtonContent => "Добавить";

        protected DataRow Row;
        protected BasicEditVM(DataRow row, TableModel<TEntity> tableModel) : base(tableModel)
        {
            Row = row;
            Fields = Model.GetEntity<TEntity>(row);
        }

        public abstract void Edit();
    }

    public abstract class BasicFilterVM<TEntity> : BasicActionVM<TEntity>
        where TEntity : Entity, new()
    {
        public override string WindowTitle => $"Фильтровать: {TableTitle}";
        public override string ButtonContent => "Фильтр";

        protected DataRow Row;
        protected BasicFilterVM(DataRow row, TableModel<TEntity> tableModel) : base(tableModel)
        {
            Row = row;
            Fields = Model.GetEntity<TEntity>(row);
        }

        public abstract void Filter();
    }
}
