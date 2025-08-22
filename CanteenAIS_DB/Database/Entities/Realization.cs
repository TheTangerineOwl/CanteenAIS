using System;
using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IRealization
    {
        [DisplayName("Id")]
        uint Id { get; set; }
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

    public class Realization : IRealization
    {
        public uint Id { get; set; }
        public DateTime DateTime { get; set; }
        public uint DishId { get; set; }
        public string DishName { get; set; }
        public double Amount { get; set; }
        public uint UnitId { get; set; }
        public string UnitName { get; set; }

        public Realization(
            uint id, DateTime dateTime,
            uint dishId, string dishName,
            double amount,
            uint unitId, string unitName)
        {
            Id = id;
            DateTime = dateTime;
            DishId = dishId;
            DishName = dishName;
            Amount = amount;
            UnitId = unitId;
            UnitName = unitName;
        }

        public Realization(
            DateTime dateTime, uint dishId, double amount,
            uint unitId)
        {
            DateTime = dateTime;
            DishId = dishId;
            Amount = amount;
            UnitId = unitId;
        }
    }
}
