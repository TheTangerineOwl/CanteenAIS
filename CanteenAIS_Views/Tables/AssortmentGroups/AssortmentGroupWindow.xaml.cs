using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_Models.Models;
using CanteenAIS_ViewModel;
using CanteenAIS_ViewModel.EntityViewModels.AssortmentGroup;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace CanteenAIS_Views.Tables.AssortmentGroups
{
    public partial class AssortmentGroupWindow : Window
    {
        private readonly AssortmentGroupVM vm;

        public AssortmentGroupWindow(SimpleModel<AssortmentGroupEntity> model, uint elementId)
        {
            InitializeComponent();

            vm = new AssortmentGroupVM(model, elementId);
            //vm.OnAdd += foo;
            vm.OnAdd += Add;
            DataContext = vm;

        }

        private void Add(TableModel<AssortmentGroupEntity> model)
        {

            // не может SimpleModel в TableModel сделать
            if (model is SimpleModel<AssortmentGroupEntity> model1)
            {
                AssortmentGroupAddWindow addGroup = new AssortmentGroupAddWindow(this, model1);
                addGroup.ShowDialog();
            }
        }

        public void UpdateTable()
        {
            vm.UpdateDataTable();
        }

        private void Edit(DataRow row, SimpleModel<AssortmentGroupEntity> model, uint elementId)
        {
            // AssortmentGroupEditWindow editGroup = new AssortmentGroupEditWindow(...);
            // editGroup.ShowDialog();
        }

        private void Delete(DataRow row, SimpleModel<AssortmentGroupEntity> model, uint elementId)
        {
            // AssortmentGroupEditWindow editGroup = new AssortmentGroupEditWindow(...);
            // editGroup.ShowDialog();
            MessageBoxResult dr = MessageBox.Show("Удалить запись?", "Удаление данных", MessageBoxButton.YesNo);
            if (dr.HasFlag(MessageBoxResult.Yes))
            {
                vm.Delete();
                vm.UpdateDataTable();
            }
        }

        private void DataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //vm.DataTableMouseDown();
        }

        private void DataGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            //vm.DataTableMouseLeave();
        }

        private void DataGrid_Selected(object sender, RoutedEventArgs e)
        {
            vm.DataTableMouseDown();
        }

        private void DataGrid_Unselected(object sender, RoutedEventArgs e)
        {
            vm.DataTableMouseLeave();
        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (vm.SelectedIndex == -1)
                vm.DataTableMouseLeave();
            else
                vm.DataTableMouseDown();
        }
    }
}
