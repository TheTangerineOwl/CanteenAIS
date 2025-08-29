using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Dish
{
    public class DishEditVM : BasicEditVM<Entities.DishEntity, Entities.Dish>
    {
        public DishEditVM(DataRow row, TableModel<Entities.DishEntity> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
            Fields.GroupId = 0;
            Fields.GroupName = string.Empty;
            Fields.Price = 0;
            Fields.Serving = 0;
            Fields.UnitId = 0;
            Fields.UnitName = string.Empty;
            Fields.Recipe = string.Empty;
            Fields.Picture = string.Empty;
        }
    }
}
