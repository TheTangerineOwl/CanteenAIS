using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class AssortmentGroupEntity : SimpleEntity
    {
        [ColumnDisplay("Имя", true, 1)]
        public virtual string Name { get; set; }

        public AssortmentGroupEntity() { }

        public AssortmentGroupEntity(AssortmentGroupEntity info)
        {
            Id = info.Id;
            Name = info.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class AssortmentGroup : AssortmentGroupEntity
    {
        public AssortmentGroup() { }

        public AssortmentGroup(AssortmentGroupEntity info) : base(info) { }
    }
}
