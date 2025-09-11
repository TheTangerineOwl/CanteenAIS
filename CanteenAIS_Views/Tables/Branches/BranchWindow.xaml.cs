using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Branch;
using Microsoft.Win32;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.Tables.Branches
{
    public partial class BranchWindow : Window
    {
        public readonly BranchVM vm;

        public BranchWindow(SimpleModel<BranchEntity> model, uint elementId)
        {
            InitializeComponent();

            vm = new BranchVM(model, elementId);
            vm.OnAdd += Add;
            vm.OnEdit += Edit;
            vm.OnFilter += Filter;
            vm.OnExport += ExportCsv;
            vm.OnDelete += Delete;
            DataContext = vm;
        }

        private void Add(TableModel<BranchEntity> model)
        {
            if (model is SimpleModel<BranchEntity> model1)
            {
                BranchAddEditWindow addGroup = new BranchAddEditWindow(this, model1, false);
                addGroup.ShowDialog();
            }
        }

        private void Edit(DataRow row, TableModel<BranchEntity> model)
        {
            if (model is SimpleModel<BranchEntity> model1)
            {
                BranchAddEditWindow editGroup = new BranchAddEditWindow(this, model1, true, row);
                editGroup.ShowDialog();
            }
        }

        private void Filter(TableModel<BranchEntity> model)
        {
            if (model is SimpleModel<BranchEntity> model1)
            {
                BranchFilterWindow filter = new BranchFilterWindow(this, model1);
                filter.ShowDialog();
            }
        }

        private void Delete(DataRow row, TableModel<BranchEntity> model)
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
