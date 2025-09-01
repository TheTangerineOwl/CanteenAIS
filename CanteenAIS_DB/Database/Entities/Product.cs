using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class ProductEntity : SimpleEntity
    {
        [DisplayName("Имя")]
        [ColumnOrder(1)]
        public virtual string Name { get; set; }
        [DisplayName("Единица измерения")]
        [ColumnOrder(2)]
        public virtual string UnitName { get; set; }
        public virtual uint UnitId { get; set; }
        [DisplayName("Надбавка (%)")]
        [ColumnOrder(4)]
        public virtual decimal Markup { get; set; }
        [DisplayName("Остаток на складе")]
        [ColumnOrder(3)]
        public virtual double Stock { get; set; }
        [DisplayName("Поставщик")]
        [ColumnOrder(5)]
        public virtual string SupplierName { get; set; }
        public virtual uint SupplierId { get; set; }

        public ProductEntity() { }

        public ProductEntity(ProductEntity info)
        {
            Id = info.Id;
            Name = info.Name;
            UnitId = info.UnitId;
            UnitName = info.UnitName;
            Markup = info.Markup;
            Stock = info.Stock;
            SupplierId = info.SupplierId;
            SupplierName = info.SupplierName;
        }
    }

    public class Product : ProductEntity
    {
        public Product() { }

        public Product(ProductEntity info) : base(info) { }
    }
}
