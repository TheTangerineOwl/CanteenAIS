using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.City;
using System.Windows;
using System;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;

namespace CanteenAIS_Views.Tables.Cities
{
    /// <summary>
    /// Логика взаимодействия для CityAddEditWindow.xaml
    /// </summary>
    public partial class CityAddEditWindow : Window
    {
        private readonly BasicActionVM<CityEntity, City> vm;

        public CityAddEditWindow(CityWindow parent, SimpleModel<CityEntity> model, bool editMode, DataRow row = null)
        {
            InitializeComponent();
            Owner = parent;
            if (!editMode)
            {
                vm = new CityAddVM(model);
                vm.OnApply += Add;
                //idRow.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (row == null)
                    this.Close();
                vm = new CityEditVM(row, model);
                vm.OnApply += Edit;
                idRow.IsEnabled = false;
            }

            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        private void Add()
        {
            if (vm is CityAddVM vmAdd)
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
            if (vm is CityEditVM vmEdit)
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
