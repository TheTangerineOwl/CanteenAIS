using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface ISupplier
    {
        [DisplayName("Id")]
        uint Id { get; set; }
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

    public class Supplier : ISupplier
    {
        public uint Id { get; set; }
        public string Name { get; set; }

        public string CityName { get; set; }
        public uint StreetId { get; set; }
        public string StreetName { get; set; }
        public string Building { get; set; }
        public uint HeadId { get; set; }
        public string HeadName { get; set; }
        public string HeadPhone { get; set; }
        public uint BankId { get; set; }
        public string BankName { get; set; }
        public string Account { get; set; }
        public string INN { get; set; }

        public Supplier(
            uint id, string name,
            string cityName, uint streetId, string streetName,
            string building,
            uint headId, string headName, string headPhone,
            uint bankId, string bankName, string account, string inn
        )
        {
            Id = id;
            Name = name;
            CityName = cityName;
            StreetId = streetId;
            StreetName = streetName;
            Building = building;
            HeadId = headId;
            HeadName = headName;
            HeadPhone = headPhone;
            BankId = bankId;
            BankName = bankName;
            Account = account;
            INN = inn;
        }

        public Supplier(
            string name, uint streetId,
            string building, uint headId,
            uint bankId,string accountNumber, string inn
        )
        {
            Name = name;
            StreetId = streetId;
            Building = building;
            HeadId = headId;
            BankId = bankId;
            Account = accountNumber;
            INN = inn;
        }
    }
}
