using CanteenAIS_Models;
using CanteenAIS_Models.Models;
using CanteenAIS_ViewModel.BasicViewModels;
using CanteenAIS_ViewModel.EntityViewModels.Ingredient;
using System.Data;
using System.Windows.Input;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Dish
{
    public class DishVM : BasicVM<Entities.DishEntity, Entities.Dish>
    {
        public DishVM(SimpleModel<Entities.DishEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }

    }
}
