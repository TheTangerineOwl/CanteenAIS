using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using CanteenAIS_DB.Database.Queries;
using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_DB.AppAuth.Queries;

namespace CanteenAIS_Models
{
    public class DBContext
    {
        private static DBContext instance;

        public UserEntity CurrentUser { get; set; }
        public BasicSimpleCRUD<UserEntity> Users { get; set; } = new UserDB();
        public BasicSimpleCRUD<MenuElementEntity> MenuElements { get; set; } = new MenuElementDB();
        public BasicDoubleCRUD<UserPermEntity> UserPerms { get; set; } = new UserPermDB();
        public BasicSimpleCRUD<BankEntity> Banks { get; set; } = new BankDB();
        public BasicSimpleCRUD<AssortmentGroupEntity> AssortmentGroups { get; set; } = new AssortmentGroupDB();
        public BasicSimpleCRUD<MeasureUnitEntity> MeasureUnits { get; set; } = new MeasureUnitDB();
        public BasicSimpleCRUD<RealizationEntity> Realizations { get; set; } = new RealizationDB();
        public BasicSimpleCRUD<DishEntity> Dishes { get; set; } = new DishDB();
        public BasicDoubleCRUD<IngredientEntity> Ingredients { get; set; } = new IngredientDB();
        public BasicSimpleCRUD<ProductEntity> Products { get; set; } = new ProductDB();
        public BasicSimpleCRUD<SupplierEntity> Suppliers { get; set; } = new SupplierDB();
        public BasicSimpleCRUD<SupplierHeadEntity> SupplierHeads { get; set; } = new SupplierHeadDB();
        public BasicSimpleCRUD<BranchEntity> Branches { get; set; } = new BranchDB();
        public BasicSimpleCRUD<BranchOrderEntity> BranchOrders { get; set; } = new BranchOrderDB();
        public BasicDoubleCRUD<OrderProductEntity> OrderProducts { get; set; } = new OrderProductDB();
        public BasicSimpleCRUD<CityEntity> Cities { get; set; } = new CityDB();
        public BasicSimpleCRUD<StreetEntity> Streets { get; set; } = new StreetDB();
        public BasicSimpleCRUD<SupplyEntity> Supplies { get; set; } = new SupplyDB();
        public BasicDoubleCRUD<SupplyProductEntity> SupplyProducts { get; set; } = new SupplyProductDB();

        private DBContext()
        {
            // УБРАТЬ
            CurrentUser = Users.Read<User>()[0];
        }

        public static DBContext GetInstance()
        {
            if (instance == null)
                instance = new DBContext();
            return instance;
        }
    }
}
