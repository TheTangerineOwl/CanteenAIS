using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenAIS_Models.Models
{
    public class StreetModel : SimpleModel<IStreet, StreetInfo>
    {
        public override string TableName => "Улицы";

        public StreetModel(BasicSimpleCRUD<IStreet> context) : base(context) { }

        public override void Add(StreetInfo info)
        {
            TableContext.Create(new Street(info));
        }

        public override void Update(DataRow row, StreetInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new Street(info));
        }

        public override int CompareEntities(IStreet first, IStreet second)
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

        public override bool ContainsString(IStreet entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.CityName.Contains(sample) ||
                entity.Name.Contains(sample)
            );
        }
    }
}
