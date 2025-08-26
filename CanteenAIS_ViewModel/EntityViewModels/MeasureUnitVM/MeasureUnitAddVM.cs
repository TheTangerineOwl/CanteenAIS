using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.MeasureUnit
{
    public class MeasureUnitAddVM : BasicAddVM<Entities.MeasureUnit>
    {
        protected MeasureUnitAddVM(TableModel<Entities.MeasureUnit> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
        }
    }
}
