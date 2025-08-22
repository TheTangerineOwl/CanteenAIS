//using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IDish
    {
        [DisplayName("Id")]
        uint Id { get; set; }
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
        //[DisplayName("Ингредиенты")]
        //ObservableCollection<IIngredient> Ingredients { get; set; }
    }

    public class Dish : IDish
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public uint GroupId { get; set; }
        public string GroupName { get; set; }
        public decimal Price { get; set; }
        public double Serving { get; set; }
        public uint UnitId { get; set; }
        public string UnitName { get; set; }
        public string Recipe { get; set; }
        public string Picture { get; set; }
        //public ObservableCollection<IIngredient> Ingredients { get; set; }

        public Dish(
            uint id, string name, uint groupId, string groupName,
            decimal price, double serving,
            uint unitId, string unitName,
            string recipe = null, string picture = null//, ObservableCollection<IIngredient> ingredients = null
        )
        {
            Id = id;
            Name = name;
            GroupId = groupId;
            GroupName = groupName;
            Price = price;
            Serving = serving;
            UnitId = unitId; 
            UnitName = unitName;
            Recipe = recipe;
            //Ingredients = ingredients;
            Picture = picture;
        }

        public Dish(
            string name, uint groupId,
            decimal price, double serving,
            uint unitId,
            string recipe = null,
            string picture = null
        )
        {
            Name = name;
            GroupId = groupId;
            Price = price;
            Serving = serving;
            UnitId = unitId;
            Recipe = recipe;
            Picture = picture;
        }
    }
}
