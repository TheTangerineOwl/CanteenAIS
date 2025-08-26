using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class BranchEntity : SimpleEntity
    {
        [DisplayName("Имя")]
        public virtual string Name { get; set; }

        public BranchEntity() { }

        public BranchEntity(BranchEntity info)
        {
            Id = info.Id;
            Name = info.Name;
        }
    }

    public class Branch : BranchEntity
    {
        public Branch() { }

        public Branch(BranchEntity info) : base(info) { }
    }
}
