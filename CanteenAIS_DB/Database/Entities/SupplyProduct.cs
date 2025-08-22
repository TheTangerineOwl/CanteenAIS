using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface ISupplyProduct
    {
        uint SupplyId { get; set; }
        uint ProductId { get; set; }
        [DisplayName("Продукт")]
        string ProductName { get; set; }
        uint UnitId { get; set; }
        [DisplayName("Единица измерения")]
        string UnitName { get; set; }
        [DisplayName("Закупочная цена")]
        decimal Price { get; set; }
        [DisplayName("Количество")]
        double Amount { get; set; }
    }

    public class SupplyProduct : ISupplyProduct
    {
        public uint SupplyId { get; set; }
        public uint ProductId { get; set; }
        public string ProductName { get; set; }
        public uint UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal Price { get; set; }
        public double Amount { get; set; }

        public SupplyProduct(
            uint supplyId,
            uint productId, string productName,
            uint unitId, string unitName,
            decimal price, double amount
        )
        {
            SupplyId = supplyId;
            ProductId = productId;
            ProductName = productName;
            UnitId = unitId;
            UnitName = unitName;
            Price = price;
            Amount = amount;
        }

        public SupplyProduct(
            uint supplyId, uint productId,
            uint unitId,decimal price, double amount
        )
        {
            SupplyId = supplyId;
            ProductId = productId;
            UnitId = unitId;
            Price = price;
            Amount = amount;
        }
    }
}
