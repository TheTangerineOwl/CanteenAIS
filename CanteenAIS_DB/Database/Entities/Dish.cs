using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class DishEntity : SimpleEntity
    {
        [DisplayName("Имя")]
        public virtual string Name { get; set; }
        [DisplayName("Группа")]
        public virtual string GroupName { get; set; }
        public virtual uint GroupId { get; set; }
        [DisplayName("Цена")]
        public virtual decimal Price { get; set; }
        [DisplayName("Выход")]
        public virtual double Serving { get; set; }
        [DisplayName("Единица измерения")]
        public virtual string UnitName { get; set; }
        public virtual uint UnitId { get; set; }
        [DisplayName("Приготовление")]
        public virtual string Recipe { get; set; }
        [DisplayName("Фото")]
        public virtual string Picture { get; set; }

        public DishEntity() { }

        public DishEntity(DishEntity info)
        {
            Id = info.Id;
            Name = info.Name;
            GroupId = info.GroupId;
            GroupName = info.GroupName;
            Price = info.Price;
            Serving = info.Serving;
            UnitId = info.UnitId;
            UnitName = info.UnitName;
            Recipe = info.Recipe;
            Picture = info.Picture;
        }
    }

    public class Dish : DishEntity
    {
        public Dish() { }

        public Dish(DishEntity info) : base(info) { }
    }
}
