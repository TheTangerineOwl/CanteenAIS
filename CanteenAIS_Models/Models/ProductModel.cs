using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class ProductModel : SimpleModel<ProductEntity>
    {
        public override string TableName => "Продукты";

        public ProductModel(BasicSimpleCRUD<ProductEntity> context) : base(context) { }

        public override void Add<TResult>(ProductEntity info)
        {
            TResult result = new TResult
            {
                Id = info.Id,
                Name = info.Name,
                UnitId = info.UnitId,
                UnitName = info.UnitName,
                Markup = info.Markup,
                Stock = info.Stock,
                SupplierId = info.SupplierId,
                SupplierName = info.SupplierName
            };
            TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, ProductEntity info)
        {
            TResult result = new TResult
            {
                Id = GetId(row),
                Name = info.Name,
                UnitId = info.UnitId,
                UnitName = info.UnitName,
                Markup = info.Markup,
                Stock = info.Stock,
                SupplierId = info.SupplierId,
                SupplierName = info.SupplierName
            };
            TableContext.Update(result);
        }

        public override int CompareEntities(ProductEntity first, ProductEntity second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.Id.CompareTo(second.Id);
            if (compared != 0) return compared;
            compared = string.Compare(first.Name, second.Name);
            if (compared != 0) return compared;
            compared = first.UnitId.CompareTo(second.UnitId);
            if (compared != 0) return compared;
            compared = first.Markup.CompareTo(second.Markup);
            if (compared != 0) return compared;
            compared = first.Stock.CompareTo(second.Stock);
            if (compared != 0) return compared;
            compared = first.SupplierId.CompareTo(second.SupplierId);
            if (compared != 0) return compared;
            return 0;
        }

        public override bool ContainsString(ProductEntity entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.Name.Contains(sample) ||
                entity.UnitName.Contains(sample) ||
                entity.Markup.ToString().Contains(sample) ||
                entity.Stock.ToString().Contains(sample) ||
                entity.SupplierName.Contains(sample)
            );
        }
    }
}
