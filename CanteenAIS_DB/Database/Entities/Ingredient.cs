namespace CanteenAIS_DB.Database.Entities
{
    public interface IIngredient : IDoubleEntity
    {
        uint DishId { get; set; }
        uint ProductId { get; set; }
        double Gross { get; set; }  // брутто
        double Net { get; set; }  // нетто
        uint UnitId { get; set; }
        string UnitName { get; set; }
    }

    public class IngredientInfo : DoubleInfo
    {
        public uint DishId { get => firstId; set => firstId = value; }
        public uint ProductId { get => secondId; set => secondId = value; }
        public string dishName;
        public string productName;
        public double gross;
        public double net;
        public uint unitId;
        public string unitName;
    }

    public class Ingredient : IIngredient
    {
        private readonly IngredientInfo _info;
        public uint DishId { get => _info.DishId; set => _info.DishId = value; }
        public string DishName { get => _info.dishName; set => _info.dishName = value; }
        public uint ProductId { get => _info.ProductId; set => _info.ProductId = value; }
        public string ProductName { get => _info.productName; set => _info.productName = value; }
        public double Gross { get => _info.gross; set => _info.gross = value; }  // брутто
        public double Net { get => _info.net; set => _info.net = value; }  // нетто
        public uint UnitId { get => _info.unitId; set => _info.unitId = value; }
        public string UnitName { get => _info.unitName; set => _info.unitName = value; }

        public uint FirstId { get => DishId; set => DishId = value; }
        public uint SecondId { get => ProductId; set => ProductId = value; }

        public Ingredient(IngredientInfo info)
        {
            _info = info;
        }
    }
}
