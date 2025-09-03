using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.City;
using System.Windows;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_Views.Tables.Cities
{
    /// <summary>
    /// Логика взаимодействия для CityFilterWindow.xaml
    /// </summary>
    public partial class CityFilterWindow : Window
    {
        public readonly BasicFilterVM<CityEntity, City> vm;

        public CityFilterWindow(CityWindow parent, SimpleModel<CityEntity> model)
        {
            InitializeComponent();
            Owner = parent;

            vm = new CityFilterVM(model);
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
