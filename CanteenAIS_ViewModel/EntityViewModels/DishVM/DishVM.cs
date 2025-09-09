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

        public IngredientVM subvm;

        public override int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (selectedIndex > 0 && selectedIndex <= Table.Rows.Count)
                    subvm.DishId = Table.Rows[selectedIndex].Field<uint>("Id");
                Set(ref selectedIndex, value);
            }
        }
    }
}
