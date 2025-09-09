using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Supply;
using System.Windows;
using System;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;

namespace CanteenAIS_Views.Tables.Supplies
{
    /// <summary>
    /// Логика взаимодействия для SupplyAddEditWindow.xaml
    /// </summary>
    public partial class SupplyAddEditWindow : Window
    {
        private readonly BasicActionVM<SupplyEntity, Supply> vm;

        public SupplyAddEditWindow(SupplyWindow parent, SimpleModel<SupplyEntity> model, bool editMode, DataRow row = null)
        {
            InitializeComponent();
            Owner = parent;
            if (!editMode)
            {
                vm = new SupplyAddVM(model);
                vm.OnApply += Add;
                //idRow.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (row == null)
                    this.Close();
                vm = new SupplyEditVM(row, model);
                vm.OnApply += Edit;
                idRow.IsEnabled = false;
            }

            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        private void Add()
        {
            if (vm is SupplyAddVM vmAdd)
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
            if (vm is SupplyEditVM vmEdit)
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
