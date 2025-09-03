using CanteenAIS_ViewModel;
using CanteenAIS_Views.Other;
using System.Windows;
using System.ComponentModel;
using CanteenAIS_Models;
using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Views.Tables.AssortmentGroups;
using CanteenAIS_Views.Tables.Banks;
using CanteenAIS_Views.Tables.BranchOrders;
using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_Views.Management.UserPerms;
using CanteenAIS_Views.Tables.Branches;
using CanteenAIS_Views.Tables.Cities;
using CanteenAIS_Views.Tables.Dishes;
using CanteenAIS_Views.Tables.MeasureUnits;
using CanteenAIS_Views.Tables.Products;
using CanteenAIS_Views.Tables.Realizations;
using CanteenAIS_Views.Tables.Streets;
using CanteenAIS_Views.Tables.SupplierHeads;
using CanteenAIS_Views.Tables.Suppliers;
using CanteenAIS_Views.Tables.Supplies;

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

            vm.OnUserPerms += ShowUserPerms;

            vm.OnAssortmentGroups += ShowAssortmentGroups;
            vm.OnBanks += ShowBanks;
            vm.OnBranches += ShowBranches;
            vm.OnBranchOrders += ShowBranchOrders;
            vm.OnCities += ShowCities;
            vm.OnDishes += ShowDishes;
            vm.OnMeasureUnits += ShowMeasureUnits;
            vm.OnProducts += ShowProducts;
            vm.OnRealizations += ShowRealizations;
            vm.OnStreets += ShowStreets;
            vm.OnSupplierHeads += ShowSupplierHeads;
            vm.OnSuppliers += ShowSuppliers;
            vm.OnSupplies += ShowSupplies;
        }

        private void ShowUserPerms(DoubleModel<UserPermEntity> model, uint elementId)
        {
            UserPermWindow perms = new UserPermWindow(model, elementId);
            perms.Show();
        }

        private void ShowSupplies(SimpleModel<SupplyEntity> model, uint elementId)
        {
            SupplyWindow supplies = new SupplyWindow(model, elementId);
            supplies.Show();
        }

        private void ShowSuppliers(SimpleModel<SupplierEntity> model, uint elementId)
        {
            SupplierWindow suppliers = new SupplierWindow(model, elementId);
            suppliers.Show();
        }

        private void ShowSupplierHeads(SimpleModel<SupplierHeadEntity> model, uint elementId)
        {
            SupplierHeadWindow heads = new SupplierHeadWindow(model, elementId);
            heads.Show();
        }

        private void ShowStreets(SimpleModel<StreetEntity> model, uint elementId)
        {
            StreetWindow streets = new StreetWindow(model, elementId);
            streets.Show();
        }

        private void ShowRealizations(SimpleModel<RealizationEntity> model, uint elementId)
        {
            RealizationWindow realizations = new RealizationWindow(model, elementId);
            realizations.Show();
        }

        private void ShowProducts(SimpleModel<ProductEntity> model, uint elementId)
        {
            ProductWindow products = new ProductWindow(model, elementId);
            products.Show();
        }

        private void ShowMeasureUnits(SimpleModel<MeasureUnitEntity> model, uint elementId)
        {
            MeasureUnitWindow units = new MeasureUnitWindow(model, elementId);
            units.Show();
        }

        private void ShowDishes(SimpleModel<DishEntity> model, uint elementId)
        {
            DishWindow dishes = new DishWindow(model, elementId);
            dishes.Show();
        }

        private void ShowCities(SimpleModel<CityEntity> model, uint elementId)
        {
            CityWindow cities = new CityWindow(model, elementId);
            cities.Show();
        }

        private void ShowBranches(SimpleModel<BranchEntity> model, uint elementId)
        {
            BranchWindow branches = new BranchWindow(model, elementId);
            branches.Show();
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

        private void ShowBranchOrders(SimpleModel<BranchOrderEntity> model, uint elementId)
        {
            BranchOrderWindow branchOrders = new BranchOrderWindow(model, elementId);
            branchOrders.Show();
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
