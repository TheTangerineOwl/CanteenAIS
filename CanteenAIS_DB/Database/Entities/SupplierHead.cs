using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface ISupplierHead
    {
        [DisplayName("Id")]
        uint Id { get; set; }
        [DisplayName("Фамилия")]
        string LastName { get; set; }
        [DisplayName("Имя")]
        string FirstName { get; set; }
        [DisplayName("Отчество")]
        string Patronim { get; set; }
        [DisplayName("Телефон")]
        string Phone { get; set; }
    }

    public class SupplierHead : ISupplierHead
    {
        public uint Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronim { get; set; }
        public string Phone { get; set; }

        public SupplierHead(uint id, string lastName, string firstName, string patronim, string phone)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Patronim = patronim;
            Phone = phone;
        }
        public SupplierHead(string lastName, string firstName, string patronim, string phone)
        {
            LastName = lastName;
            FirstName = firstName;
            Patronim = patronim;
            Phone = phone;
        }
    }
}
