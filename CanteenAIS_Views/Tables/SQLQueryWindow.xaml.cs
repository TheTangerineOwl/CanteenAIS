using CanteenAIS_ViewModel;
using System.Windows;
using System;
using Microsoft.Win32;

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
            vm.OnExport += ExportCsv;
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

        public void ExportCsv(string format)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    AddExtension = true,
                    CheckPathExists = true,
                    CreatePrompt = true,
                    OverwritePrompt = true,
                };
                if (format == "Word")
                {
                    dialog.DefaultExt = "*.docx";
                    dialog.Filter = "Microsoft Office Word files (*.docx;*.doc)|*.docx;*.doc|All files (*.*)|*.*";
                }
                else if (format == "Excel")
                {
                    dialog.DefaultExt = "*.xlsx";
                    dialog.Filter = "Microsoft Office Excel files (*.xls, *.xlsx)|*.xlsx;*xls|All files (*.*)|*.*";
                }
                else
                {
                    dialog.DefaultExt = "*.csv";
                    dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                }
                if (dialog.ShowDialog() == true)
                {
                    string file = dialog.FileName;
                    vm.ExportCsv(file, format);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
