using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Supplier;
using Microsoft.Win32;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.Tables.Suppliers
{
    public partial class SupplierWindow : Window
    {
        public readonly SupplierVM vm;

        public SupplierWindow(SimpleModel<SupplierEntity> model, uint elementId)
        {
            InitializeComponent();

            vm = new SupplierVM(model, elementId);
            vm.OnAdd += Add;
            vm.OnEdit += Edit;
            vm.OnFilter += Filter;
            vm.OnExport += ExportCsv;
            vm.OnDelete += Delete;
            DataContext = vm;
        }

        private void Add(TableModel<SupplierEntity> model)
        {
            if (model is SimpleModel<SupplierEntity> model1)
            {
                SupplierAddEditWindow addGroup = new SupplierAddEditWindow(this, model1, false);
                addGroup.ShowDialog();
            }
        }

        private void Edit(DataRow row, TableModel<SupplierEntity> model)
        {
            if (model is SimpleModel<SupplierEntity> model1)
            {
                SupplierAddEditWindow editGroup = new SupplierAddEditWindow(this, model1, true, row);
                editGroup.ShowDialog();
            }
        }

        private void Filter(TableModel<SupplierEntity> model)
        {
            if (model is SimpleModel<SupplierEntity> model1)
            {
                SupplierFilterWindow filter = new SupplierFilterWindow(this, model1);
                filter.ShowDialog();
            }
        }

        private void Delete(DataRow row, TableModel<SupplierEntity> model)
        {
            MessageBoxResult dr = MessageBox.Show("Удалить запись?", "Удаление данных", MessageBoxButton.YesNo);
            if (dr == MessageBoxResult.Yes)
                vm.Delete();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vm.SelectedIndex == -1)
                vm.DataTableMouseLeave();
            else
                vm.DataTableMouseDown();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (dtGrid.ItemsSource is DataView dataView && dataView.Table != null)
            {
                DataTable dataTable = dataView.Table;
                DataColumn dataColumn = dataTable.Columns[e.PropertyName];

                if (dataColumn != null)
                    e.Column.Header = dataColumn.Caption;
            }
        }

        public void ExportCsv(string format)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    AddExtension = true,
                    CheckPathExists = true,
                    CreatePrompt = true,
                    OverwritePrompt = true,
                };
                if (format == "Word")
                {
                    dialog.DefaultExt = "*.docx";
                    dialog.Filter = "Microsoft Office Word files (*.docx;*.doc)|*.docx;*.doc|All files (*.*)|*.*";
                }
                else if (format == "Excel")
                {
                    dialog.DefaultExt = "*.xlsx";
                    dialog.Filter = "Microsoft Office Excel files (*.xls, *.xlsx)|*.xlsx;*xls|All files (*.*)|*.*";
                }
                else
                {
                    dialog.DefaultExt = "*.csv";
                    dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                }
                if (dialog.ShowDialog() == true)
                {
                    string file = dialog.FileName;
                    vm.ExportCsv(file, format);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
