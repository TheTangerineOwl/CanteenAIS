using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.AssortmentGroup;
using System.Windows;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_Views.Tables.AssortmentGroups
{
    /// <summary>
    /// Логика взаимодействия для AssortmentGroupFilterWindow.xaml
    /// </summary>
    public partial class AssortmentGroupFilterWindow : Window
    {
        public readonly BasicFilterVM<AssortmentGroupEntity, AssortmentGroup> vm;

        private readonly AssortmentGroupWindow _parent;

        public AssortmentGroupFilterWindow(AssortmentGroupWindow parent, SimpleModel<AssortmentGroupEntity> model)
        {
            InitializeComponent();
            _parent = parent;
            Owner = parent;

            vm = new AssortmentGroupFilterVM(model);
            vm.OnApply += Filter;
            vm.OnCancel += Cancel;
            DataContext = vm;
        }

        private void Filter()
        {
            vm.Filter();
            this.Close();
        }

        private void Cancel()
        {
            vm.Cancel();
            this.Close();
        }
    }
}
