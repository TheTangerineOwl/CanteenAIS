using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.ManagementViewModels.UserPerm;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.Management.UserPerms
{
    public partial class UserPermWindow : Window
    {
        public readonly UserPermVM vm;

        public UserPermWindow(DoubleModel<UserPermEntity> model, uint elementId)
        {
            InitializeComponent();

            vm = new UserPermVM(model, elementId);
            vm.OnAdd += Add;
            vm.OnEdit += Edit;
            vm.OnFilter += Filter;
            vm.OnDelete += Delete;
            DataContext = vm;
        }

        private void Add(TableModel<UserPermEntity> model)
        {
            if (model is DoubleModel<UserPermEntity> model1)
            {
                UserPermAddEditWindow addGroup = new UserPermAddEditWindow(this, model1, false);
                addGroup.ShowDialog();
            }
        }

        private void Edit(DataRow row, TableModel<UserPermEntity> model)
        {
            if (model is DoubleModel<UserPermEntity> model1)
            {
                UserPermAddEditWindow editGroup = new UserPermAddEditWindow(this, model1, true, row);
                editGroup.ShowDialog();
            }
        }

        private void Filter(TableModel<UserPermEntity> model)
        {
            if (model is DoubleModel<UserPermEntity> model1)
            {
                UserPermFilterWindow filter = new UserPermFilterWindow(this, model1);
                filter.ShowDialog();
            }
        }

        private void Delete(DataRow row, TableModel<UserPermEntity> model)
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
