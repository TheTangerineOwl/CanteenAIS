using Entities = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Dish
{
    public class DishVM : BasicVM<Entities.DishEntity, Entities.Dish>
    {
        public DishVM(SimpleModel<Entities.DishEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
