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
    public class SupplyProductModel : DoubleModel<ISupplyProduct, SupplyProductInfo>
    {
        public override string TableName => "Банки";

        public SupplyProductModel(BasicDoubleCRUD<ISupplyProduct> context) : base(context) { }

        public override void Add(SupplyProductInfo info)
        {
            TableContext.Create(new SupplyProduct(info));
        }

        public override void Update(DataRow row, SupplyProductInfo info)
        {
            (info.SupplyId, info.ProductId) = GetPK(row);
            TableContext.Update(new SupplyProduct(info));
        }

        public override int CompareEntities(ISupplyProduct first, ISupplyProduct second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.SupplyId.CompareTo(second.ProductId);
            if (compared != 0) return compared;
            compared = first.ProductId.CompareTo(second.ProductId);
            if (compared != 0) return compared;
            compared = first.Amount.CompareTo(second.Amount);
            if (compared != 0) return compared;
            compared = first.UnitId.CompareTo(second.UnitId);
            if (compared != 0) return compared;
            compared = first.Price.CompareTo(second.Price);
            return compared;
        }

        public override bool ContainsString(ISupplyProduct entity, string sample)
        {
            return (
                entity.SupplyId.ToString().Contains(sample) ||
                entity.ProductName.Contains(sample) ||
                entity.Amount.ToString().Contains(sample) ||
                entity.UnitName.Contains(sample) ||
                entity.Price.ToString().Contains(sample)
            );
        }
    }
}
