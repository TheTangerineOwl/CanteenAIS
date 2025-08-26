using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class SupplierHeadEntity : SimpleEntity
    {
        [DisplayName("Фамилия")]
        public virtual string LastName { get; set; }
        [DisplayName("Имя")]
        public virtual string FirstName { get; set; }
        [DisplayName("Отчество")]
        public virtual string Patronim { get; set; }
        [DisplayName("Телефон")]
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
    }

    public class SupplierHead : SupplierHeadEntity
    {
        public SupplierHead() { }

        public SupplierHead(SupplierHeadEntity info) : base(info) { }
    }
}
