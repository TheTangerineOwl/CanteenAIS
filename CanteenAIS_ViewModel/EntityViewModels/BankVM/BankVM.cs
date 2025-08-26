using Entitites = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Bank
{
    public class BankVM : BasicVM<Entitites.Bank>
    {
        public BankVM(SimpleModel<Entitites.Bank> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
