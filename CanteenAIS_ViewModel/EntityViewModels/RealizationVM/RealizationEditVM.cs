using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Realization
{
    public class RealizationEditVM : BasicEditVM<Entities.RealizationEntity, Entities.Realization>
    {
        public RealizationEditVM(DataRow row, TableModel<Entities.RealizationEntity> tableModel)
            : base(row, tableModel) { }

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
