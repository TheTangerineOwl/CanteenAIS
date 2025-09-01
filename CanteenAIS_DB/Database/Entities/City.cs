using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class CityEntity : SimpleEntity
    {
        [DisplayName("Имя")]
        [ColumnOrder(1)]
        public virtual string Name { get; set; }

        public CityEntity() { }

        public CityEntity(CityEntity info)
        {
            Id = info.Id;
            Name = info.Name;
        }
    }

    public class City : CityEntity
    {
        public City() : base() { }

        public City(CityEntity info) : base(info) { }
    }
}
