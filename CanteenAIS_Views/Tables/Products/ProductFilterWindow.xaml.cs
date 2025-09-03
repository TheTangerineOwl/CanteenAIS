using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.EntityViewModels.Product;
using System.Windows;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_Views.Tables.Products
{
    /// <summary>
    /// Логика взаимодействия для ProductFilterWindow.xaml
    /// </summary>
    public partial class ProductFilterWindow : Window
    {
        public readonly BasicFilterVM<ProductEntity, Product> vm;

        public ProductFilterWindow(ProductWindow parent, SimpleModel<ProductEntity> model)
        {
            InitializeComponent();
            Owner = parent;

            vm = new ProductFilterVM(model);
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
