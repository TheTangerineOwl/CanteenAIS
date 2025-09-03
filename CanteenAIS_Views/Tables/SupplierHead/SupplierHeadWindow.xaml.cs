using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.SupplierHead;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.Tables.SupplierHeads
{
    public partial class SupplierHeadWindow : Window
    {
        public readonly SupplierHeadVM vm;

        public SupplierHeadWindow(SimpleModel<SupplierHeadEntity> model, uint elementId)
        {
            InitializeComponent();

            vm = new SupplierHeadVM(model, elementId);
            vm.OnAdd += Add;
            vm.OnEdit += Edit;
            vm.OnFilter += Filter;
            vm.OnDelete += Delete;
            DataContext = vm;
        }

        private void Add(TableModel<SupplierHeadEntity> model)
        {
            if (model is SimpleModel<SupplierHeadEntity> model1)
            {
                SupplierHeadAddEditWindow addGroup = new SupplierHeadAddEditWindow(this, model1, false);
                addGroup.ShowDialog();
            }
        }

        private void Edit(DataRow row, TableModel<SupplierHeadEntity> model)
        {
            if (model is SimpleModel<SupplierHeadEntity> model1)
            {
                SupplierHeadAddEditWindow editGroup = new SupplierHeadAddEditWindow(this, model1, true, row);
                editGroup.ShowDialog();
            }
        }

        private void Filter(TableModel<SupplierHeadEntity> model)
        {
            if (model is SimpleModel<SupplierHeadEntity> model1)
            {
                SupplierHeadFilterWindow filter = new SupplierHeadFilterWindow(this, model1);
                filter.ShowDialog();
            }
        }

        private void Delete(DataRow row, TableModel<SupplierHeadEntity> model)
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
    }
}
