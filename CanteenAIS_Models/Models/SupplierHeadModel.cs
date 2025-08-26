using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class SupplierHeadModel : SimpleModel<SupplierHeadEntity>
    {
        public override string TableName => "Руководители";

        public SupplierHeadModel(BasicSimpleCRUD<SupplierHeadEntity> context) : base(context) { }

        public override void Add<TResult>(SupplierHeadEntity info)
        {
            TResult result = new TResult
            {
                Id = info.Id,
                LastName = info.LastName,
                FirstName = info.FirstName,
                Patronim = info.Patronim,
                Phone = info.Phone
            };
            TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, SupplierHeadEntity info)
        {
            TResult result = new TResult
            {
                Id = GetId(row),
                LastName = info.LastName,
                FirstName = info.FirstName,
                Patronim = info.Patronim,
                Phone = info.Phone
            };
            TableContext.Update(result);
        }

        public override int CompareEntities(SupplierHeadEntity first, SupplierHeadEntity second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.Id.CompareTo(second.Id);
            if (compared != 0) return compared;
            compared = first.LastName.CompareTo(second.LastName);
            if (compared != 0) return compared;
            compared = first.FirstName.CompareTo(second.FirstName);
            if (compared != 0) return compared;
            compared = first.Patronim.CompareTo(second.Patronim);
            if (compared != 0) return compared;
            compared = first.Phone.CompareTo(second.Phone);
            if (compared != 0) return compared;
            return 0;
        }

        public override bool ContainsString(SupplierHeadEntity entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.LastName.Contains(sample) ||
                entity.FirstName.Contains(sample) ||
                entity.Patronim.Contains(sample) ||
                entity.Phone.Contains(sample)
            );
        }
    }
}
