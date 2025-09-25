using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class SupplyModel : SimpleModel<SupplyEntity>
    {
        public override string TableName => "Поставки";

        public SupplyModel(BasicSimpleCRUD<SupplyEntity> context) : base(context) { }

        public override void Add<TResult>(SupplyEntity info)
        {
            TResult result = new TResult
            {
                //Id = info.Id,
                SupplierId = info.SupplierId,
                SupplierName = info.SupplierName,
                DateTime = info.DateTime
            };
            TableContext.Create(result);
        }

        public override void Add<TResult>(SupplyEntity info, out long id)
        {
            TResult result = new TResult
            {
                //Id = info.Id,
                SupplierId = info.SupplierId,
                SupplierName = info.SupplierName,
                DateTime = info.DateTime
            };
            id = TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, SupplyEntity info)
        {
            TResult result = new TResult
            {
                Id = GetId(row),
                SupplierId = info.SupplierId,
                SupplierName = info.SupplierName,
                DateTime = info.DateTime
            };
            TableContext.Update(result);
        }

        public override int CompareEntities(SupplyEntity first, SupplyEntity second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.Id.CompareTo(second.Id);
            if (compared != 0) return compared;
            compared = first.SupplierId.CompareTo(second.SupplierId);
            if (compared != 0) return compared;
            compared = first.DateTime.CompareTo(second.DateTime);
            return compared;
        }

        public override bool ContainsString(SupplyEntity entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.SupplierName.Contains(sample) ||
                entity.DateTime.ToString().Contains(sample)
            );
        }
    }
}
