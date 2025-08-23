using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface ICity : ISimpleEntity
    {
        [DisplayName("Имя")]
        string Name { get; set; }
    }

    public class CityInfo : SimpleInfo
    {
        public string name;
    }

    public class City : ICity
    {
        private readonly CityInfo _info;
        public uint Id { get => _info.id; set => _info.id = value; }
        public string Name { get => _info.name; set => _info.name = value; }

        public City(CityInfo info)
        {
            _info = info;
        }
    }
}
