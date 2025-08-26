using Entitites = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Supply
{
    public class SupplyVM : BasicVM<Entitites.Supply>
    {
        public SupplyVM(SimpleModel<Entitites.Supply> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
