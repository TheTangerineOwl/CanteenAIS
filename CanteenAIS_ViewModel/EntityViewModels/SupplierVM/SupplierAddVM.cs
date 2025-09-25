using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supplier
{
    public class SupplierAddVM : BasicAddVM<Entities.SupplierEntity, Entities.Supplier>
    {
        public SupplierAddVM(TableModel<Entities.SupplierEntity> tableModel)
            : base(tableModel)
        {
            //_id = 1;
            _streets = MainServices.GetInstance().Streets.FetchValues<Entities.Street>().ToList();
            _street = Streets.FirstOrDefault();
            _heads = MainServices.GetInstance().SupplierHeads.FetchValues<Entities.SupplierHead>().ToList();
            _head = Heads.FirstOrDefault();
            _banks = MainServices.GetInstance().Banks.FetchValues<Entities.Bank>().ToList();
            _bank = Banks.FirstOrDefault();
            _name = string.Empty;
            _building = string.Empty;
            _account = string.Empty;
            _inn = string.Empty;
        }

        protected override void Clear()
        {
            //Id = 1;
            Street = Streets.FirstOrDefault();
            Head = Heads.FirstOrDefault();
            Bank = Banks.FirstOrDefault();
            Name = string.Empty;
            Building = string.Empty;
            Account = string.Empty;
            INN = string.Empty;
        }

        //private uint _id;
        //public uint Id
        //{
        //    get => _id;
        //    set
        //    {
        //        if (!ValueChecker.CheckValueUint(value.ToString(), out _))
        //            value = 1;
        //        Set(ref _id, value);
        //    }
        //}

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

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == null)
                    _name = value;
                if (!ValueChecker.CheckValueString(value, out value, 50, false))
                    value = string.Empty;
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
                if (!ValueChecker.CheckValueString(value, out string _, 15))
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

        public override void ParseFields()
        {
            //if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, false))
            //    throw new ArgumentNullException("Некорректное значение!", nameof(Id));
            //Fields.Id = id;

            if (!ValueChecker.CheckValueString(Name, out string name, 50))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
            Fields.Name = name;

            if (!ValueChecker.CheckValueUint(Street.Id.ToString(), out uint streetId, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Street.Id));
            Fields.StreetId = streetId;

            if (!ValueChecker.CheckValueUint(Head.Id.ToString(), out uint headId, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Head.Id));
            Fields.HeadId = headId;

            if (!ValueChecker.CheckValueUint(Bank.Id.ToString(), out uint bankId, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Bank.Id));
            Fields.BankId = bankId;

            if (!ValueChecker.CheckValueString(Building, out string building, 15))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Building));
            Fields.Building = building;

            if (!ValueChecker.CheckValueString(Account, out string account, 20))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Account));
            Fields.Account = account;

            if (!ValueChecker.CheckValueString(INN, out string inn, 10))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(INN));
            Fields.INN = inn;
        }
    }
}
