using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.AssortmentGroup;
using System.Windows;
using System;

namespace CanteenAIS_Views.Tables.AssortmentGroups
{
    /// <summary>
    /// Логика взаимодействия для AssortmentGroupAddWindow.xaml
    /// </summary>
    public partial class AssortmentGroupAddWindow : Window
    {
        private readonly AssortmentGroupAddVM vm;

        private readonly AssortmentGroupWindow _parent;

        public AssortmentGroupAddWindow(AssortmentGroupWindow parent, SimpleModel<AssortmentGroupEntity> model)
        {
            InitializeComponent();
            _parent = parent;
            Owner = parent;
            vm = new AssortmentGroupAddVM(model);
            vm.OnApply += Add;
            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        public void Add()
        {
            try
            {
                vm.Add();
                this.Close();
                _parent.UpdateTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                vm.Cancel();
            }
        }

        public void Cancel()
        {
            vm.Cancel();
            this.Close();
        }
    }
}
