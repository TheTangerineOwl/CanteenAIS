using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class DishEntity : SimpleEntity
    {
        [DisplayName("Имя")]
        [ColumnOrder(1)]
        public virtual string Name { get; set; }
        [DisplayName("Группа")]
        [ColumnOrder(2)]
        public virtual string GroupName { get; set; }
        public virtual uint GroupId { get; set; }
        [DisplayName("Цена")]
        [ColumnOrder(3)]
        public virtual decimal Price { get; set; }
        [DisplayName("Выход")]
        [ColumnOrder(4)]
        public virtual double Serving { get; set; }
        [DisplayName("Единица измерения")]
        [ColumnOrder(5)]
        public virtual string UnitName { get; set; }
        public virtual uint UnitId { get; set; }
        [DisplayName("Приготовление")]
        [ColumnOrder(6)]
        public virtual string Recipe { get; set; }
        [DisplayName("Фото")]
        [ColumnOrder(7)]
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

        public override string ToString()
        {
            return Name;
        }
    }

    public class Dish : DishEntity
    {
        public Dish() { }

        public Dish(DishEntity info) : base(info) { }
    }
}
