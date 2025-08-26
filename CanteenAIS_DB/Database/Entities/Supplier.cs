using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class SupplierEntity : SimpleEntity
    {
        [DisplayName("Название")]
        public virtual string Name { get; set; }

        [DisplayName("Город")]
        public virtual string CityName { get; set; }
        public virtual uint StreetId { get; set; }
        [DisplayName("Улица")]
        public virtual string StreetName { get; set; }
        [DisplayName("Строение")]
        public virtual string Building { get; set; }
        public virtual uint HeadId { get; set; }
        [DisplayName("Руководитель")]
        public virtual string HeadName { get; set; }
        [DisplayName("Телефон")]
        public virtual string HeadPhone { get; set; }
        public virtual uint BankId { get; set; }
        [DisplayName("Банк")]
        public virtual string BankName { get; set; }
        [DisplayName("Расчетный счет")]
        public virtual string Account { get; set; }
        [DisplayName("ИНН")]
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
    }

    public class Supplier : SupplierEntity
    {
        public Supplier() { }

        public Supplier(SupplierEntity info) : base(info) { }
    }
}
