using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class ProductEntity : SimpleEntity
    {
        [ColumnDisplay("Имя", true, 1)]
        public virtual string Name { get; set; }
        [ColumnDisplay("Единица измерения", true, 2)]
        public virtual string UnitName { get; set; }
        public virtual uint UnitId { get; set; }
        [ColumnDisplay("Надбавка (%)", true, 4)]
        public virtual decimal Markup { get; set; }
        [ColumnDisplay("Остаток на складе", true, 3)]
        public virtual double Stock { get; set; }
        [ColumnDisplay("Поставщик", true, 5)]
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

        public override string ToString()
        {
            return Name;
        }
    }

    public class Product : ProductEntity
    {
        public Product() { }

        public Product(ProductEntity info) : base(info) { }
    }
}
