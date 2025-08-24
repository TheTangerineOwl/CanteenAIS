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
    public class BranchOrderModel : SimpleModel<IBranchOrder, BranchOrderInfo>
    {
        public override string TableName => "Заказы продуктов";

        public BranchOrderModel(BasicSimpleCRUD<IBranchOrder> context) : base(context) { }

        public override void Add(BranchOrderInfo info)
        {
            TableContext.Create(new BranchOrder(info));
        }

        public override void Update(DataRow row, BranchOrderInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new BranchOrder(info));
        }

        public override int CompareEntities(IBranchOrder first, IBranchOrder second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.Id.CompareTo(second.Id);
            if (compared != 0) return compared;
            compared = first.BranchId.CompareTo(second.BranchId);
            if (compared != 0) return compared;
            return first.DateTime.CompareTo(second.DateTime);
        }

        public override bool ContainsString(IBranchOrder entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.BranchName.Contains(sample) ||
                entity.DateTime.ToString().Contains(sample)
            );
        }
    }
}
