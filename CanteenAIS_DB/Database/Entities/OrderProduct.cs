namespace CanteenAIS_DB.Database.Entities
{
    public interface IOrderProduct
    {
        uint OrderId { get; set; }
        uint ProductId { get; set; }
        string ProductName { get; set; }
        uint UnitId { get; set; }
        string UnitName { get; set; }
        double Amount { get; set; }
    }

    public class OrderProduct : IOrderProduct
    {
        public uint OrderId { get; set; }
        public uint ProductId { get; set; }
        public string ProductName { get; set; }
        public uint UnitId { get; set; }
        public string UnitName { get; set; }
        public double Amount { get; set; }

        public OrderProduct(
            uint orderId, uint productId, string productName,
            uint unitId, string unitName, double amount
        )
        {
            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
            UnitId = unitId;
            UnitName = unitName;
            Amount = amount;
        }

        public OrderProduct(uint branchOrderId, uint productId,
            uint unitId,double amount)
        {
            OrderId = branchOrderId;
            ProductId = productId;
            UnitId = unitId;
            Amount = amount;
        }
    }
}
