using Entitites = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_Models.Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using System.Windows.Input;

namespace CanteenAIS_ViewModel.EntityViewModels.AssortmentGroup
{
    public class AssortmentGroupVM : BasicVM<Entitites.AssortmentGroup>
    {
        protected bool dishesVisible;
        public bool DishesVisibility
        {
            get => dishesVisible;
            set => Set(ref dishesVisible, value);
        }

        public AssortmentGroupVM(SimpleModel<Entitites.AssortmentGroup> tableModel, uint menuElementId)
            : base(tableModel, menuElementId)
        {
            dishesVisible = true;
        }

        public Action<
            DataRow,
            SimpleModel<Entitites.AssortmentGroup>,
            SimpleModel<Entitites.DishEntity>
        > OnDishes;

        public ICommand ClickDishes
        {
            get => new Command((obj) =>
                {
                    if (SelectedIndex >= 0 && SelectedIndex < Table.Rows.Count &&
                        Model is SimpleModel<Entitites.AssortmentGroup> model
                        )
                        OnDishes?.Invoke
                        (
                            Table.Rows[SelectedIndex],
                            model,
                            new DishModel(DBContext.GetInstance().Dishes)
                        );
                });
        }
    }
}
