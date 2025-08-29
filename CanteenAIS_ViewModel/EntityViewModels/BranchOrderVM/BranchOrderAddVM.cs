using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.BranchOrder
{
    public class BranchOrderAddVM : BasicAddVM<Entities.BranchOrderEntity, Entities.BranchOrder>
    {
        public BranchOrderAddVM(TableModel<Entities.BranchOrderEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.BranchId = 0;
            Fields.BranchName = string.Empty;
            Fields.DateTime = DateTime.Now;
        }
    }
}
