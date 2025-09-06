using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.MeasureUnit;
using Microsoft.Win32;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.Tables.MeasureUnits
{
    public partial class MeasureUnitWindow : Window
    {
        public readonly MeasureUnitVM vm;

        public MeasureUnitWindow(SimpleModel<MeasureUnitEntity> model, uint elementId)
        {
            InitializeComponent();

            vm = new MeasureUnitVM(model, elementId);
            vm.OnAdd += Add;
            vm.OnEdit += Edit;
            vm.OnFilter += Filter;
            vm.OnExport += ExportCsv;
            vm.OnDelete += Delete;
            DataContext = vm;
        }

        private void Add(TableModel<MeasureUnitEntity> model)
        {
            if (model is SimpleModel<MeasureUnitEntity> model1)
            {
                MeasureUnitAddEditWindow addGroup = new MeasureUnitAddEditWindow(this, model1, false);
                addGroup.ShowDialog();
            }
        }

        private void Edit(DataRow row, TableModel<MeasureUnitEntity> model)
        {
            if (model is SimpleModel<MeasureUnitEntity> model1)
            {
                MeasureUnitAddEditWindow editGroup = new MeasureUnitAddEditWindow(this, model1, true, row);
                editGroup.ShowDialog();
            }
        }

        private void Filter(TableModel<MeasureUnitEntity> model)
        {
            if (model is SimpleModel<MeasureUnitEntity> model1)
            {
                MeasureUnitFilterWindow filter = new MeasureUnitFilterWindow(this, model1);
                filter.ShowDialog();
            }
        }

        private void Delete(DataRow row, TableModel<MeasureUnitEntity> model)
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

        public void ExportCsv()
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    AddExtension = true,
                    CheckPathExists = true,
                    CreatePrompt = true,
                    OverwritePrompt = true,
                    DefaultExt = "*.csv",
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"
                };
                if (dialog.ShowDialog() == true)
                {
                    string file = dialog.FileName;
                    vm.ExportCsv(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
