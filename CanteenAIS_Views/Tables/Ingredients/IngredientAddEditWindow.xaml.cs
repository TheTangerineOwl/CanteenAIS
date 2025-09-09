using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Dish;
using System.Windows;
using System;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;
using CanteenAIS_ViewModel.EntityViewModels.Ingredient;

namespace CanteenAIS_Views.Tables.Dishes
{
    /// <summary>
    /// Логика взаимодействия для IngredientAddEditWindow.xaml
    /// </summary>
    public partial class IngredientAddEditWindow : Window
    {
        private readonly BasicActionVM<IngredientEntity, Ingredient> vm;
        public IngredientVM Subvm;

        public IngredientAddEditWindow(DishAddEditWindow parent, IngredientVM subvm, bool editMode, DataRow ingredientRow = null)
        {
            Subvm = subvm;
            InitializeComponent();
            Owner = parent;
            if (!editMode)
            {
                vm = new IngredientAddVM(Subvm.Model);
                vm.OnApply += Add;
            }
            else
            {
                if (ingredientRow == null)
                    this.Close();
                vm = new IngredientEditVM(ingredientRow, Subvm.Model);//, Subvm.DishId.Value);
                vm.OnApply += Edit;
            }
            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        private void Add()
        {
            if (vm is IngredientAddVM vmAdd)
            {
                try
                {
                    vmAdd.Add();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    vmAdd.Cancel();
                }
            }
        }

        private void Edit()
        {
            if (vm is IngredientEditVM vmEdit)
            {
                try
                {
                    vmEdit.Edit();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    vmEdit.Cancel();
                }
            }
        }

        private void Cancel()
        {
            vm.Cancel();
            this.Close();
        }
    }
}
