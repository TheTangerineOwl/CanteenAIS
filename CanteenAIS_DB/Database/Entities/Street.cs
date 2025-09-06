using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class StreetEntity : SimpleEntity
    {
        public virtual uint CityId { get; set; }
        [ColumnDisplay("Город", true, 1)]
        public virtual string CityName { get; set; }
        [ColumnDisplay("Название", true, 2)]
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
