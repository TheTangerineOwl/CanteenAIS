using CanteenAIS_ViewModel;
using CanteenAIS_Views.Other;
using System.Windows;
using System.ComponentModel;
using CanteenAIS_Models;
using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Views.Tables.AssortmentGroups;
using CanteenAIS_Views.Tables.Banks;

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

            vm.OnAboutProgram += ShowAbout;
            vm.OnContent += ShowContents;
            vm.OnExit += CloseWindow;

            vm.OnAssortmentGroups += ShowAssortmentGroups;
            vm.OnBanks += ShowBanks;
        }

        private void ShowAssortmentGroups(SimpleModel<AssortmentGroupEntity> model, uint elementId)
        {
            AssortmentGroupWindow groups = new AssortmentGroupWindow(model, elementId);
            groups.Show();
        }

        private void ShowBanks(SimpleModel<BankEntity> model, uint elementId)
        {
            BankWindow banks = new BankWindow(model, elementId);
            banks.Show();
        }

        private void ShowContents()
        {
            ContentWindow content = new ContentWindow { Owner = this };
            content.Show();
        }

        private void ShowAbout()
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
            foreach (Window w in OwnedWindows)
                w.Close();
            parent.Show();
        }
    }
}
