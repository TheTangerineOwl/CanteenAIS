using Entities = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Realization
{
    public class RealizationVM : BasicVM<Entities.RealizationEntity, Entities.Realization>
    {
        public RealizationVM(SimpleModel<Entities.RealizationEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
