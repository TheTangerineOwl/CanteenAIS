using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class StreetModel : SimpleModel<StreetEntity>
    {
        public override string TableName => "Улицы";

        public StreetModel(BasicSimpleCRUD<StreetEntity> context) : base(context) { }

        public override void Add<TResult>(StreetEntity info)
        {
            TResult result = new TResult
            {
                //Id = info.Id,
                CityId = info.CityId,
                CityName = info.CityName,
                Name = info.Name
            };
            TableContext.Create(result);
        }

        public override void Add<TResult>(StreetEntity info, out long id)
        {
            TResult result = new TResult
            {
                //Id = info.Id,
                CityId = info.CityId,
                CityName = info.CityName,
                Name = info.Name
            };
            id = TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, StreetEntity info)
        {
            TResult result = new TResult
            {
                Id = GetId(row),
                CityId = info.CityId,
                CityName = info.CityName,
                Name = info.Name
            };
            TableContext.Update(result);
        }

        public override int CompareEntities(StreetEntity first, StreetEntity second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.Id.CompareTo(second.Id);
            if (compared != 0) return compared;
            compared = first.CityId.CompareTo(second.CityId);
            if (compared != 0) return compared;
            compared = string.Compare(first.Name, second.Name);
            if (compared != 0) return compared;
            return 0;
        }

        public override bool ContainsString(StreetEntity entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.CityName.Contains(sample) ||
                entity.Name.Contains(sample)
            );
        }
    }
}
