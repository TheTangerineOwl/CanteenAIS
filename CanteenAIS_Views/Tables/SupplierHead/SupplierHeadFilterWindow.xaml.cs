using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.SupplierHead;
using System.Windows;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_Views.Tables.SupplierHeads
{
    /// <summary>
    /// Логика взаимодействия для SupplierHeadFilterWindow.xaml
    /// </summary>
    public partial class SupplierHeadFilterWindow : Window
    {
        public readonly BasicFilterVM<SupplierHeadEntity, SupplierHead> vm;

        public SupplierHeadFilterWindow(SupplierHeadWindow parent, SimpleModel<SupplierHeadEntity> model)
        {
            InitializeComponent();
            Owner = parent;

            vm = new SupplierHeadFilterVM(model);
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
