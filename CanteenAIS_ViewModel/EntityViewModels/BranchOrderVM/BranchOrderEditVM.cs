using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.BranchOrder
{
    public class BranchOrderEditVM : BasicEditVM<Entities.BranchOrder>
    {
        protected BranchOrderEditVM(DataRow row, TableModel<Entities.BranchOrder> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.BranchId = 0;
            Fields.BranchName = string.Empty;
            Fields.DateTime = DateTime.Now;
        }
    }
}
