using Entitites = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Realization
{
    public class RealizationVM : BasicVM<Entitites.Realization>
    {
        public RealizationVM(SimpleModel<Entitites.Realization> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
