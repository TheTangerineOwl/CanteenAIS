using Entities = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Street
{
    public class StreetVM : BasicVM<Entities.StreetEntity, Entities.Street>
    {
        public StreetVM(SimpleModel<Entities.StreetEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
