using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.OrderProduct;
using System.Windows;
using System;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;

namespace CanteenAIS_Views.Tables.BranchOrders
{
    /// <summary>
    /// Логика взаимодействия для OrderProductAddEditWindow.xaml
    /// </summary>
    public partial class OrderProductAddEditWindow : Window
    {
        private readonly BasicActionVM<OrderProductEntity, OrderProduct> vm;
        public OrderProductVM Subvm;

        public OrderProductAddEditWindow(BranchOrderAddEditWindow parent, OrderProductVM subvm, bool editMode, DataRow orderproductRow = null)
        {
            Subvm = subvm;
            InitializeComponent();
            Owner = parent;
            if (!editMode)
            {
                vm = new OrderProductAddVM(Subvm.Model);
                vm.OnApply += Add;
            }
            else
            {
                if (orderproductRow == null)
                    this.Close();
                vm = new OrderProductEditVM(orderproductRow, Subvm.Model);
                vm.OnApply += Edit;
            }
            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        private void Add()
        {
            if (vm is OrderProductAddVM vmAdd)
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
            if (vm is OrderProductEditVM vmEdit)
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
