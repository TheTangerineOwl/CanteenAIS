using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Branch
{
    public class BranchAddVM : BasicAddVM<Entities.Branch>
    {
        protected BranchAddVM(TableModel<Entities.Branch> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
        }
    }
}
