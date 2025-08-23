namespace CanteenAIS_DB.Database.Entities
{
    public interface IOrderProduct : IDoubleEntity
    {
        uint OrderId { get; set; }
        uint ProductId { get; set; }
        string ProductName { get; set; }
        uint UnitId { get; set; }
        string UnitName { get; set; }
        double Amount { get; set; }
    }

    public class OrderProductInfo : DoubleInfo
    {
        public uint OrderId { get => firstId; set => firstId = value; }
        public uint ProductId { get => secondId; set => secondId = value; }
        public string productName;
        public uint unitId;
        public string unitName;
        public double amount;
    }

    public class OrderProduct : IOrderProduct
    {
        private readonly OrderProductInfo _info;
        public uint OrderId { get => _info.OrderId; set => _info.OrderId = value; }
        public uint ProductId { get => _info.secondId; set => _info.secondId = value; }
        public string ProductName { get => _info.productName; set => _info.productName = value; }
        public uint UnitId { get => _info.unitId; set => _info.unitId = value; }
        public string UnitName { get => _info.unitName; set => _info.unitName = value; }
        public double Amount { get => _info.amount; set => _info.amount = value; }
        public uint FirstId { get => OrderId; set => OrderId = value; }
        public uint SecondId { get => ProductId; set => ProductId = value; }

        public OrderProduct(OrderProductInfo info)
        {
            _info = info;
        }
    }
}
