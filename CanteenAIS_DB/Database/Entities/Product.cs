using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IProduct
    {
        [DisplayName("Id")]
        uint Id { get; set; }
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

    public class Product : IProduct
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint UnitId { get; set; }
        public string UnitName { get;set; }
        public decimal Markup { get; set; }
        public double Stock { get; set; }
        public uint SupplierId { get; set; }

        public string SupplierName { get; set; }

        public Product(
            uint id, string name,
            uint unitId, string unitName,
            decimal markup, double stock,
            uint supplierId, string supplierName
        )
        {
            Id = id;
            Name = name;
            UnitId = unitId;
            UnitName = unitName;
            Markup = markup;
            Stock = stock;
            SupplierId = supplierId;
            SupplierName = supplierName;
        }

        public Product(
            string name, uint unitId,
            decimal markup, double stock, uint supplierId
        )
        {
            Name = name;
            UnitId = unitId;
            Markup = markup;
            Stock = stock;
            SupplierId = supplierId;
        }
    }
}
