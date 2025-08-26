using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Branch
{
    public class BranchEditVM : BasicEditVM<Entities.Branch>
    {
        protected BranchEditVM(DataRow row, TableModel<Entities.Branch> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
        }
    }
}
