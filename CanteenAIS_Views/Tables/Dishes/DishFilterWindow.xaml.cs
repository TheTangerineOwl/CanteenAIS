using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Dish;
using System.Windows;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_Views.Tables.Dishes
{
    /// <summary>
    /// Логика взаимодействия для DishFilterWindow.xaml
    /// </summary>
    public partial class DishFilterWindow : Window
    {
        public readonly BasicFilterVM<DishEntity, Dish> vm;

        public DishFilterWindow(DishWindow parent, SimpleModel<DishEntity> model)
        {
            InitializeComponent();
            Owner = parent;

            vm = new DishFilterVM(model);
            vm.OnApply += Filter;
            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        private void Filter()
        {
            vm.Filter();
            this.Close();
        }

        private void Cancel()
        {
            vm.Cancel();
            this.Close();
        }
    }
}
