using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IRealization : ISimpleEntity
    {
        [DisplayName("Время")]
        DateTime DateTime { get; set; }
        uint DishId { get; set; }
        [DisplayName("Блюдо")]
        string DishName { get; set; }
        [DisplayName("Объем")]
        double Amount { get; set; }
        uint UnitId { get; set; }
        [DisplayName("Единица измерения")]
        string UnitName { get; set; }
    }

    public class RealizationInfo : SimpleInfo
    {
        public DateTime dateTime;
        public uint dishId;
        public string dishName;
        public double amount;
        public uint unitId;
        public string unitName;
    }

    public class Realization : IRealization
    {
        private readonly RealizationInfo _info;
        public uint Id { get => _info.id; set => _info.id = value; }
        public DateTime DateTime { get => _info.dateTime; set => _info.dateTime = value; }
        public uint DishId { get => _info.dishId; set => _info.dishId = value; }
        public string DishName { get => _info.dishName; set => _info.dishName = value; }
        public double Amount { get => _info.amount; set => _info.amount = value; }
        public uint UnitId { get => _info.unitId; set => _info.unitId = value; }
        public string UnitName { get => _info.unitName; set => _info.unitName = value; }

        public Realization(RealizationInfo info)
        {
            _info = info;
        }
    }
}
