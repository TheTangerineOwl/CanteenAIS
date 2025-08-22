using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface ICity
    {
        [DisplayName("Id")]
        uint Id { get; set; }
        [DisplayName("Имя")]
        string Name { get; set; }
    }

    public class City : ICity
    {
        public uint Id { get; set; }
        public string Name { get; set; }

        public City(uint id, string name)
        {
            Id = id;
            Name = name;
        }

        public City(string name)
        {
            Name = name;
        }
    }
}
