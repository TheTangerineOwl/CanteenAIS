using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class CityModel : SimpleModel<ICity, CityInfo>
    {
        public override string TableName => "Города";

        public CityModel(BasicSimpleCRUD<ICity> context) : base(context) { }

        public override void Add(CityInfo info)
        {
            TableContext.Create(new City(info));
        }

        public override void Update(DataRow row, CityInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new City(info));
        }

        public override int CompareEntities(ICity first, ICity second)
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

        public override bool ContainsString(ICity entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.Name.Contains(sample)
            );
        }
    }
}
