using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supplier
{
    public class SupplierFilterVM : BasicFilterVM<Entities.SupplierEntity, Entities.Supplier>
    {
        public SupplierFilterVM(TableModel<Entities.SupplierEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
            Fields.StreetId = 0;
            Fields.StreetName = string.Empty;
            Fields.Building = string.Empty;
            Fields.HeadId = 0;
            Fields.HeadName = string.Empty;
            Fields.HeadPhone = string.Empty;
            Fields.BankId = 0;
            Fields.BankName = string.Empty;
            Fields.Account = string.Empty;
            Fields.INN = string.Empty;
        }
    }
}
