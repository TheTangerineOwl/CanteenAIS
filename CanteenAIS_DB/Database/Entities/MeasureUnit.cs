using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IMeasureUnit
    {
        [DisplayName("Id")]
        uint Id { get; set; }
        [DisplayName("Имя")]
        string Name { get; set; }
    }

    public class MeasureUnit : IMeasureUnit
    {
        public uint Id { get; set; }
        public string Name { get; set; }

        public MeasureUnit(uint id, string name)
        {
            Id = id;
            Name = name;
        }

        public MeasureUnit(string name)
        {
            Name = name;
        }
    }
}
