using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class SupplyProductModel : DoubleModel<SupplyProductEntity>
    {
        public override string TableName => "Банки";

        public SupplyProductModel(BasicDoubleCRUD<SupplyProductEntity> context) : base(context) { }

        public override void Add<TResult>(SupplyProductEntity info)
        {
            TResult result = new TResult
            {
                SupplyId = info.SupplyId,
                ProductId = info.ProductId,
                ProductName = info.ProductName,
                Amount = info.Amount,
                UnitId = info.UnitId,
                UnitName = info.UnitName,
                Price = info.Price
            };
            TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, SupplyProductEntity info)
        {
            TResult result = new TResult
            {
                SupplyId = info.SupplyId,
                ProductId = info.ProductId,
                ProductName = info.ProductName,
                Amount = info.Amount,
                UnitId = info.UnitId,
                UnitName = info.UnitName,
                Price = info.Price
            };
            //(result.SupplyId, result.ProductId) = GetPK(row);
            TableContext.Update(result);
        }

        public override int CompareEntities(SupplyProductEntity first, SupplyProductEntity second)
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

        public override bool ContainsString(SupplyProductEntity entity, string sample)
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
