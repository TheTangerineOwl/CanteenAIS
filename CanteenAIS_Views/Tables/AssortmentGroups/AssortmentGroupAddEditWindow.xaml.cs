using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.AssortmentGroup;
using System.Windows;
using System;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;

namespace CanteenAIS_Views.Tables.AssortmentGroups
{
    /// <summary>
    /// Логика взаимодействия для AssortmentGroupAddEditWindow.xaml
    /// </summary>
    public partial class AssortmentGroupAddEditWindow : Window
    {
        //private readonly AssortmentGroupAddVM vm;
        private readonly BasicActionVM<AssortmentGroupEntity, AssortmentGroup> vm;

        public AssortmentGroupAddEditWindow(AssortmentGroupWindow parent, SimpleModel<AssortmentGroupEntity> model, bool editMode, DataRow row = null)
        {
            InitializeComponent();
            Owner = parent;
            if (!editMode)
            {
                vm = new AssortmentGroupAddVM(model);
                vm.OnApply += Add;
                idRow.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (row == null)
                    this.Close();
                vm = new AssortmentGroupEditVM(row, model);
                vm.OnApply += Edit;
            }

            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        private void Add()
        {
            if (vm is AssortmentGroupAddVM vmAdd)
            {
                try
                {
                    vmAdd.Add();
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
            if (vm is AssortmentGroupEditVM vmEdit)
            {
                try
                {
                    vmEdit.Edit();
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
    }
}
