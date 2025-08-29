using Entities = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.SupplierHead
{
    public class SupplierHeadVM : BasicVM<Entities.SupplierHeadEntity, Entities.SupplierHead>
    {
        public SupplierHeadVM(SimpleModel<Entities.SupplierHeadEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
