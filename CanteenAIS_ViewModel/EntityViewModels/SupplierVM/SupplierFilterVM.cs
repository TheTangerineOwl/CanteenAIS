using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supplier
{
    public class SupplierFilterVM : BasicFilterVM<Entities.SupplierEntity, Entities.Supplier>
    {
        public SupplierFilterVM(TableModel<Entities.SupplierEntity> tableModel)
            : base(tableModel)
        {
            _streets = MainServices.GetInstance().Streets.FetchValues<Entities.Street>().ToList();
            _street = Streets.FirstOrDefault();
            _streetCheck = false;
            _heads = MainServices.GetInstance().SupplierHeads.FetchValues<Entities.SupplierHead>().ToList();
            _head = Heads.FirstOrDefault();
            _headCheck = false;
            _banks = MainServices.GetInstance().Banks.FetchValues<Entities.Bank>().ToList();
            _bank = Banks.FirstOrDefault();
            _bankCheck = false;
            _id = 0;
            _idCheck = false;
            _name = string.Empty;
            _nameCheck = false;
            _building = string.Empty;
            _buildingCheck = false;
            _account = string.Empty;
            _accountCheck = false;
            _inn = string.Empty;
            _innCheck = false;
        }

        protected override void Clear()
        {
            Street = Streets.FirstOrDefault();
            StreetCheck = false;
            Head = Heads.FirstOrDefault();
            HeadCheck = false;
            Bank = Banks.FirstOrDefault();
            BankCheck = false;
            Id = 0;
            IdCheck = false;
            Name = string.Empty;
            NameCheck = false;
            Building = string.Empty;
            BuildingCheck = false;
            Account = string.Empty;
            AccountCheck = false;
            INN = string.Empty;
            INNCheck = false;
        }

        private IList<Entities.Street> _streets;
        public IList<Entities.Street> Streets
        {
            get => _streets;
            set => Set(ref _streets, value);
        }

        private IList<Entities.SupplierHead> _heads;
        public IList<Entities.SupplierHead> Heads
        {
            get => _heads;
            set => Set(ref _heads, value);
        }

        private IList<Entities.Bank> _banks;
        public IList<Entities.Bank> Banks
        {
            get => _banks;
            set => Set(ref _banks, value);
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

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == null)
                    _name = value;
                if (!ValueChecker.CheckValueString(value, out value, 50, false))
                    value = "";
                Set(ref _name, value);
            }
        }

        private Entities.Street _street;
        public Entities.Street Street
        {
            get => _street;
            set => Set(ref _street, value);
        }

        private Entities.SupplierHead _head;
        public Entities.SupplierHead Head
        {
            get => _head;
            set => Set(ref _head, value);
        }

        private Entities.Bank _bank;
        public Entities.Bank Bank
        {
            get => _bank;
            set => Set(ref _bank, value);
        }

        private string _building;
        public string Building
        {
            get => _building;
            set
            {
                if (_building == null)
                    _building = value;
                if (!ValueChecker.CheckValueString(value, out string _, 16))
                    value = string.Empty;
                Set(ref _building, value);
            }
        }

        private string _account;
        public string Account
        {
            get => _account;
            set
            {
                if (_account == null)
                    _account = value;
                if (!ValueChecker.CheckValueString(value, out string _, 20))
                    value = string.Empty;
                Set(ref _account, value);
            }
        }

        private string _inn;
        public string INN
        {
            get => _inn;
            set
            {
                if (_inn == null)
                    _inn = value;
                if (!ValueChecker.CheckValueString(value, out string _, 10))
                    value = string.Empty;
                Set(ref _inn, value);
            }
        }

        private bool _idCheck;
        public bool IdCheck
        {
            get => _idCheck;
            set => Set(ref _idCheck, value);
        }

        private bool _nameCheck;
        public bool NameCheck
        {
            get => _nameCheck;
            set => Set(ref _nameCheck, value);
        }

        private bool _streetCheck;
        public bool StreetCheck
        {
            get => _streetCheck;
            set => Set(ref _streetCheck, value);
        }

        private bool _headCheck;
        public bool HeadCheck
        {
            get => _headCheck;
            set => Set(ref _headCheck, value);
        }

        private bool _bankCheck;
        public bool BankCheck
        {
            get => _bankCheck;
            set => Set(ref _bankCheck, value);
        }

        private bool _buildingCheck;
        public bool BuildingCheck
        {
            get => _buildingCheck;
            set => Set(ref _buildingCheck, value);
        }

        private bool _accountCheck;
        public bool AccountCheck
        {
            get => _accountCheck;
            set => Set(ref _accountCheck, value);
        }

        private bool _innCheck;
        public bool INNCheck
        {
            get => _innCheck;
            set => Set(ref _innCheck, value);
        }

        public override void ParseFields()
        {
            if (_idCheck)
            {
                if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
                Fields.Id = id;
            }
            if (_nameCheck)
            {
                if (!ValueChecker.CheckValueString(Name, out string name, 50))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
                Fields.Name = name;
            }
            if (_streetCheck)
            {
                if (!ValueChecker.CheckValueUint(Street.Id.ToString(), out uint streetId, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Street.Id));
                Fields.StreetId = streetId;
            }
            if (_headCheck)
            {
                if (!ValueChecker.CheckValueUint(Head.Id.ToString(), out uint headId, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Head.Id));
                Fields.HeadId = headId;
            }
            if (_bankCheck)
            {
                if (!ValueChecker.CheckValueUint(Bank.Id.ToString(), out uint bankId, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Bank.Id));
                Fields.BankId = bankId;
            }
            if (_buildingCheck)
            {
                if (!ValueChecker.CheckValueString(Building, out string building, 16))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(Building));
                Fields.Building = building;
            }
            if (_accountCheck)
            {
                if (!ValueChecker.CheckValueString(Account, out string account, 20))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(Account));
                Fields.Account = account;
            }
            if (_innCheck)
            {
                if (!ValueChecker.CheckValueString(INN, out string inn, 10))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(INN));
                Fields.INN = inn;
            }
        }

        public override void Filter()
        {
            ParseFields();
            Model.FetchAndFilter<Entities.Supplier>((item) =>
                !(IdCheck && item.Id != Fields.Id) &&
                !(NameCheck && !item.Name.Contains(Fields.Name)) &&
                !(StreetCheck && item.StreetId != Fields.StreetId) &&
                !(HeadCheck && item.HeadId != Fields.HeadId) &&
                !(BankCheck && item.BankId != Fields.BankId) &&
                !(BuildingCheck && !item.Building.Contains(Fields.Building)) &&
                !(AccountCheck && !item.Account.Contains(Fields.Account)) &&
                !(INNCheck && item.INN != Fields.INN)
            );
        }
    }
}
