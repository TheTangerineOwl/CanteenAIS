using Entities = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Branch
{
    public class BranchVM : BasicVM<Entities.BranchEntity, Entities.Branch>
    {
        public BranchVM(SimpleModel<Entities.BranchEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
