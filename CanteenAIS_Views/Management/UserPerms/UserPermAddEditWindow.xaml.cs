using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.ManagementViewModels.UserPerm;
using System.Windows;
using System;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;

namespace CanteenAIS_Views.Management.UserPerms
{
    /// <summary>
    /// Логика взаимодействия для UserPermAddEditWindow.xaml
    /// </summary>
    public partial class UserPermAddEditWindow : Window
    {
        private readonly BasicActionVM<UserPermEntity, UserPerm> vm;

        public UserPermAddEditWindow(UserPermWindow parent, DoubleModel<UserPermEntity> model, bool editMode, DataRow row = null)
        {
            InitializeComponent();
            Owner = parent;
            if (!editMode)
            {
                vm = new UserPermAddVM(model);
                vm.OnApply += Add;
            }
            else
            {
                if (row == null)
                    this.Close();
                vm = new UserPermEditVM(row, model);
                vm.OnApply += Edit;
            }

            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        private void Add()
        {
            if (vm is UserPermAddVM vmAdd)
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
            if (vm is UserPermEditVM vmEdit)
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
