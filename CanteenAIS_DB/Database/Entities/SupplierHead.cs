using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class SupplierHeadEntity : SimpleEntity
    {
        [DisplayName("Фамилия")]
        [ColumnOrder(1)]
        public virtual string LastName { get; set; }
        [DisplayName("Имя")]
        [ColumnOrder(2)]
        public virtual string FirstName { get; set; }
        [DisplayName("Отчество")]
        [ColumnOrder(3)]
        public virtual string Patronim { get; set; }
        [DisplayName("Телефон")]
        [ColumnOrder(4)]
        public virtual string Phone { get; set; }

        public SupplierHeadEntity() { }

        public SupplierHeadEntity(SupplierHeadEntity info)
        {
            Id = info.Id;
            LastName = info.LastName;
            FirstName = info.FirstName;
            Patronim = info.Patronim;
            Phone = info.Phone;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName} {Patronim}";
        }
    }

    public class SupplierHead : SupplierHeadEntity
    {
        public SupplierHead() { }

        public SupplierHead(SupplierHeadEntity info) : base(info) { }
    }
}
