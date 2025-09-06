using CanteenAIS_ViewModel.ManagementViewModels.User;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.Management
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        private readonly Window _parent;
        public ChangePasswordWindow(Window parent)
        {
            _parent = parent;
            InitializeComponent();
            if (DataContext is ChangePasswordVM vm)
            {
                vm.OnChange += ChangePassword;
                vm.OnSuccessChangePassword += ChangeSuccess;
                vm.OnCancel += Clear;
            }
        }

        public void ChangePassword()
        {
            try
            {
                if (DataContext is ChangePasswordVM vm)
                    vm.ChangePassword();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ChangeSuccess()
        {
            MessageBox.Show("Пароль успешно изменен!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            Clear();
            _parent.Show();
            this.Close();
        }

        public void Clear()
        {
            if (DataContext is ChangePasswordVM vm)
            {
                vm.ClearFormInfo();
                passOldBox.Password = string.Empty;
                passNewBox.Password = string.Empty;
                passRepeatBox.Password = string.Empty;
            }
        }

        private void PasswordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is ChangePasswordVM vm)
            {
                vm.OldPassword = ((PasswordBox)sender).Password;
            }
        }

        private void PasswordBox2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is ChangePasswordVM vm)
            {
                vm.NewPassword = ((PasswordBox)sender).Password;
            }
        }

        private void PasswordBox3_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is ChangePasswordVM vm)
            {
                vm.RepeatedPassword = ((PasswordBox)sender).Password;
            }
        }
    }
}
