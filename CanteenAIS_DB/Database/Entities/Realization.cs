using System;
using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class RealizationEntity : SimpleEntity
    {
        [ColumnDisplay("Время", true, 1)]
        public virtual DateTime DateTime { get; set; }
        public virtual uint DishId { get; set; }
        [ColumnDisplay("Блюдо", true, 2)]
        public virtual string DishName { get; set; }
        [ColumnDisplay("Объем", true, 3)]
        public virtual double Amount { get; set; }
        public virtual uint UnitId { get; set; }
        [ColumnDisplay("Единица измерения", true, 4)]
        public virtual string UnitName { get; set; }

        public RealizationEntity() { }

        public RealizationEntity(RealizationEntity info)
        {
            Id = info.Id;
            DateTime = info.DateTime;
            DishId = info.DishId;
            DishName = info.DishName;
            Amount = info.Amount;
            UnitId = info.UnitId;
            UnitName = info.UnitName;
        }

        public override string ToString()
        {
            return $"{DateTime}_{DishName}";
        }
    }

    public class Realization : RealizationEntity
    {
        public Realization() { }

        public Realization(RealizationEntity info) : base(info) { }
    }
}
