using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.MeasureUnit
{
    public class MeasureUnitEditVM : BasicEditVM<Entities.MeasureUnitEntity, Entities.MeasureUnit>
    {
        public MeasureUnitEditVM(DataRow row, TableModel<Entities.MeasureUnitEntity> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
        }
    }
}
