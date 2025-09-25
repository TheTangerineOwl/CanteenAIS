using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class OrderProductEntity : DoubleEntity
    {
        [ColumnDisplay("OrderId", false, 0)]
        public override uint FirstId { get => OrderId; set => OrderId = value; }
        [ColumnDisplay("ProductId", false, 0)]
        public override uint SecondId { get => ProductId; set => ProductId = value; }

        [ColumnDisplay("Заказ", true, 0)]
        public virtual uint OrderId { get; set; }
        [ColumnDisplay("Продукт")]
        public uint ProductId { get; set; }
        [ColumnDisplay("Продукт", true, 1)]
        public string ProductName { get; set; }
        [ColumnDisplay("Единица")]
        public uint UnitId { get; set; }
        [ColumnDisplay("Единица измерения", true, 3)]
        public string UnitName { get; set; }
        [ColumnDisplay("Объем", true, 2)]
        public double Amount { get; set; }

        public OrderProductEntity() { }

        public OrderProductEntity(OrderProductEntity info)
        {
            OrderId = info.OrderId;
            ProductId = info.ProductId;
            ProductName = info.ProductName;
            UnitId = info.UnitId;
            UnitName = info.UnitName;
            Amount = info.Amount;
        }

        public override string ToString()
        {
            return $"{OrderId}, {ProductName}";
        }
    }

    public class OrderProduct : OrderProductEntity
    {
        public OrderProduct() { }

        public OrderProduct(OrderProductEntity info) : base(info) { }
    }
}
