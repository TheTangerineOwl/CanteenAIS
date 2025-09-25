using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using CanteenAIS_ViewModel.EntityViewModels.SupplyProduct;
using System;
using System.Data;
using System.Windows.Input;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supply
{
    public class SupplyVM : BasicVM<Entities.SupplyEntity, Entities.Supply>
    {
        public SupplyVM(SimpleModel<Entities.SupplyEntity> tableModel, uint menuElementId)
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
