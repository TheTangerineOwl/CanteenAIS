using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Bank;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.Tables.Banks
{
    public partial class BankWindow : Window
    {
        public readonly BankVM vm;

        public BankWindow(SimpleModel<BankEntity> model, uint elementId)
        {
            InitializeComponent();

            vm = new BankVM(model, elementId);
            vm.OnAdd += Add;
            vm.OnEdit += Edit;
            vm.OnFilter += Filter;
            vm.OnDelete += Delete;
            DataContext = vm;
        }

        private void Add(TableModel<BankEntity> model)
        {
            if (model is SimpleModel<BankEntity> model1)
            {
                BankAddEditWindow addGroup = new BankAddEditWindow(this, model1, false);
                addGroup.ShowDialog();
            }
        }

        private void Edit(DataRow row, TableModel<BankEntity> model)
        {
            if (model is SimpleModel<BankEntity> model1)
            {
                BankAddEditWindow editGroup = new BankAddEditWindow(this, model1, true, row);
                editGroup.ShowDialog();
            }
        }

        private void Filter(TableModel<BankEntity> model)
        {
            if (model is SimpleModel<BankEntity> model1)
            {
                BankFilterWindow filter = new BankFilterWindow(this, model1);
                filter.ShowDialog();
            }
        }

        private void Delete(DataRow row, TableModel<BankEntity> model)
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
