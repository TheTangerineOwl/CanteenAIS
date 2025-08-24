using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenAIS_Models.Models
{
    public class ProductModel : SimpleModel<IProduct, ProductInfo>
    {
        public override string TableName => "Продукты";

        public ProductModel(BasicSimpleCRUD<IProduct> context) : base(context) { }

        public override void Add(ProductInfo info)
        {
            TableContext.Create(new Product(info));
        }

        public override void Update(DataRow row, ProductInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new Product(info));
        }

        public override int CompareEntities(IProduct first, IProduct second)
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

        public override bool ContainsString(IProduct entity, string sample)
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
