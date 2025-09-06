using CanteenAIS_ViewModel.ManagementViewModels.User;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.Management
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private readonly Window _parent;
        public RegistrationWindow(Window parent)
        {
            _parent = parent;
            InitializeComponent();
            if (DataContext is RegistrationVM vm)
            {
                vm.OnRegistrate += Registration;
                vm.OnSuccessRegistration += RegistrationSuccess;
                vm.OnCancel += Clear;
            }
        }

        public void Registration()
        {
            try
            {
                if (DataContext is RegistrationVM vm)
                    vm.Registrate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void RegistrationSuccess()
        {
            MessageBox.Show("Регистрация прошла успешно!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            Clear();
            _parent.Show();
            this.Close();
        }

        public void Clear()
        {
            if (DataContext is RegistrationVM vm)
            {
                vm.ClearFields();
                passOldBox.Password = string.Empty;
                passNewBox.Password = string.Empty;
            }
        }

        private void PasswordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegistrationVM vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }

        private void PasswordBox2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegistrationVM vm)
            {
                vm.RepeatedPassword = ((PasswordBox)sender).Password;
            }
        }
    }
}
