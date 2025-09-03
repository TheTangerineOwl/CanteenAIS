using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class SupplierEntity : SimpleEntity
    {
        [DisplayName("Название")]
        [ColumnOrder(1)]
        public virtual string Name { get; set; }

        [DisplayName("Город")]
        [ColumnOrder(2)]
        public virtual string CityName { get; set; }
        public virtual uint StreetId { get; set; }
        [DisplayName("Улица")]
        [ColumnOrder(3)]
        public virtual string StreetName { get; set; }
        [DisplayName("Строение")]
        [ColumnOrder(4)]
        public virtual string Building { get; set; }
        public virtual uint HeadId { get; set; }
        [DisplayName("Руководитель")]
        [ColumnOrder(5)]
        public virtual string HeadName { get; set; }
        [DisplayName("Телефон")]
        [ColumnOrder(6)]
        public virtual string HeadPhone { get; set; }
        public virtual uint BankId { get; set; }
        [DisplayName("Банк")]
        [ColumnOrder(7)]
        public virtual string BankName { get; set; }
        [DisplayName("Расчетный счет")]
        [ColumnOrder(8)]
        public virtual string Account { get; set; }
        [DisplayName("ИНН")]
        [ColumnOrder(9)]
        public virtual string INN { get; set; }

        public SupplierEntity() { }

        public SupplierEntity(SupplierEntity info)
        {
            Id = info.Id;
            Name = info.Name;
            CityName = info.CityName;
            StreetId = info.StreetId;
            StreetName = info.StreetName;
            Building = info.Building;
            HeadId = info.HeadId;
            HeadName = info.HeadName;
            HeadPhone = info.HeadPhone;
            BankId = info.BankId;
            BankName = info.BankName;
            Account = info.Account;
            INN = info.INN;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Supplier : SupplierEntity
    {
        public Supplier() { }

        public Supplier(SupplierEntity info) : base(info) { }
    }
}
