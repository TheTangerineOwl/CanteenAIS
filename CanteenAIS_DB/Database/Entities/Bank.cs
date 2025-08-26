using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class BankEntity : SimpleEntity
    {
        [DisplayName("Имя")]
        public virtual string Name { get; set; }

        public BankEntity() { }

        public BankEntity(BankEntity info)
        {
            Id = info.Id;
            Name = info.Name;
        }
    }

    public class Bank : BankEntity
    {
        public Bank() { }

        public Bank(BankEntity info) : base(info) { }
    }
}
