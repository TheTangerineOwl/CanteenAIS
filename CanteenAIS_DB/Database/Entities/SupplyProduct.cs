using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class SupplyProductEntity : DoubleEntity
    {
        public override uint FirstId { get => SupplyId; set => SupplyId = value; }
        public override uint SecondId { get => ProductId; set => ProductId = value; }

        public virtual uint SupplyId { get; set; }
        public virtual uint ProductId { get; set; }
        [DisplayName("Продукт")]
        [ColumnOrder(1)]
        public virtual string ProductName { get; set; }
        public virtual uint UnitId { get; set; }
        [DisplayName("Единица измерения")]
        [ColumnOrder(2)]
        public virtual string UnitName { get; set; }
        [DisplayName("Закупочная цена")]
        [ColumnOrder(3)]
        public virtual decimal Price { get; set; }
        [DisplayName("Количество")]
        [ColumnOrder(4)]
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
    }

    public class SupplyProduct : SupplyProductEntity
    {
        public SupplyProduct() { }

        public SupplyProduct(SupplyProductEntity info) : base(info) { }
    }
}
