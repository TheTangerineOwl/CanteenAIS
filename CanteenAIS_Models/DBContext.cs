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

        public IUser CurrentUser { get; set; }
        public BasicSimpleCRUD<IUser> Users { get; set; } = new UserDB();
        public BasicSimpleCRUD<IMenuElement> MenuElements { get; set; } = new MenuElementDB();
        public BasicDoubleCRUD<IUserPerm> UserPerms { get; set; } = new UserPermDB();
        public BasicSimpleCRUD<IBank> Banks { get; set; } = new BankDB();
        public BasicSimpleCRUD<IAssortmentGroup> AssortmentGroups { get; set; } = new AssortmentGroupDB();
        public BasicSimpleCRUD<IMeasureUnit> MeasureUnits { get; set; } = new MeasureUnitDB();
        public BasicSimpleCRUD<IRealization> Realizations { get; set; } = new RealizationDB();
        public BasicSimpleCRUD<IDish> Dishes { get; set; } = new DishDB();
        public BasicDoubleCRUD<IIngredient> Ingredients { get; set; } = new IngredientDB();
        public BasicSimpleCRUD<IProduct> Products { get; set; } = new ProductDB();
        public BasicSimpleCRUD<ISupplier> Suppliers { get; set; } = new SupplierDB();
        public BasicSimpleCRUD<ISupplierHead> SupplierHeads { get; set; } = new SupplierHeadDB();
        public BasicSimpleCRUD<IBranch> Branches { get; set; } = new BranchDB();
        public BasicSimpleCRUD<IBranchOrder> BranchOrders { get; set; } = new BranchOrderDB();
        public BasicDoubleCRUD<IOrderProduct> OrderProducts { get; set; } = new OrderProductDB();
        public BasicSimpleCRUD<ICity> Cities { get; set; } = new CityDB();
        public BasicSimpleCRUD<IStreet> Streets { get; set; } = new StreetDB();
        public BasicSimpleCRUD<ISupply> Supplies { get; set; } = new SupplyDB();
        public BasicDoubleCRUD<ISupplyProduct> SupplyProducts { get; set; } = new SupplyProductDB();

        private DBContext()
        {
            // УБРАТЬ
            CurrentUser = Users.Read()[0];
        }

        public static DBContext GetInstance()
        {
            if (instance == null)
                instance = new DBContext();
            return instance;
        }
    }
}
