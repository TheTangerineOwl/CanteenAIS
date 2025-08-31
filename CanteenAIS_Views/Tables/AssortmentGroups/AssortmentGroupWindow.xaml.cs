using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_Models.Models;
using CanteenAIS_ViewModel;
using CanteenAIS_ViewModel.EntityViewModels.AssortmentGroup;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CanteenAIS_Views.Tables.AssortmentGroups
{
    public partial class AssortmentGroupWindow : Window
    {
        public readonly AssortmentGroupVM vm;

        public AssortmentGroupWindow(SimpleModel<AssortmentGroupEntity> model, uint elementId)
        {
            InitializeComponent();

            vm = new AssortmentGroupVM(model, elementId);
            vm.OnAdd += Add;
            vm.OnEdit += Edit;
            vm.OnFilter += Filter;
            vm.OnDelete += Delete;
            DataContext = vm;

        }

        private void Add(TableModel<AssortmentGroupEntity> model)
        {
            if (model is SimpleModel<AssortmentGroupEntity> model1)
            {
                AssortmentGroupAddEditWindow addGroup = new AssortmentGroupAddEditWindow(this, model1, false);
                addGroup.ShowDialog();
                vm.Table = model1.Table;
            }
        }

        private void Edit(DataRow row, TableModel<AssortmentGroupEntity> model)
        {
            if (model is SimpleModel<AssortmentGroupEntity> model1)
            {
                AssortmentGroupAddEditWindow editGroup = new AssortmentGroupAddEditWindow(this, model1, true, row);
                editGroup.ShowDialog();
                vm.Table = model1.Table;
            }
        }

        private void Filter(TableModel<AssortmentGroupEntity> model)
        {
            if (model is SimpleModel<AssortmentGroupEntity> model1)
            {
                //AssortmentGroupAddEditWindow editGroup = new AssortmentGroupAddEditWindow(this, model1, ActionMode.Filter, null);
                //editGroup.ShowDialog();
                AssortmentGroupFilterWindow filter = new AssortmentGroupFilterWindow(this, model1);
                filter.ShowDialog();
                vm.Table = model1.Table;
                //if (_filter.ShowDialog() == true)
                //    vm.FilterIn = _filter.vm.Fields;
            }
        }

        private void Delete(DataRow row, TableModel<AssortmentGroupEntity> model)
        {
            // AssortmentGroupEditWindow editGroup = new AssortmentGroupEditWindow(...);
            // editGroup.ShowDialog();
            MessageBoxResult dr = MessageBox.Show("Удалить запись?", "Удаление данных", MessageBoxButton.YesNo);
            //if (dr.HasFlag(MessageBoxResult.Yes))
            if (dr == MessageBoxResult.Yes)
            {
                vm.Delete();
                vm.Table = model.Table;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (vm.SelectedIndex == -1)
                vm.DataTableMouseLeave();
            else
                vm.DataTableMouseDown();
        }
    }
}
