using Entitites = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Dish
{
    public class DishVM : BasicVM<Entitites.Dish>
    {
        public DishVM(SimpleModel<Entitites.Dish> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
