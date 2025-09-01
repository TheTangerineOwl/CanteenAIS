using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Bank;
using System.Windows;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_Views.Tables.Banks
{
    /// <summary>
    /// Логика взаимодействия для BankFilterWindow.xaml
    /// </summary>
    public partial class BankFilterWindow : Window
    {
        public readonly BasicFilterVM<BankEntity, Bank> vm;

        public BankFilterWindow(BankWindow parent, SimpleModel<BankEntity> model)
        {
            InitializeComponent();
            Owner = parent;

            vm = new BankFilterVM(model);
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
