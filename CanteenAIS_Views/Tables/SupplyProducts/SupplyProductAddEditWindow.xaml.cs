using CanteenAIS_DB.Database.Entities;
using CanteenAIS_ViewModel.EntityViewModels.SupplyProduct;
using System.Windows;
using System;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;

namespace CanteenAIS_Views.Tables.Supplies
{
    /// <summary>
    /// Логика взаимодействия для SupplyProductAddEditWindow.xaml
    /// </summary>
    public partial class SupplyProductAddEditWindow : Window
    {
        private readonly BasicActionVM<SupplyProductEntity, SupplyProduct> vm;
        public SupplyProductVM Subvm;

        public SupplyProductAddEditWindow(SupplyAddEditWindow parent, SupplyProductVM subvm, bool editMode, DataRow supplyproductRow = null)
        {
            Subvm = subvm;
            InitializeComponent();
            Owner = parent;
            if (!editMode)
            {
                vm = new SupplyProductAddVM(Subvm.Model);
                vm.OnApply += Add;
            }
            else
            {
                if (supplyproductRow == null)
                    this.Close();
                vm = new SupplyProductEditVM(supplyproductRow, Subvm.Model);
                vm.OnApply += Edit;
            }
            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        private void Add()
        {
            if (vm is SupplyProductAddVM vmAdd)
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
            if (vm is SupplyProductEditVM vmEdit)
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
