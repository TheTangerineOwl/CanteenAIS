using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface ISupplier : ISimpleEntity
    {
        [DisplayName("Название")]
        string Name { get; set; }

        [DisplayName("Город")]
        string CityName { get; set; }
        uint StreetId { get; set; }
        [DisplayName("Улица")]
        string StreetName { get; set; }
        [DisplayName("Строение")]
        string Building { get; set; }
        uint HeadId { get; set; }
        [DisplayName("Руководитель")]
        string HeadName { get; set; }
        [DisplayName("Телефон")]
        string HeadPhone { get; set; }
        uint BankId { get; set; }
        [DisplayName("Банк")]
        string BankName { get; set; }
        [DisplayName("Расчетный счет")]
        string Account { get; set; }
        [DisplayName("ИНН")]
        string INN { get; set; }
    }

    public class SupplierInfo : SimpleInfo
    {
        public string name;
        public string cityName;
        public uint streetId;
        public string streetName;
        public string building;
        public uint headId;
        public string headName;
        public string headPhone;
        public uint bankId;
        public string bankName;
        public string account;
        public string inn;
    }

    public class Supplier : ISupplier
    {
        private readonly SupplierInfo _info;
        public uint Id { get => _info.id; set => _info.id = value; }
        public string Name { get => _info.name; set => _info.name = value; }
        public string CityName { get => _info.cityName; set => _info.cityName = value; }
        public uint StreetId { get => _info.streetId; set => _info.streetId = value; }
        public string StreetName { get => _info.streetName; set => _info.streetName = value; }
        public string Building { get => _info.building; set => _info.building = value; }
        public uint HeadId { get => _info.headId; set => _info.headId = value; }
        public string HeadName { get => _info.headName; set => _info.headName = value; }
        public string HeadPhone { get => _info.headPhone; set => _info.headPhone = value; }
        public uint BankId { get => _info.bankId; set => _info.bankId = value; }
        public string BankName { get => _info.bankName; set => _info.bankName = value; }
        public string Account { get => _info.account; set => _info.account = value; }
        public string INN { get => _info.inn; set => _info.inn = value; }

        public Supplier(SupplierInfo info)
        {
            _info = info;
        }
    }
}
