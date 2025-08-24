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
    public class DishModel : SimpleModel<IDish, DishInfo>
    {
        public override string TableName => "Изделия";

        public DishModel(BasicSimpleCRUD<IDish> context) : base(context) { }

        public override void Add(DishInfo info)
        {
            TableContext.Create(new Dish(info));
        }

        public override void Update(DataRow row, DishInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new Dish(info));
        }

        public override int CompareEntities(IDish first, IDish second)
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

        public override bool ContainsString(IDish entity, string sample)
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
