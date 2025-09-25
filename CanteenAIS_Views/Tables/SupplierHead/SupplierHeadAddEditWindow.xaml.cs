using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.SupplierHead;
using System.Windows;
using System;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;

namespace CanteenAIS_Views.Tables.SupplierHeads
{
    /// <summary>
    /// Логика взаимодействия для SupplierHeadAddEditWindow.xaml
    /// </summary>
    public partial class SupplierHeadAddEditWindow : Window
    {
        private readonly BasicActionVM<SupplierHeadEntity, SupplierHead> vm;

        public SupplierHeadAddEditWindow(SupplierHeadWindow parent, SimpleModel<SupplierHeadEntity> model, bool editMode, DataRow row = null)
        {
            InitializeComponent();
            Owner = parent;
            if (!editMode)
            {
                vm = new SupplierHeadAddVM(model);
                vm.OnApply += Add;
                idRow.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (row == null)
                    this.Close();
                vm = new SupplierHeadEditVM(row, model);
                vm.OnApply += Edit;
                idRow.IsEnabled = false;
            }

            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        private void Add()
        {
            if (vm is SupplierHeadAddVM vmAdd)
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
            if (vm is SupplierHeadEditVM vmEdit)
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
