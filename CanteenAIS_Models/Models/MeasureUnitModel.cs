using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class MeasureUnitModel : SimpleModel<MeasureUnitEntity>
    {
        public override string TableName => "Единицы измерения";

        public MeasureUnitModel(BasicSimpleCRUD<MeasureUnitEntity> context) : base(context) { }

        public override void Add<TResult>(MeasureUnitEntity info)
        {
            TResult result = new TResult
            {
                Id = info.Id,
                Name = info.Name
            };
            TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, MeasureUnitEntity info)
        {
            TResult result = new TResult
            {
                Id = GetId(row),
                Name = info.Name
            };
            TableContext.Update(result);
        }

        public override int CompareEntities(MeasureUnitEntity first, MeasureUnitEntity second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.Id.CompareTo(second.Id);
            if (compared != 0) return compared;
            compared = string.Compare(first.Name, second.Name);
            if (compared != 0) return compared;
            return 0;
        }

        public override bool ContainsString(MeasureUnitEntity entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.Name.Contains(sample)
            );
        }
    }
}
