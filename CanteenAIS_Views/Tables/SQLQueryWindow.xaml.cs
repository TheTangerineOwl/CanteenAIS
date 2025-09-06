using CanteenAIS_ViewModel;
using System.Windows;
using System;

namespace CanteenAIS_Views.Tables
{
    /// <summary>
    /// Логика взаимодействия для SQLQueryWindow.xaml
    /// </summary>
    public partial class SQLQueryWindow : Window
    {
        private readonly SQLqueryVM vm;

        public SQLQueryWindow(uint elementId)
        {
            InitializeComponent();
            vm = new SQLqueryVM(elementId);
            vm.OnExecuteQuery += Execute;
            vm.OnClear += Clear;
            DataContext = vm;
        }

        public void Execute()
        {
            try
            {
                vm.Execute();
                if (!string.IsNullOrEmpty(vm.Exception))
                    MessageBox.Show(vm.Exception, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При выполнении запроса возникла следующая ошибка:\n" + ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Clear()
        {
            vm.Clear();
        }
    }
}
