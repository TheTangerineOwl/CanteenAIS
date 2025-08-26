using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class ProductEntity : SimpleEntity
    {
        [DisplayName("Имя")]
        public virtual string Name { get; set; }
        [DisplayName("Единица измерения")]
        public virtual string UnitName { get; set; }
        public virtual uint UnitId { get; set; }
        [DisplayName("Надбавка (%)")]
        public virtual decimal Markup { get; set; }
        [DisplayName("Остаток на складе")]
        public virtual double Stock { get; set; }
        [DisplayName("Поставщик")]
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
