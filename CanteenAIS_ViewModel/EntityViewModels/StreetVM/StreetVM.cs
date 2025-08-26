using Entitites = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Street
{
    public class StreetVM : BasicVM<Entitites.Street>
    {
        public StreetVM(SimpleModel<Entitites.Street> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
