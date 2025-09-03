using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.SupplierHead
{
    public class SupplierHeadFilterVM : BasicFilterVM<Entities.SupplierHeadEntity, Entities.SupplierHead>
    {
        public SupplierHeadFilterVM(TableModel<Entities.SupplierHeadEntity> tableModel)
            : base(tableModel)
        {
            _id = 0;
            _idCheck = false;
            _lastName = string.Empty;
            _lastNameCheck = false;
            _firstName = string.Empty;
            _firstNameCheck = false;
            _patronim = string.Empty;
            _patronimCheck = false;
            _phone = string.Empty;
            _phoneCheck = false;
        }

        protected override void Clear()
        {
            Id = 0;
            IdCheck = false;
            LastName = string.Empty;
            LastNameCheck = false;
            FirstName = string.Empty;
            FirstNameCheck = false;
            Patronim = string.Empty;
            PatronimCheck = false;
            Phone = string.Empty;
            PhoneCheck = false;
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (!ValueChecker.CheckValueUint(value.ToString(), out uint _, true))
                    value = 0;
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
                    value = "";
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
                    value = "";
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
                    value = "";
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
                    value = "";
                Set(ref _phone, value);
            }
        }

        private bool _idCheck;
        public bool IdCheck
        {
            get => _idCheck;
            set => Set(ref _idCheck, value);
        }

        private bool _lastNameCheck;
        public bool LastNameCheck
        {
            get => _lastNameCheck;
            set => Set(ref _lastNameCheck, value);
        }

        private bool _firstNameCheck;
        public bool FirstNameCheck
        {
            get => _firstNameCheck;
            set => Set(ref _firstNameCheck, value);
        }

        private bool _patronimCheck;
        public bool PatronimCheck
        {
            get => _patronimCheck;
            set => Set(ref _patronimCheck, value);
        }

        private bool _phoneCheck;
        public bool PhoneCheck
        {
            get => _phoneCheck;
            set => Set(ref _phoneCheck, value);
        }

        public override void ParseFields()
        {
            if (_idCheck)
            {
                if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
                Fields.Id = id;
            }
            if (_lastNameCheck)
            {
                if (!ValueChecker.CheckValueString(LastName, out string name, 50))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(LastName));
                Fields.LastName = name;
            }
            if (_firstNameCheck)
            {
                if (!ValueChecker.CheckValueString(FirstName, out string name, 50))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(FirstName));
                Fields.FirstName = name;
            }
            if (_patronimCheck)
            {
                if (!ValueChecker.CheckValueString(Patronim, out string name, 50))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(Patronim));
                Fields.Patronim = name;
            }
            if (_phoneCheck)
            {
                if (!ValueChecker.CheckValueString(Phone, out string name, 13))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(Phone));
                Fields.Phone = name;
            }
        }

        public override void Filter()
        {
            ParseFields();
            Model.FetchAndFilter<Entities.SupplierHead>((item) =>
                !(IdCheck && item.Id != Fields.Id) &&
                !(LastNameCheck && !item.LastName.Contains(Fields.LastName)) &&
                !(FirstNameCheck && !item.FirstName.Contains(Fields.FirstName)) &&
                !(PatronimCheck && !item.Patronim.Contains(Fields.Patronim)) &&
                !(PhoneCheck && !item.Phone.Contains(Fields.Phone))
            );
        }
    }
}
