using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Supplier;
using System.Windows;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_Views.Tables.Suppliers
{
    /// <summary>
    /// Логика взаимодействия для SupplierFilterWindow.xaml
    /// </summary>
    public partial class SupplierFilterWindow : Window
    {
        public readonly BasicFilterVM<SupplierEntity, Supplier> vm;

        public SupplierFilterWindow(SupplierWindow parent, SimpleModel<SupplierEntity> model)
        {
            InitializeComponent();
            Owner = parent;

            vm = new SupplierFilterVM(model);
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
