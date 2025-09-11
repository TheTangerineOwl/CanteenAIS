using CanteenAIS_Views;
using System.Windows;

namespace CanteenAIS
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// Входная точка приложения.
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            LoginWindow login = new LoginWindow();
            login.Show();
        }
    }
}
