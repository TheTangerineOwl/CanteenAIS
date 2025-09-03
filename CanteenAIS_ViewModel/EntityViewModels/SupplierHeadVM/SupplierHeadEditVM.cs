using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.SupplierHead
{
    public class SupplierHeadEditVM : BasicEditVM<Entities.SupplierHeadEntity, Entities.SupplierHead>
    {
        public SupplierHeadEditVM(DataRow row, TableModel<Entities.SupplierHeadEntity> tableModel)
            : base(row, tableModel)
        {
            _id = (int)Fields.Id;
            _lastName = Fields.LastName;
            _firstName = Fields.FirstName;
            _patronim = Fields.Patronim;
            _phone = Fields.Phone;
        }

        protected override void Clear()
        {
            Id = (int)Fields.Id;
            LastName = Fields.LastName;
            FirstName = Fields.FirstName;
            Patronim = Fields.Patronim;
            Phone = Fields.Phone;
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (!ValueChecker.CheckValueUint(value.ToString(), out uint _, true))
                    value = (int)Fields.Id;
                Set(ref _id, value);
            }
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
                    value = Fields.LastName;
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
                    value = Fields.FirstName;
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
                    value = Fields.Patronim;
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
                    value = Fields.Phone;
                Set(ref _phone, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
            Fields.Id = id;

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
