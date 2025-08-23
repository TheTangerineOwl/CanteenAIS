//using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Transactions;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IDish : ISimpleEntity
    {
        [DisplayName("Имя")]
        string Name { get; set; }
        [DisplayName("Группа")]
        string GroupName { get; set; }
        uint GroupId { get; set; }
        [DisplayName("Цена")]
        decimal Price { get; set; }
        [DisplayName("Выход")]
        double Serving { get; set; }
        [DisplayName("Единица измерения")]
        string UnitName { get; set; }
        uint UnitId { get; set; }
        [DisplayName("Приготовление")]
        string Recipe { get; set; }
        [DisplayName("Фото")]
        string Picture { get; set; }
    }

    public class DishInfo : SimpleInfo
    {
        public string name;
        public uint groupId;
        public string groupName;
        public decimal price;
        public double serving;
        public uint unitId;
        public string unitName;
        public string recipe;
        public string picture;
    }

    public class Dish : IDish
    {
        private readonly DishInfo _info;
        public uint Id { get => _info.id; set => _info.id = value; }
        public string Name { get => _info.name; set => _info.name = value; }
        public uint GroupId { get => _info.groupId; set => _info.groupId = value; }
        public string GroupName { get => _info.groupName; set => _info.groupName = value; }
        public decimal Price { get => _info.price; set => _info.price = value; }
        public double Serving { get => _info.serving; set => _info.serving = value; }
        public uint UnitId { get => _info.unitId; set => _info.unitId = value; }
        public string UnitName { get => _info.unitName; set => _info.unitName = value; }
        public string Recipe { get => _info.recipe; set => _info.recipe = value; }
        public string Picture { get => _info.picture; set => _info.picture = value; }

        public Dish(DishInfo info)
        {
            _info = info;
        }
    }
}
