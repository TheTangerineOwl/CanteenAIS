using CanteenAIS_ViewModel.ManagementViewModels.User;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            if (DataContext is LoginVM vm)
            {
                vm.OnLogin += Login;
                vm.OnLoginSuccess += LoginSuccess;
                vm.OnCancel += Clear;
            }
        }

        public void Login()
        {
            try
            {
                if (DataContext is LoginVM vm)
                    vm.Login();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LoginSuccess()
        {
            Clear();
            MainMenu menu = new MainMenu(this);
            menu.Show();
            this.Hide();
        }

        public void Clear()
        {
            if (DataContext is LoginVM vm)
            {
                vm.ClearLoginInfo();
                passBox.Password = string.Empty;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginVM vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
