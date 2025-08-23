using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IProduct : ISimpleEntity
    {
        [DisplayName("Имя")]
        string Name { get; set; }
        [DisplayName("Единица измерения")]
        string UnitName { get; set; }
        uint UnitId { get; set; }
        [DisplayName("Надбавка (%)")]
        decimal Markup { get; set; }
        [DisplayName("Остаток на складе")]
        double Stock { get; set; }
        [DisplayName("Поставщик")]
        string SupplierName { get; set; }
        uint SupplierId { get; set; }
    }

    public class ProductInfo : SimpleInfo
    {
        public string name;
        public uint unitId;
        public string unitName;
        public decimal markup;
        public double stock;
        public uint supplierId;
        public string supplierName;
    }

    public class Product : IProduct
    {
        private readonly ProductInfo _info;
        public uint Id { get => _info.id; set => _info.id = value; }
        public string Name { get => _info.name; set => _info.name = value; }
        public uint UnitId { get => _info.unitId; set => _info.unitId = value; }
        public string UnitName { get => _info.unitName; set => _info.unitName = value; }
        public decimal Markup { get => _info.markup; set => _info.markup = value; }
        public double Stock { get => _info.stock; set => _info.stock = value; }
        public uint SupplierId { get => _info.supplierId; set => _info.supplierId = value; }
        public string SupplierName { get => _info.supplierName; set => _info.supplierName = value; }

        public Product(ProductInfo info)
        {
            _info = info;
        }
    }
}
