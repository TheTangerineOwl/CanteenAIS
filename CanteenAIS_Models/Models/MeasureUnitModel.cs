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
    public class MeasureUnitModel : SimpleModel<IMeasureUnit, MeasureUnitInfo>
    {
        public override string TableName => "Единицы измерения";

        public MeasureUnitModel(BasicSimpleCRUD<IMeasureUnit> context) : base(context) { }

        public override void Add(MeasureUnitInfo info)
        {
            TableContext.Create(new MeasureUnit(info));
        }

        public override void Update(DataRow row, MeasureUnitInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new MeasureUnit(info));
        }

        public override int CompareEntities(IMeasureUnit first, IMeasureUnit second)
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

        public override bool ContainsString(IMeasureUnit entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.Name.Contains(sample)
            );
        }
    }
}
