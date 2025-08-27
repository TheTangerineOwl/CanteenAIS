using CanteenAIS_ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CanteenAIS_Views
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private readonly Window parent;
        private readonly MainVM vm;

        public MainMenu(Window parentWindow)
        {
            parent = parentWindow;
            vm = new MainVM();

            InitializeComponent();

            MenuConstructor constructor = new MenuConstructor(vm);
            mainMenu.Children.Add(constructor.Construct());

            vm.OnExit += CloseWindow;
        }

        private void CloseWindow()
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.Show();
        }
    }
}
