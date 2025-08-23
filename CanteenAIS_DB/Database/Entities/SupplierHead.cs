using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface ISupplierHead : ISimpleEntity
    {
        [DisplayName("Фамилия")]
        string LastName { get; set; }
        [DisplayName("Имя")]
        string FirstName { get; set; }
        [DisplayName("Отчество")]
        string Patronim { get; set; }
        [DisplayName("Телефон")]
        string Phone { get; set; }
    }

    public class SupplierHeadInfo : SimpleInfo
    {
        public string lastName;
        public string firstName;
        public string patronim;
        public string phone;
    }

    public class SupplierHead : ISupplierHead
    {
        private readonly SupplierHeadInfo _info;
        public uint Id { get => _info.id; set => _info.id = value; }
        public string LastName { get => _info.lastName; set => _info.lastName = value; }
        public string FirstName { get => _info.firstName; set => _info.firstName = value; }
        public string Patronim { get => _info.patronim; set => _info.patronim = value; }
        public string Phone { get => _info.phone; set => _info.phone = value; }

        public SupplierHead(SupplierHeadInfo info)
        {
            _info = info;
        }
    }
}
