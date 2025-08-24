using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class SupplyModel : SimpleModel<ISupply, SupplyInfo>
    {
        public override string TableName => "Поставки";

        public SupplyModel(BasicSimpleCRUD<ISupply> context) : base(context) { }

        public override void Add(SupplyInfo info)
        {
            TableContext.Create(new Supply(info));
        }

        public override void Update(DataRow row, SupplyInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new Supply(info));
        }

        public override int CompareEntities(ISupply first, ISupply second)
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

        public override bool ContainsString(ISupply entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.SupplierName.Contains(sample) ||
                entity.DateTime.ToString().Contains(sample)
            );
        }
    }
}
