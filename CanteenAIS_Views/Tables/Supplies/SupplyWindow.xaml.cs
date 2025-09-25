using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Supply;
using CanteenAIS_Views.Tables.Dishes;
using Microsoft.Win32;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.Tables.Supplies
{
    public partial class SupplyWindow : Window
    {
        public readonly SupplyVM vm;

        public SupplyWindow(SimpleModel<SupplyEntity> model, uint elementId)
        {
            InitializeComponent();

            vm = new SupplyVM(model, elementId);
            vm.OnAdd += Add;
            vm.OnEdit += Edit;
            vm.OnFilter += Filter;
            vm.OnDelete += Delete;
            vm.OnExport += ExportCsv;
            vm.OnTableUpdate += HideColumns;
            vm.OnSubtable += ReadSubtable;

            DataContext = vm;
        }

        private void HideColumns()
        {
            ColumnMasker.HideInvisible<Supply>(dtGrid);
        }

        private void ReadSubtable()
        {
            uint id = vm.Table.Rows[vm.SelectedIndex].Field<uint>("Id");
            SupplyProductWindow products = new SupplyProductWindow(id);
            products.Show();
        }


        private void Add(TableModel<SupplyEntity> model)
        {
            if (model is SimpleModel<SupplyEntity> model1)
            {
                vm.SelectedIndex = -1;
                SupplyAddEditWindow addGroup = new SupplyAddEditWindow(this, model1, false);
                addGroup.ShowDialog();
            }
        }

        private void Edit(DataRow row, TableModel<SupplyEntity> model)
        {
            if (model is SimpleModel<SupplyEntity> model1)
            {
                SupplyAddEditWindow editGroup = new SupplyAddEditWindow(this, model1, true, row);
                editGroup.ShowDialog();
            }
        }

        private void Filter(TableModel<SupplyEntity> model)
        {
            if (model is SimpleModel<SupplyEntity> model1)
            {
                SupplyFilterWindow filter = new SupplyFilterWindow(this, model1);
                filter.ShowDialog();
            }
        }

        private void Delete(DataRow row, TableModel<SupplyEntity> model)
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
            HideColumns();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ColumnMasker.HideInvisible<Supply>(dtGrid);
        }
    }
}
