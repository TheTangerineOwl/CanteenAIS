using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Realization
{
    public class RealizationAddVM : BasicAddVM<Entities.RealizationEntity, Entities.Realization>
    {
        public RealizationAddVM(TableModel<Entities.RealizationEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.UnitId = 0;
            Fields.UnitName = string.Empty;
            Fields.DishId = 0;
            Fields.DishName = string.Empty;
            Fields.Amount = 0;
            Fields.DateTime = DateTime.Now;
        }
    }
}
