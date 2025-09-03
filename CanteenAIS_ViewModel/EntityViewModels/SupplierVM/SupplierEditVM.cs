using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supplier
{
    public class SupplierEditVM : BasicEditVM<Entities.SupplierEntity, Entities.Supplier>
    {
        public SupplierEditVM(DataRow row, TableModel<Entities.SupplierEntity> tableModel)
            : base(row, tableModel)
        {
            _streets = MainServices.GetInstance().Streets.FetchValues<Entities.Street>().ToList();
            _street = Streets.Where(item => item.Id == Fields.StreetId).FirstOrDefault();
            _heads = MainServices.GetInstance().SupplierHeads.FetchValues<Entities.SupplierHead>().ToList();
            _head = Heads.Where(item => item.Id == Fields.HeadId).FirstOrDefault();
            _banks = MainServices.GetInstance().Banks.FetchValues<Entities.Bank>().ToList();
            _bank = Banks.Where(item => item.Id == Fields.BankId).FirstOrDefault();
            _id = (int)Fields.Id;
            _name = Fields.Name;
            _building = Fields.Building;
            _account = Fields.Account;
            _inn = Fields.INN;
        }

        protected override void Clear()
        {
            Street = Streets.Where(item => item.Id == Fields.StreetId).FirstOrDefault();
            Head = Heads.Where(item => item.Id == Fields.HeadId).FirstOrDefault();
            Bank = Banks.Where(item => item.Id == Fields.BankId).FirstOrDefault();
            Id = (int)Fields.Id;
            Name = Fields.Name;
            Building = Fields.Building;
            Account = Fields.Account;
            INN = Fields.INN;
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
                    value = (int)Fields.Id;
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
                    value = Fields.Name;
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
                    value = Fields.Building;
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
                    value = Fields.Account;
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
                    value = Fields.INN;
                Set(ref _inn, value);
            }
        }

        public override void ParseFields()
        {

                if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
                Fields.Id = id;

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

                if (!ValueChecker.CheckValueString(Building, out string building, 16))
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
