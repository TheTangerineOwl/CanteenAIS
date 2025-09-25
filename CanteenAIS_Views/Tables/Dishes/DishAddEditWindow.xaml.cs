using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using CanteenAIS_ViewModel.EntityViewModels.Dish;
using CanteenAIS_ViewModel.EntityViewModels.Ingredient;
using Microsoft.SqlServer.Server;
using Microsoft.Win32;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CanteenAIS_Views.Tables.Dishes
{
    /// <summary>
    /// Логика взаимодействия для DishAddEditWindow.xaml
    /// </summary>
    public partial class DishAddEditWindow : Window
    {
        private readonly BasicActionVM<DishEntity, Dish> vm;
        public IngredientVM Subvm = new IngredientVM();

        public DishAddEditWindow(DishWindow parent, SimpleModel<DishEntity> model, bool editMode, DataRow row = null)
        {
            InitializeComponent();
            Owner = parent;
            if (!editMode)
            {
                vm = new DishAddVM(model);
                vm.OnApply += Add;
                idRow.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (row == null)
                    this.Close();
                vm = new DishEditVM(row, model);
                Subvm.DishId = vm.Fields.Id;
                Subvm.LoadForDish(Subvm.DishId);
                vm.OnApply += Edit;
                idRow.IsEnabled = false;
            }
            Subvm.OnAdd += AddIngredient;
            Subvm.OnEdit += EditIngredient;
            Subvm.OnDelete += DeleteIngredient;
            Subvm.OnExport += SubvmExportCsv;
            vm.OnCancel += Cancel;
            DataContext = vm;
            Subtable.DataContext = Subvm;
        }

        private void AddIngredient()
        {
            Subvm.SelectedIndex = -1;
            IngredientAddEditWindow addGroup = new IngredientAddEditWindow(this, Subvm, false);
            addGroup.ShowDialog();
        }

        private void EditIngredient(DataRow row)
        {
            //Subvm.DishId = vm.Fields.Id;
            IngredientAddEditWindow editGroup = new IngredientAddEditWindow(this, Subvm, true, row);
            editGroup.ShowDialog();
        }

        private void DeleteIngredient(DataRow row)
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
            if (vm is DishAddVM vmAdd)
            {
                try
                {
                    vmAdd.Add();
                    Subvm.AddTableToDB((uint)vmAdd.Id);
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
            if (vm is DishEditVM vmEdit)
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
            Subtable.HideInvisible<IngredientEntity>();
        }
    }
}
