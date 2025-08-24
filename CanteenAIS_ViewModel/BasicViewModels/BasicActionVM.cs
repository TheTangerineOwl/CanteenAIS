using CanteenAIS_DB;
using CanteenAIS_Models;
using CanteenAIS_ViewModel;
using System;
using System.Data;
using System.Windows.Input;

namespace CanteenDBViewModels.BasicViewModels
{
    public abstract class BasicActionVM<TEntity, TEntityInfo> : PropChanged
        where TEntity : class, IEntity
        where TEntityInfo : Info
    {
        protected TableModel<TEntity, TEntityInfo> Model;

        public Action OnApply;
        public Action OnCancel;

        public abstract string WindowTitle { get; }
        public abstract string ButtonContent { get; }
        public virtual string TitleText => Model.TableName;

        protected BasicActionVM(TableModel<TEntity, TEntityInfo> tableModel)
        {
            Model = tableModel;
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

        public abstract void Cancel();
    }

    public abstract class BasicAddVM<TEntity, TEntityInfo> : BasicActionVM<TEntity, TEntityInfo>
        where TEntity : class, IEntity
        where TEntityInfo : Info
    {
        public override string WindowTitle => $"Добавление в таблицу: {TitleText}";
        public override string ButtonContent => "Добавить";

        protected BasicAddVM(TableModel<TEntity, TEntityInfo> tableModel) : base(tableModel) { }

        public abstract void Add();
    }

    public abstract class BasicEditVM<TEntity, TEntityInfo> : BasicActionVM<TEntity, TEntityInfo>
        where TEntity : class, IEntity
        where TEntityInfo : Info
    {
        public override string WindowTitle => $"Добавление в таблицу: {TitleText}";
        public override string ButtonContent => "Добавить";

        protected DataRow Row;
        protected BasicEditVM(DataRow row, TableModel<TEntity, TEntityInfo> tableModel) : base(tableModel)
        {
            Row = row;
        }

        public abstract void Edit();
    }

    public abstract class BasicFilterVM<TEntity, TEntityInfo> : BasicActionVM<TEntity, TEntityInfo>
        where TEntity : class, IEntity
        where TEntityInfo : Info
    {
        public override string WindowTitle => $"Фильтровать: {TitleText}";
        public override string ButtonContent => "Фильтр";

        protected DataRow Row;
        protected BasicFilterVM(DataRow row, TableModel<TEntity, TEntityInfo> tableModel) : base(tableModel)
        {
            Row = row;
        }

        public abstract void Filter();
    }
}
