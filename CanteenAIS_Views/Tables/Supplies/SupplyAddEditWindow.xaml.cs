using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using CanteenAIS_ViewModel.EntityViewModels.Supply;
using CanteenAIS_ViewModel.EntityViewModels.SupplyProduct;
using Microsoft.Win32;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.Tables.Supplies
{
    /// <summary>
    /// Логика взаимодействия для SupplyAddEditWindow.xaml
    /// </summary>
    public partial class SupplyAddEditWindow : Window
    {
        private readonly BasicActionVM<SupplyEntity, Supply> vm;
        public SupplyProductVM Subvm = new SupplyProductVM();

        public SupplyAddEditWindow(SupplyWindow parent, SimpleModel<SupplyEntity> model, bool editMode, DataRow row = null)
        {
            InitializeComponent();
            Owner = parent;
            if (!editMode)
            {
                vm = new SupplyAddVM(model);
                vm.OnApply += Add;
            }
            else
            {
                if (row == null)
                    this.Close();
                vm = new SupplyEditVM(row, model);
                Subvm.SupplyId = vm.Fields.Id;
                Subvm.LoadForSupply(Subvm.SupplyId);
                vm.OnApply += Edit;
                idRow.IsEnabled = false;
            }
            Subvm.OnAdd += AddSupplyProduct;
            Subvm.OnEdit += EditSupplyProduct;
            Subvm.OnDelete += DeleteSupplyProduct;
            Subvm.OnExport += SubvmExportCsv;
            vm.OnCancel += Cancel;
            DataContext = vm;
            Subtable.DataContext = Subvm;
        }

        private void AddSupplyProduct()
        {
            Subvm.SelectedIndex = -1;
            SupplyProductAddEditWindow addGroup = new SupplyProductAddEditWindow(this, Subvm, false);
            addGroup.ShowDialog();
        }

        private void EditSupplyProduct(DataRow row)
        {
            SupplyProductAddEditWindow editGroup = new SupplyProductAddEditWindow(this, Subvm, true, row);
            editGroup.ShowDialog();
        }

        private void DeleteSupplyProduct(DataRow row)
        {
            MessageBoxResult dr = MessageBox.Show("Удалить запись?", "Удаление данных", MessageBoxButton.YesNo);
            if (dr == MessageBoxResult.Yes)
                Subvm.DeleteRow(row);
        }

        public void SubvmExportCsv(string format)
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
                    Subvm.ExportCsv(file, format);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Add()
        {
            if (vm is SupplyAddVM vmAdd)
            {
                try
                {
                    vmAdd.Add();
                    Subvm.AddTableToDB(vm.Fields.Id);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    vmAdd.Cancel();
                }
            }
        }

        private void Edit()
        {
            if (vm is SupplyEditVM vmEdit)
            {
                try
                {
                    vmEdit.Edit();
                    Subvm.EditTableInDB(vm.Fields.Id);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    vmEdit.Cancel();
                }
            }
        }

        private void Cancel()
        {
            vm.Cancel();
            this.Close();
        }

        private void Subtable_GridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Subvm.HasSelectedRow = Subtable.SelectedIndex != -1;
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            Subtable.HideInvisible<SupplyProduct>();
        }
    }
}
