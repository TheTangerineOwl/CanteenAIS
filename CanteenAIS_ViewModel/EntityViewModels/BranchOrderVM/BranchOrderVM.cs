using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using CanteenAIS_ViewModel.EntityViewModels.OrderProduct;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.BranchOrder
{
    public class BranchOrderVM : BasicVM<Entities.BranchOrderEntity, Entities.BranchOrder>
    {
        public BranchOrderVM(SimpleModel<Entities.BranchOrderEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
