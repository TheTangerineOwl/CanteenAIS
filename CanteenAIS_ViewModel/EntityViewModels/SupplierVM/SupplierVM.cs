using Entities = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Supplier
{
    public class SupplierVM : BasicVM<Entities.SupplierEntity, Entities.Supplier>
    {
        public SupplierVM(SimpleModel<Entities.SupplierEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
