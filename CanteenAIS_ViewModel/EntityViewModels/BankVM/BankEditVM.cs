using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Bank
{
    public class BankEditVM : BasicEditVM<Entities.Bank>
    {
        protected BankEditVM(DataRow row, TableModel<Entities.Bank> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
        }
    }
}
