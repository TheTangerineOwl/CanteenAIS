using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Supplier;
using System.Windows;
using System;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;

namespace CanteenAIS_Views.Tables.Suppliers
{
    /// <summary>
    /// Логика взаимодействия для SupplierAddEditWindow.xaml
    /// </summary>
    public partial class SupplierAddEditWindow : Window
    {
        private readonly BasicActionVM<SupplierEntity, Supplier> vm;

        public SupplierAddEditWindow(SupplierWindow parent, SimpleModel<SupplierEntity> model, bool editMode, DataRow row = null)
        {
            InitializeComponent();
            Owner = parent;
            if (!editMode)
            {
                vm = new SupplierAddVM(model);
                vm.OnApply += Add;
                //idRow.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (row == null)
                    this.Close();
                vm = new SupplierEditVM(row, model);
                vm.OnApply += Edit;
                idRow.IsEnabled = false;
            }

            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        private void Add()
        {
            if (vm is SupplierAddVM vmAdd)
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
            if (vm is SupplierEditVM vmEdit)
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
