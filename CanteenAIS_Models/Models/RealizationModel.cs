using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class RealizationModel : SimpleModel<RealizationEntity>
    {
        public override string TableName => "Реализации";

        public RealizationModel(BasicSimpleCRUD<RealizationEntity> context) : base(context) { }

        public override void Add<TResult>(RealizationEntity info)
        {
            TResult result = new TResult
            {
                Id = info.Id,
                DishId = info.DishId,
                DishName = info.DishName,
                Amount = info.Amount,
                DateTime = info.DateTime,
                UnitId = info.UnitId,
                UnitName = info.UnitName
            };
            TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, RealizationEntity info)
        {
            TResult result = new TResult
            {
                Id = GetId(row),
                DishId = info.DishId,
                DishName = info.DishName,
                Amount = info.Amount,
                DateTime = info.DateTime,
                UnitId = info.UnitId,
                UnitName = info.UnitName
            };
            TableContext.Update(result);
        }

        public override int CompareEntities(RealizationEntity first, RealizationEntity second)
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

        public override bool ContainsString(RealizationEntity entity, string sample)
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
