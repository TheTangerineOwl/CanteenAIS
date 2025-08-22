using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IBank
    {
        [DisplayName("Id")]
        uint Id { get;set; }
        [DisplayName("Имя")]
        string Name { get; set; }
    }

    public class Bank : IBank
    {
        public uint Id { get; set; }
        public string Name { get; set; }

        public Bank(uint id, string name)
        {
            Id = id;
            Name = name;
        }

        public Bank(string name)
        {
            Name = name;
        }
    }
}
