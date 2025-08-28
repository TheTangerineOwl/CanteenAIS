using CanteenAIS_ViewModel;
using CanteenAIS_Views.Other;
using System.Windows;
using System.ComponentModel;

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

            vm.OnAboutProgram += About;
            vm.OnContent += Contents;
            vm.OnExit += CloseWindow;


        }

        private void Contents()
        {
            ContentWindow content = new ContentWindow { Owner = this };
            content.Show();
        }

        private void About()
        {
            AboutWindow about = new AboutWindow { Owner = this };
            about.Show();
        }

        private void CloseWindow()
        {
            this.Close();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            parent.Show();
        }
    }
}
