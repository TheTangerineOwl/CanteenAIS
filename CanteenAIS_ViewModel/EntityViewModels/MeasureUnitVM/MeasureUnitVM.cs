using Entities = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.MeasureUnit
{
    public class MeasureUnitVM : BasicVM<Entities.MeasureUnitEntity, Entities.MeasureUnit>
    {
        public MeasureUnitVM(SimpleModel<Entities.MeasureUnitEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
