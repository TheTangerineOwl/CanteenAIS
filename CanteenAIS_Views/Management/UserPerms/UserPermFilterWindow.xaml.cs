using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.ManagementViewModels.UserPerm;
using System.Windows;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_Views.Management.UserPerms
{
    /// <summary>
    /// Логика взаимодействия для UserPermFilterWindow.xaml
    /// </summary>
    public partial class UserPermFilterWindow : Window
    {
        public readonly BasicFilterVM<UserPermEntity, UserPerm> vm;

        public UserPermFilterWindow(UserPermWindow parent, DoubleModel<UserPermEntity> model)
        {
            InitializeComponent();
            Owner = parent;

            vm = new UserPermFilterVM(model);
            vm.OnApply += Filter;
            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        private void Filter()
        {
            vm.Filter();
            this.Close();
        }

        private void Cancel()
        {
            vm.Cancel();
            this.Close();
        }
    }
}
