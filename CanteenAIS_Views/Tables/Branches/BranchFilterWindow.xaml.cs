using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Branch;
using System.Windows;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_Views.Tables.Branches
{
    /// <summary>
    /// Логика взаимодействия для BranchFilterWindow.xaml
    /// </summary>
    public partial class BranchFilterWindow : Window
    {
        public readonly BasicFilterVM<BranchEntity, Branch> vm;

        public BranchFilterWindow(BranchWindow parent, SimpleModel<BranchEntity> model)
        {
            InitializeComponent();
            Owner = parent;

            vm = new BranchFilterVM(model);
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
