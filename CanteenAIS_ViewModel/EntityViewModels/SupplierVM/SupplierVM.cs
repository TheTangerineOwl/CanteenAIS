using Entitites = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Supplier
{
    public class SupplierVM : BasicVM<Entitites.Supplier>
    {
        public SupplierVM(SimpleModel<Entitites.Supplier> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
