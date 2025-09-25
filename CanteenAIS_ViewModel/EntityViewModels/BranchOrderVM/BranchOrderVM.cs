using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using CanteenAIS_ViewModel.EntityViewModels.OrderProduct;
using System;
using System.Data;
using System.Windows.Input;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.BranchOrder
{
    public class BranchOrderVM : BasicVM<Entities.BranchOrderEntity, Entities.BranchOrder>
    {
        public BranchOrderVM(SimpleModel<Entities.BranchOrderEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }


        public string SubtableName => "Продукты";
        public Action OnSubtable;

        public virtual ICommand ClickSubtable
        {
            get => new Command((obj) =>
            {
                OnSubtable?.Invoke();
            });
        }

        protected bool subtableVisibility = false;
        public virtual bool SubtableVisibility
        {
            get => subtableVisibility;
            set => Set(ref subtableVisibility, value);
        }

        public override void DataTableMouseDown()
        {
            base.DataTableMouseDown();
            SubtableVisibility = true;
        }

        public override void DataTableMouseLeave()
        {
            base.DataTableMouseLeave();
            SubtableVisibility = false;
        }
    }
}
