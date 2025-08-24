using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class RealizationModel : SimpleModel<IRealization, RealizationInfo>
    {
        public override string TableName => "Реализации";

        public RealizationModel(BasicSimpleCRUD<IRealization> context) : base(context) { }

        public override void Add(RealizationInfo info)
        {
            TableContext.Create(new Realization(info));
        }

        public override void Update(DataRow row, RealizationInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new Realization(info));
        }

        public override int CompareEntities(IRealization first, IRealization second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.Id.CompareTo(second.Id);
            if (compared != 0) return compared;
            compared = first.DishId.CompareTo(second.DishId);
            if (compared != 0) return compared;
            compared = first.Amount.CompareTo(second.Amount);
            if (compared != 0) return compared;
            compared = first.DateTime.CompareTo(second.DateTime);
            if (compared != 0) return compared;
            compared = first.UnitId .CompareTo(second.UnitId);
            if (compared != 0) return compared;
            return 0;
        }

        public override bool ContainsString(IRealization entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.DishName.Contains(sample) ||
                entity.Amount.ToString().Contains(sample) ||
                entity.DateTime.ToString().Contains(sample) ||
                entity.UnitName.Contains(sample)
            );
        }
    }
}
