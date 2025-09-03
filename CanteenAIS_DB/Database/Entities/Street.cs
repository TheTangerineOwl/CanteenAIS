using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class StreetEntity : SimpleEntity
    {
        public virtual uint CityId { get; set; }
        [DisplayName("Город")]
        [ColumnOrder(1)]
        public virtual string CityName { get; set; }
        [DisplayName("Название")]
        [ColumnOrder(2)]
        public virtual string Name { get; set; }

        public StreetEntity() { }

        public StreetEntity(StreetEntity info)
        {
            Id = info.Id;
            Name = info.Name;
            CityId = info.CityId;
            CityName = info.CityName;
        }

        public override string ToString()
        {
            return $"{CityName}, {Name}";
        }
    }

    public class Street : StreetEntity
    {
        public Street() { }

        public Street(StreetEntity info) : base(info) { }
    }
}
