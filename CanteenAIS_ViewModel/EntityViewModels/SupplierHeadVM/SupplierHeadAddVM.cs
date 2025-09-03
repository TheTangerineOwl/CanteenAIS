using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.SupplierHead
{
    public class SupplierHeadAddVM : BasicAddVM<Entities.SupplierHeadEntity, Entities.SupplierHead>
    {
        public SupplierHeadAddVM(TableModel<Entities.SupplierHeadEntity> tableModel)
            : base(tableModel)
        {
            _lastName = string.Empty;
            _firstName = string.Empty;
            _patronim = string.Empty;
            _phone = string.Empty;
        }

        protected override void Clear()
        {
            LastName = string.Empty;
            FirstName = string.Empty;
            Patronim = string.Empty;
            Phone = string.Empty;
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == null)
                    _lastName = value;
                if (!ValueChecker.CheckValueString(value, out value, 50, false))
                    value = string.Empty;
                Set(ref _lastName, value);
            }
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == null)
                    _firstName = value;
                if (!ValueChecker.CheckValueString(value, out value, 50, false))
                    value = string.Empty;
                Set(ref _firstName, value);
            }
        }

        private string _patronim;
        public string Patronim
        {
            get => _patronim;
            set
            {
                if (_patronim == null)
                    _patronim = value;
                if (!ValueChecker.CheckValueString(value, out value, 50, false))
                    value = string.Empty;
                Set(ref _patronim, value);
            }
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                if (_phone == null)
                    _phone = value;
                if (!ValueChecker.CheckValueString(value, out value, 13, false))
                    value = string.Empty;
                Set(ref _phone, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueString(LastName, out string lastname, 50))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(LastName));
            Fields.LastName = lastname;

            if (!ValueChecker.CheckValueString(FirstName, out string firstname, 50))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(FirstName));
            Fields.FirstName = firstname;

            if (!ValueChecker.CheckValueString(Patronim, out string patronim, 50))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Patronim));
            Fields.Patronim = patronim;

            if (!ValueChecker.CheckValueString(Phone, out string phone, 13))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Phone));
            Fields.Phone = phone;
        }
    }
}
