using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class IngredientEntity : DoubleEntity
    {
        public override uint FirstId { get => DishId; set => DishId = value; }
        public override uint SecondId { get => ProductId; set => ProductId = value; }

        public virtual uint DishId { get; set; }
        [DisplayName("Блюдо")]
        [ColumnOrder(0)]
        public virtual string DishName { get; set; }
        public virtual uint ProductId { get; set; }
        [DisplayName("Продукт")]
        [ColumnOrder(1)]
        public virtual string ProductName { get; set; }
        [DisplayName("Вес брутто")]
        [ColumnOrder(2)]
        public virtual double Gross { get; set; }
        [DisplayName("Вес нетто")]
        [ColumnOrder(3)]
        public virtual double Net { get; set; }
        public virtual uint UnitId { get; set; }
        [DisplayName("Единица измерения")]
        [ColumnOrder(4)]
        public virtual string UnitName { get; set; }

        public IngredientEntity() { }

        public IngredientEntity(IngredientEntity info)
        {
            DishId = info.DishId;
            DishName = info.DishName;
            ProductId = info.ProductId;
            ProductName = info.ProductName;
            Gross = info.Gross;
            Net = info.Net;
            UnitId = info.UnitId;
            UnitName = info.UnitName;
        }
    }

    public class Ingredient : IngredientEntity
    {
        public Ingredient() { }

        public Ingredient(IngredientEntity info) : base(info) { }
    }
}
