using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class BankEntity : SimpleEntity
    {
        [ColumnDisplay("Имя", true, 1)]
        public virtual string Name { get; set; }

        public BankEntity() { }

        public BankEntity(BankEntity info)
        {
            Id = info.Id;
            Name = info.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Bank : BankEntity
    {
        public Bank() { }

        public Bank(BankEntity info) : base(info) { }
    }
}
