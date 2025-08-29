using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Branch
{
    public class BranchAddVM : BasicAddVM<Entities.BranchEntity, Entities.Branch>
    {
        public BranchAddVM(TableModel<Entities.BranchEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
        }
    }
}
