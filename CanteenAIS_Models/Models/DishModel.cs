using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class DishModel : SimpleModel<DishEntity>
    {
        public override string TableName => "Изделия";

        public DishModel(BasicSimpleCRUD<DishEntity> context) : base(context) { }

        public override void Add<TResult>(DishEntity info)
        {
            TResult result = new TResult
            {
                Id = info.Id,
                Name = info.Name,
                GroupId = info.GroupId,
                GroupName = info.GroupName,
                Price = info.Price,
                Serving = info.Serving,
                UnitId = info.UnitId,
                UnitName = info.UnitName,
                Recipe = info.Recipe,
                Picture = info.Picture
            };
            TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, DishEntity info)
        {
            TResult result = new TResult
            {
                Id = GetId(row),
                Name = info.Name,
                GroupId = info.GroupId,
                GroupName = info.GroupName,
                Price = info.Price,
                Serving = info.Serving,
                UnitId = info.UnitId,
                UnitName = info.UnitName,
                Recipe = info.Recipe,
                Picture = info.Picture
            };
            TableContext.Update(result);
        }

        public override int CompareEntities(DishEntity first, DishEntity second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.Id.CompareTo(second.Id);
            if (compared != 0) return compared;
            compared = first.Name.CompareTo(second.Name);
            if (compared != 0) return compared;
            compared = first.GroupId.CompareTo(second.GroupId);
            if (compared != 0) return compared;
            compared = first.Price.CompareTo(second.Price);
            if (compared != 0) return compared;
            compared = first.Serving.CompareTo(second.Serving);
            if (compared != 0) return compared;
            compared = first.UnitId.CompareTo(second.UnitId);
            if (compared != 0) return compared;
            compared = first.Recipe.CompareTo(second.Recipe);
            if (compared != 0) return compared;
            return first.Picture.CompareTo(second.Picture);
        }

        public override bool ContainsString(DishEntity entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.Name.Contains(sample) ||
                entity.GroupName.Contains(sample) ||
                entity.Price.ToString().Contains(sample) ||
                entity.Serving.ToString().Contains(sample) ||
                entity.UnitName.Contains(sample) ||
                entity.Recipe.Contains(sample) ||
                entity.Picture.Contains(sample)
            );
        }
    }
}
