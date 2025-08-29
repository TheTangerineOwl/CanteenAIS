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
                        MainServices.GetInstance().UserPerms,
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
                        MainServices.GetInstance().AssortmentGroups,
                        MenuElementModel.GetCurrentMenuElemId(nameof(ClickAssortmentGroups))
                    );
                });
        }

        public ICommand ClickBanks
        {
            get => new Command((obj) =>
            {
                OnBanks?.Invoke(
                    MainServices.GetInstance().Banks,
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickBanks))
                );
            });
        }

        public ICommand ClickBranches
        {
            get => new Command((obj) =>
            {
                OnBranches?.Invoke(
                    MainServices.GetInstance().Branches,
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickBranches))
                );
            });
        }

        public ICommand ClickBranchOrders
        {
            get => new Command((obj) =>
            {
                OnBranchOrders?.Invoke(
                    MainServices.GetInstance().BranchOrders,
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickBranchOrders))
                );
            });
        }

        public ICommand ClickCities
        {
            get => new Command((obj) =>
            {
                OnCities?.Invoke(
                    MainServices.GetInstance().Cities,
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickCities))
                );
            });
        }

        public ICommand ClickDishes
        {
            get => new Command((obj) =>
            {
                OnDishes?.Invoke(
                    MainServices.GetInstance().Dishes,
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickDishes))
                );
            });
        }

        public ICommand ClickMeasureUnits
        {
            get => new Command((obj) =>
            {
                OnMeasureUnits?.Invoke(
                    MainServices.GetInstance().MeasureUnits,
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickMeasureUnits))
                );
            });
        }

        public ICommand ClickSupplierHeads
        {
            get => new Command((obj) =>
            {
                OnSupplierHeads?.Invoke(
                    MainServices.GetInstance().SupplierHeads,
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickSupplierHeads))
                );
            });
        }

        public ICommand ClickSupplier
        {
            get => new Command((obj) =>
            {
                OnSuppliers?.Invoke(
                    MainServices.GetInstance().Suppliers,
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickSupplier))
                );
            });
        }

        public ICommand ClickProducts
        {
            get => new Command((obj) =>
            {
                OnProducts?.Invoke(
                    MainServices.GetInstance().Products,
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickProducts))
                );
            });
        }

        public ICommand ClickRealizations
        {
            get => new Command((obj) =>
            {
                OnRealizations?.Invoke(
                    MainServices.GetInstance().Realizations,
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickRealizations))
                );
            });
        }

        public ICommand ClickSupplies
        {
            get => new Command((obj) =>
            {
                OnSupplies?.Invoke(
                    MainServices.GetInstance().Supplies,
                    MenuElementModel.GetCurrentMenuElemId(nameof(ClickSupplies))
                );
            });
        }

        public ICommand ClickStreets
        {
            get => new Command((obj) =>
            {
                OnStreets?.Invoke(
                    MainServices.GetInstance().Streets,
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
            get => new Command((obj) =>
            {
                    OnContent?.Invoke();
            });
        }
    }
}
