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
    public class OrderProductModel : DoubleModel<IOrderProduct, OrderProductInfo>
    {
        public override string TableName => "Продукты в заказе";

        public OrderProductModel(BasicDoubleCRUD<IOrderProduct> context) : base(context) { }

        public override void Add(OrderProductInfo info)
        {
            TableContext.Create(new OrderProduct(info));
        }

        public override void Update(DataRow row, OrderProductInfo info)
        {
            (info.firstId, info.secondId) = GetPK(row);
            TableContext.Update(new OrderProduct(info));
        }

        public override int CompareEntities(IOrderProduct first, IOrderProduct second)
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

        public override bool ContainsString(IOrderProduct entity, string sample)
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
