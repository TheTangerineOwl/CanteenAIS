using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.MeasureUnit;
using System.Windows;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_Views.Tables.MeasureUnits
{
    /// <summary>
    /// Логика взаимодействия для MeasureUnitFilterWindow.xaml
    /// </summary>
    public partial class MeasureUnitFilterWindow : Window
    {
        public readonly BasicFilterVM<MeasureUnitEntity, MeasureUnit> vm;

        public MeasureUnitFilterWindow(MeasureUnitWindow parent, SimpleModel<MeasureUnitEntity> model)
        {
            InitializeComponent();
            Owner = parent;

            vm = new MeasureUnitFilterVM(model);
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
