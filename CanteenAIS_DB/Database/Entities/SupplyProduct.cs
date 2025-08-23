using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface ISupplyProduct : IDoubleEntity
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

    public class SupplyProductInfo : DoubleInfo
    {
        public uint SupplyId { get => firstId; set => firstId = value; }
        public uint ProductId { get => secondId; set => secondId = value; }
        public string productName;
        public uint unitId;
        public string unitName;
        public decimal price;
        public double amount;
    }

    public class SupplyProduct : ISupplyProduct
    {
        private readonly SupplyProductInfo _info;
        public uint SupplyId { get => _info.SupplyId; set => _info.SupplyId = value; }
        public uint ProductId { get => _info.ProductId; set => _info.ProductId = value; }
        public string ProductName { get => _info.productName; set => _info.productName = value; }
        public uint UnitId { get => _info.unitId; set => _info.unitId = value; }
        public string UnitName { get => _info.unitName; set => _info.unitName = value; }
        public decimal Price { get => _info.price; set => _info.price = value; }
        public double Amount { get => _info.amount; set => _info.amount = value; }
        public uint FirstId { get => SupplyId; set => SupplyId = value; }
        public uint SecondId { get => ProductId; set => ProductId = value; }

        public SupplyProduct(SupplyProductInfo info)
        {
            _info = info;
        }
    }
}
