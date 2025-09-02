using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.BranchOrder;
using System.Windows;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_Views.Tables.BranchOrders
{
    /// <summary>
    /// Логика взаимодействия для BranchOrderFilterWindow.xaml
    /// </summary>
    public partial class BranchOrderFilterWindow : Window
    {
        public readonly BasicFilterVM<BranchOrderEntity, BranchOrder> vm;

        public BranchOrderFilterWindow(BranchOrderWindow parent, SimpleModel<BranchOrderEntity> model)
        {
            InitializeComponent();
            Owner = parent;

            vm = new BranchOrderFilterVM(model);
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
