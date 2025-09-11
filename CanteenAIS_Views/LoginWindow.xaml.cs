using CanteenAIS_ViewModel.ManagementViewModels.User;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Globalization;

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
                vm.InputInfo = GetInputInfo(
                    InputLanguageManager.Current.CurrentInputLanguage.DisplayName,
                    Keyboard.IsKeyToggled(Key.CapsLock)
                );
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

        private string GetInputInfo(string language, bool isCapsLocked)
        {
            return !isCapsLocked ? language : language + ", CapsLock включен";
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            bool isCapsLocked = e.KeyboardDevice.IsKeyToggled(Key.CapsLock);
            string lang = InputLanguageManager.Current.CurrentInputLanguage.DisplayName;
            if (DataContext is LoginVM vm)
                vm.InputInfo = GetInputInfo(lang, isCapsLocked);
        }
    }
}
