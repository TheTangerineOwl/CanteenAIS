using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Supply;
using System.Windows;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_Views.Tables.Supplies
{
    /// <summary>
    /// Логика взаимодействия для SupplyFilterWindow.xaml
    /// </summary>
    public partial class SupplyFilterWindow : Window
    {
        public readonly BasicFilterVM<SupplyEntity, Supply> vm;

        public SupplyFilterWindow(SupplyWindow parent, SimpleModel<SupplyEntity> model)
        {
            InitializeComponent();
            Owner = parent;

            vm = new SupplyFilterVM(model);
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
