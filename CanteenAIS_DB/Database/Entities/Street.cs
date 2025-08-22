using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IStreet
    {
        [DisplayName("Id")]
        uint Id { get; set; }
        uint CityId { get; set; }
        [DisplayName("Город")]
        string CityName { get; set; }
        [DisplayName("Название")]
        string Name { get; set; }
    }

    public class Street : IStreet
    {
        public uint Id { get; set; }
        public uint CityId { get; set; }
        public string CityName { get; set; }
        public string Name { get; set; }

        public Street(uint id, uint cityId, string cityName, string name)
        {
            Id = id;
            CityId = cityId;
            CityName = cityName;
            Name = name;
        }

        public Street(uint cityId, string name)
        {
            CityId = cityId;
            Name = name;
        }
    }
}
