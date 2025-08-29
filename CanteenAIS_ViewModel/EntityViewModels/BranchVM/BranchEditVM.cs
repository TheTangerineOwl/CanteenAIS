using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Branch
{
    public class BranchEditVM : BasicEditVM<Entities.BranchEntity, Entities.Branch>
    {
        public BranchEditVM(DataRow row, TableModel<Entities.BranchEntity> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
        }
    }
}
