using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class OrderProductModel : DoubleModel<OrderProductEntity>
    {
        public override string TableName => "Продукты в заказе";

        public OrderProductModel(BasicDoubleCRUD<OrderProductEntity> context) : base(context) { }

        public override void Add<TResult>(OrderProductEntity info)
        {
            TResult result = new TResult
            {
                OrderId = info.OrderId,
                ProductId = info.ProductId,
                ProductName = info.ProductName,
                UnitId = info.UnitId,
                UnitName = info.UnitName,
                Amount = info.Amount
            };
            TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, OrderProductEntity info)
        {
            TResult result = new TResult
            {
                OrderId = info.OrderId,
                ProductId = info.ProductId,
                ProductName = info.ProductName,
                UnitId = info.UnitId,
                UnitName = info.UnitName,
                Amount = info.Amount
            };
            //(result.OrderId, result.ProductId) = GetPK(row);
            TableContext.Update(result);
        }

        public override int CompareEntities(OrderProductEntity first, OrderProductEntity second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.OrderId.CompareTo(second.OrderId);
            if (compared != 0) return compared;
            compared = first.ProductId.CompareTo(second.ProductId);
            if (compared != 0) return compared;
            compared = first.UnitId.CompareTo(second.UnitId);
            if (compared != 0) return compared;
            compared = first.Amount.CompareTo(second.Amount);
            if (compared != 0) return compared;
            return 0;
        }

        public override bool ContainsString(OrderProductEntity entity, string sample)
        {
            return (
                entity.OrderId.ToString().Contains(sample) ||
                entity.ProductName.Contains(sample) ||
                entity.ProductId.ToString().Contains(sample) ||
                entity.UnitName.Contains(sample) ||
                entity.Amount.ToString().Contains(sample)
            );
        }
    }
}
