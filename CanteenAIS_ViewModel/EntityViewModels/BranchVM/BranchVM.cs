using Entitites = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Branch
{
    public class BranchVM : BasicVM<Entitites.Branch>
    {
        public BranchVM(SimpleModel<Entitites.Branch> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
