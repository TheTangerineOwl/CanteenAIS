using Entities = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Bank
{
    public class BankVM : BasicVM<Entities.BankEntity, Entities.Bank>
    {
        public BankVM(SimpleModel<Entities.BankEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
