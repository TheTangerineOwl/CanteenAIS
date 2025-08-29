using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supply
{
    public class SupplyFilterVM : BasicFilterVM<Entities.SupplyEntity, Entities.Supply>
    {
        public SupplyFilterVM(TableModel<Entities.SupplyEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.SupplierId = 0;
            Fields.SupplierName = string.Empty;
            Fields.DateTime = DateTime.Now;
        }
    }
}
