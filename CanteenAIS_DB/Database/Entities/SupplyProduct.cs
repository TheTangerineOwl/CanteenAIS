using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class SupplyProductEntity : DoubleEntity
    {
        [ColumnDisplay("SupplyId", false, 0)]
        public override uint FirstId { get => SupplyId; set => SupplyId = value; }
        [ColumnDisplay("ProductId", false, 0)]
        public override uint SecondId { get => ProductId; set => ProductId = value; }

        [ColumnDisplay("Id поставки", true, 0)]
        public virtual uint SupplyId { get; set; }
        [ColumnDisplay("Продукт_Id")]
        public virtual uint ProductId { get; set; }
        [ColumnDisplay("Продукт", true, 1)]
        public virtual string ProductName { get; set; }
        [ColumnDisplay("Единица_Id")]
        public virtual uint UnitId { get; set; }
        [ColumnDisplay("Единица измерения", true, 2)]
        public virtual string UnitName { get; set; }
        [ColumnDisplay("Закупочная цена", true, 3)]
        public virtual decimal Price { get; set; }
        [ColumnDisplay("Количество", true, 4)]
        public virtual double Amount { get; set; }

        public SupplyProductEntity() { }

        public SupplyProductEntity(SupplyProductEntity info)
        {
            SupplyId = info.SupplyId;
            ProductId = info.ProductId;
            ProductName = info.ProductName;
            UnitId = info.UnitId;
            UnitName = info.UnitName;
            Price = info.Price;
            Amount = info.Amount;
        }

        public override string ToString()
        {
            return $"{SupplyId}, {ProductName}";
        }
    }

    public class SupplyProduct : SupplyProductEntity
    {
        public SupplyProduct() { }

        public SupplyProduct(SupplyProductEntity info) : base(info) { }
    }
}
