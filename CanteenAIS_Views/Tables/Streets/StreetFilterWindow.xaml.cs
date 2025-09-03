using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Street;
using System.Windows;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_Views.Tables.Streets
{
    /// <summary>
    /// Логика взаимодействия для StreetFilterWindow.xaml
    /// </summary>
    public partial class StreetFilterWindow : Window
    {
        public readonly BasicFilterVM<StreetEntity, Street> vm;

        public StreetFilterWindow(StreetWindow parent, SimpleModel<StreetEntity> model)
        {
            InitializeComponent();
            Owner = parent;

            vm = new StreetFilterVM(model);
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
