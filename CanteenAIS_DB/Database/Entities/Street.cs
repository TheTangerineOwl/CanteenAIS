using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IStreet : ISimpleEntity
    {
        uint CityId { get; set; }
        [DisplayName("Город")]
        string CityName { get; set; }
        [DisplayName("Название")]
        string Name { get; set; }
    }

    public class StreetInfo : SimpleInfo
    {
        public uint cityId;
        public string cityName;
        public string name;
    }

    public class Street : IStreet
    {
        private readonly StreetInfo _info;
        public uint Id { get => _info.id; set => _info.id = value; }
        public uint CityId { get => _info.cityId; set => _info.cityId = value; }
        public string CityName { get => _info.cityName; set => _info.cityName = value; }
        public string Name { get => _info.name; set => _info.name = value; }

        public Street(StreetInfo info)
        {
            _info = info;
        }
    }
}
