using Entitites = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.SupplierHead
{
    public class SupplierHeadVM : BasicVM<Entitites.SupplierHead>
    {
        public SupplierHeadVM(SimpleModel<Entitites.SupplierHead> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
