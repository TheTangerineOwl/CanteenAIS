using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IBranch
    {
        [DisplayName("Id")]
        uint Id { get; set; }
        [DisplayName("Имя")]
        string Name { get; set; }
    }

    public class Branch : IBranch
    {
        public uint Id { get; set; }
        public string Name { get; set; }

        public Branch(uint id, string name)
        {
            Id = id;
            Name = name;
        }

        public Branch(string name)
        {
            Name = name;
        }
    }
}
