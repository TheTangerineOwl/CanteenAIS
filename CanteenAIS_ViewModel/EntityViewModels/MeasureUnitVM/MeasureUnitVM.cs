using Entitites = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.MeasureUnit
{
    public class MeasureUnitVM : BasicVM<Entitites.MeasureUnit>
    {
        public MeasureUnitVM(SimpleModel<Entitites.MeasureUnit> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
