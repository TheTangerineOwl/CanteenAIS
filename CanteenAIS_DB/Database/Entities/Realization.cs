using System;
using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class RealizationEntity : SimpleEntity
    {
        [DisplayName("Время")]
        public virtual DateTime DateTime { get; set; }
        public virtual uint DishId { get; set; }
        [DisplayName("Блюдо")]
        public virtual string DishName { get; set; }
        [DisplayName("Объем")]
        public virtual double Amount { get; set; }
        public virtual uint UnitId { get; set; }
        [DisplayName("Единица измерения")]
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
    }

    public class Realization : RealizationEntity
    {
        public Realization() { }

        public Realization(RealizationEntity info) : base(info) { }
    }
}
