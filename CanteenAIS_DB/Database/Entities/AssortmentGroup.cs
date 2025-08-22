using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IAssortmentGroup
    {
        [DisplayName("Id")]
        uint Id { get; set; }
        [DisplayName("Имя")]
        string Name { get; set; }
    }

    public class AssortmentGroup : IAssortmentGroup
    {
        public uint Id { get; set; }
        public string Name { get; set; }

        public AssortmentGroup(uint id, string name)
        {
            Id = id;
            Name = name;
        }

        public AssortmentGroup(string name)
        {
            Name = name;
        }
    }
}
