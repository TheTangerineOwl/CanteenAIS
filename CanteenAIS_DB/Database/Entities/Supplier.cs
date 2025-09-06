using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class SupplierEntity : SimpleEntity
    {
        [ColumnDisplay("Название", true, 1)]
        public virtual string Name { get; set; }

        [ColumnDisplay("Город", true, 2)]
        public virtual string CityName { get; set; }
        public virtual uint StreetId { get; set; }
        [ColumnDisplay("Улица", true, 3)]
        public virtual string StreetName { get; set; }
        [ColumnDisplay("Строение", true, 4)]
        public virtual string Building { get; set; }
        public virtual uint HeadId { get; set; }
        [ColumnDisplay("Руководитель", true, 5)]
        public virtual string HeadName { get; set; }
        [ColumnDisplay("Телефон", true, 6)]
        public virtual string HeadPhone { get; set; }
        public virtual uint BankId { get; set; }
        [ColumnDisplay("Банк", true, 7)]
        public virtual string BankName { get; set; }
        [ColumnDisplay("Расчетный счет", true, 8)]
        public virtual string Account { get; set; }
        [ColumnDisplay("ИНН", true, 9)]
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
