using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supply
{
    public class SupplyEditVM : BasicEditVM<Entities.Supply>
    {
        protected SupplyEditVM(DataRow row, TableModel<Entities.Supply> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.SupplierId = 0;
            Fields.SupplierName = string.Empty;
            Fields.DateTime = DateTime.Now;
        }
    }
}
