using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.SupplierHead
{
    public class SupplierHeadAddVM : BasicAddVM<Entities.SupplierHead>
    {
        protected SupplierHeadAddVM(TableModel<Entities.SupplierHead> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.LastName = string.Empty;
            Fields.FirstName = string.Empty;
            Fields.Patronim = string.Empty;
            Fields.Phone = string.Empty;
        }
    }
}
