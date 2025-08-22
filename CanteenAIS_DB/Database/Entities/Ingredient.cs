namespace CanteenAIS_DB.Database.Entities
{
    public interface IIngredient
    {
        uint DishId { get; set; }
        uint ProductId { get; set; }
        double Gross { get; set; }  // брутто
        double Net { get; set; }  // нетто
        uint UnitId { get; set; }
        string UnitName { get; set; }
    }

    public class Ingredient : IIngredient
    {
        public uint DishId { get; set; }
        public string DishName { get; set; }
        public uint ProductId { get; set; }
        public string ProductName { get; set; }
        public double Gross { get; set; }  // брутто
        public double Net { get; set; }  // нетто
        public uint UnitId { get; set; }
        public string UnitName { get; set; }

        public Ingredient(
            uint dishId, string dishName,
            uint productId, string productName,
            double gross, double net,
            uint unitId, string unitName
        )
        {
            DishId = dishId;
            DishName = dishName;
            ProductId = productId;
            ProductName = productName;
            Gross = gross;
            Net = net;
            UnitId = unitId;
            UnitName = unitName;
        }

        public Ingredient(
            uint dishId, uint productId,
            double gross, double net,
            uint unitId
        )
        {
            DishId = dishId;
            ProductId = productId;
            Gross = gross;
            Net = net;
            UnitId = unitId;
        }
    }
}
