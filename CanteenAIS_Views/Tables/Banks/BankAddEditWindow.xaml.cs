using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Bank;
using System.Windows;
using System;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;

namespace CanteenAIS_Views.Tables.Banks
{
    /// <summary>
    /// Логика взаимодействия для BankAddEditWindow.xaml
    /// </summary>
    public partial class BankAddEditWindow : Window
    {
        private readonly BasicActionVM<BankEntity, Bank> vm;

        public BankAddEditWindow(BankWindow parent, SimpleModel<BankEntity> model, bool editMode, DataRow row = null)
        {
            InitializeComponent();
            Owner = parent;
            if (!editMode)
            {
                vm = new BankAddVM(model);
                vm.OnApply += Add;
                //idRow.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (row == null)
                    this.Close();
                vm = new BankEditVM(row, model);
                vm.OnApply += Edit;
                idRow.IsEnabled = false;
            }

            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        private void Add()
        {
            if (vm is BankAddVM vmAdd)
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
            if (vm is BankEditVM vmEdit)
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
