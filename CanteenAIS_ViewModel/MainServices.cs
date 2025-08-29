using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_Models.Management.Models;
using CanteenAIS_Models.Models;

namespace CanteenAIS_ViewModel
{
    public class MainServices
    {
        private static MainServices instance;
        public SimpleModel<UserEntity> Users { get; set; }
            = new UserModel(DBContext.GetInstance().Users);
        public DoubleModel<UserPermEntity> UserPerms { get; set; }
            = new UserPermModel(DBContext.GetInstance().UserPerms);
        public SimpleModel<BankEntity> Banks { get; set; }
            = new BankModel(DBContext.GetInstance().Banks);
        public SimpleModel<AssortmentGroupEntity> AssortmentGroups { get; set; }
            = new AssortmentGroupModel(DBContext.GetInstance().AssortmentGroups);
        public SimpleModel<MeasureUnitEntity> MeasureUnits { get; set; }
            = new MeasureUnitModel(DBContext.GetInstance().MeasureUnits);
        public SimpleModel<RealizationEntity> Realizations { get; set; }
            = new RealizationModel(DBContext.GetInstance().Realizations);
        public SimpleModel<DishEntity> Dishes { get; set; }
            = new DishModel(DBContext.GetInstance().Dishes);
        public DoubleModel<IngredientEntity> Ingredients { get; set; }
            = new IngredientModel(DBContext.GetInstance().Ingredients);
        public SimpleModel<ProductEntity> Products { get; set; }
            = new ProductModel(DBContext.GetInstance().Products);
        public SimpleModel<SupplierEntity> Suppliers { get; set; }
            = new SupplierModel(DBContext.GetInstance().Suppliers);
        public SimpleModel<SupplierHeadEntity> SupplierHeads { get; set; }
            = new SupplierHeadModel(DBContext.GetInstance().SupplierHeads);
        public SimpleModel<BranchEntity> Branches { get; set; }
            = new BranchModel(DBContext.GetInstance().Branches);
        public SimpleModel<BranchOrderEntity> BranchOrders { get; set; }
            = new BranchOrderModel(DBContext.GetInstance().BranchOrders);
        public DoubleModel<OrderProductEntity> OrderProducts { get; set; }
            = new OrderProductModel(DBContext.GetInstance().OrderProducts);
        public SimpleModel<CityEntity> Cities { get; set; }
            = new CityModel(DBContext.GetInstance().Cities);
        public SimpleModel<StreetEntity> Streets { get; set; }
            = new StreetModel(DBContext.GetInstance().Streets);
        public SimpleModel<SupplyEntity> Supplies { get; set; }
            = new SupplyModel(DBContext.GetInstance().Supplies);
        public DoubleModel<SupplyProductEntity> SupplyProducts { get; set; }
            = new SupplyProductModel(DBContext.GetInstance().SupplyProducts);

        public static MainServices GetInstance()
        {
            if (instance == null)
                instance = new MainServices();
            return instance;
        }
    }
}
