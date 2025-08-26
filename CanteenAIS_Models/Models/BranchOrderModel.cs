using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class BranchOrderModel : SimpleModel<BranchOrderEntity>
    {
        public override string TableName => "Заказы продуктов";

        public BranchOrderModel(BasicSimpleCRUD<BranchOrderEntity> context) : base(context) { }

        public override void Add<TResult>(BranchOrderEntity info)
        {
            TResult result = new TResult
            {
                Id = info.Id,
                BranchId = info.BranchId,
                BranchName = info.BranchName,
                DateTime = info.DateTime
            };
            TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, BranchOrderEntity info)
        {
            TResult result = new TResult
            {
                Id = GetId(row),
                BranchId = info.BranchId,
                BranchName = info.BranchName,
                DateTime = info.DateTime
            };
            TableContext.Update(result);
        }

        public override int CompareEntities(BranchOrderEntity first, BranchOrderEntity second)
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

        public override bool ContainsString(BranchOrderEntity entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.BranchName.Contains(sample) ||
                entity.DateTime.ToString().Contains(sample)
            );
        }
    }
}
