using Entitites = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.BranchOrder
{
    public class BranchOrderVM : BasicVM<Entitites.BranchOrder>
    {
        public BranchOrderVM(SimpleModel<Entitites.BranchOrder> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
