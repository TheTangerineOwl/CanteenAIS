using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_Models.Management.Models;
using CanteenAIS_Models.Models;
using System;
using System.Windows.Input;

namespace CanteenAIS_ViewModel
{
    public class MainVM : PropChanged
    {
        public Action OnRegistration;
        public Action<DoubleModel<UserPermEntity>, uint> OnUserPerms;
        public Action OnChangePassword;
        public Action<uint> OnSQLquery;

        public Action<SimpleModel<AssortmentGroupEntity>, uint> OnAssortmentGroups;
        public Action<SimpleModel<BankEntity>, uint> OnBanks;
        public Action<SimpleModel<BranchEntity>, uint> OnBranches;
        public Action<SimpleModel<BranchOrderEntity>, uint> OnBranchOrders;
        public Action<SimpleModel<CityEntity>, uint> OnCities;
        public Action<SimpleModel<DishEntity>, uint> OnDishes;
        public Action<SimpleModel<MeasureUnitEntity>, uint> OnMeasureUnits;
        public Action<SimpleModel<SupplierHeadEntity>, uint> OnSupplierHeads;
        public Action<SimpleModel<SupplierEntity>, uint> OnSuppliers;
        public Action<SimpleModel<ProductEntity>, uint> OnProducts;
        public Action<SimpleModel<RealizationEntity>, uint> OnRealizations;
        public Action<SimpleModel<SupplyEntity>, uint> OnSupplies;
        public Action<SimpleModel<StreetEntity>, uint> OnStreets;

        public Action OnAboutProgram;
        public Action OnContent;
        public Action OnExit;

        public ICommand ClickExit
        {
            get => new Command((obj) =>
                {
                    OnExit?.Invoke();
                });
        }

        public ICommand ClickRegistration
        {
            get => new Command((obj) =>
                {
                    OnRegistration?.Invoke();
                });
        }

        public ICommand ClickUserPerms
        {
            get => new Command((obj) =>
                {
                    OnUserPerms?.Invoke(
                        new UserPermModel(DBContext.GetInstance().UserPerms),
                        MenuElementModel.GetCurrentMenuElemId(nameof(ClickUserPerms))
                    );
                });
        }

        public ICommand ClickChangePassword
        {
            get => new Command((obj) =>
                {
                    OnChangePassword?.Invoke();
                });
        }

        public ICommand ClickSQLquery
        {
            get => new Command((obj) =>
                {
                    OnSQLquery?.Invoke(MenuElementModel.GetCurrentMenuElemId(nameof(ClickSQLquery)));
                });
        }

        public ICommand ClickAssortmentGroups
        {
            get => new Command((obj) =>
                {
                    OnAssortmentGroups?.Invoke(
                        new AssortmentGroupModel(DBContext.GetInstance().AssortmentGroups),
                        MenuElementModel.GetCurrentMenuElemId(nameof(ClickAssortmentGroups))
                    );
                });
        }

        public ICommand ClickBanks
        {
            get => new Command((obj) =>
            {
                OnBanks?.Invoke(
                    new BankModel(DBContext.GetInstance().Banks),
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickBanks))
                );
            });
        }

        public ICommand ClickBranches
        {
            get => new Command((obj) =>
            {
                OnBranches?.Invoke(
                    new BranchModel(DBContext.GetInstance().Branches),
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickBranches))
                );
            });
        }

        public ICommand ClickBranchOrders
        {
            get => new Command((obj) =>
            {
                OnBranchOrders?.Invoke(
                    new BranchOrderModel(DBContext.GetInstance().BranchOrders),
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickBranchOrders))
                );
            });
        }

        public ICommand ClickCities
        {
            get => new Command((obj) =>
            {
                OnCities?.Invoke(
                    new CityModel(DBContext.GetInstance().Cities),
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickCities))
                );
            });
        }

        public ICommand ClickDishes
        {
            get => new Command((obj) =>
            {
                OnDishes?.Invoke(
                    new DishModel(DBContext.GetInstance().Dishes),
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickDishes))
                );
            });
        }

        public ICommand ClickMeasureUnits
        {
            get => new Command((obj) =>
            {
                OnMeasureUnits?.Invoke(
                    new MeasureUnitModel(DBContext.GetInstance().MeasureUnits),
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickMeasureUnits))
                );
            });
        }

        public ICommand ClickSupplierHeads
        {
            get => new Command((obj) =>
            {
                OnSupplierHeads?.Invoke(
                    new SupplierHeadModel(DBContext.GetInstance().SupplierHeads),
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickSupplierHeads))
                );
            });
        }

        public ICommand ClickSupplier
        {
            get => new Command((obj) =>
            {
                OnSuppliers?.Invoke(
                    new SupplierModel(DBContext.GetInstance().Suppliers),
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickSupplier))
                );
            });
        }

        public ICommand ClickProducts
        {
            get => new Command((obj) =>
            {
                OnProducts?.Invoke(
                    new ProductModel(DBContext.GetInstance().Products),
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickProducts))
                );
            });
        }

        public ICommand ClickRealizations
        {
            get => new Command((obj) =>
            {
                OnRealizations?.Invoke(
                    new RealizationModel(DBContext.GetInstance().Realizations),
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickRealizations))
                );
            });
        }

        public ICommand ClickSupplies
        {
            get => new Command((obj) =>
            {
                OnSupplies?.Invoke(
                    new SupplyModel(DBContext.GetInstance().Supplies),
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickSupplies))
                );
            });
        }

        public ICommand ClickStreets
        {
            get => new Command((obj) =>
            {
                OnStreets?.Invoke(
                    new StreetModel(DBContext.GetInstance().Streets),
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickStreets))
                );
            });
        }

        public ICommand ClickAbout
        {
            get => new Command((obj) =>
            {
                OnAboutProgram?.Invoke();
            });
        }

        public ICommand ClickContent
        {
            get
            {
                return new Command((obj) =>
                {
                    OnContent?.Invoke();
                });
            }
        }
    }
}
