using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supplier
{
    public class SupplierFilterVM : BasicFilterVM<Entities.SupplierEntity, Entities.Supplier>
    {
        public SupplierFilterVM(TableModel<Entities.SupplierEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            IdText = Fields.Id.ToString();
            NameText = Fields.Name;
            Street = (int)Fields.StreetId;
            BuildingText = Fields.Building;
            Head = (int)Fields.HeadId;
            Bank = (int)Fields.BankId;
            AccountText = Fields.Account;
            INNText = Fields.INN;
        }

        private string idText;
        public string IdText
        {
            get => idText;
            set
            {
                if (idText == null)
                    idText = value;
                if (!ValueChecker.CheckValueUint(value, out uint _, true))
                    value = Fields.Id.ToString();
                Set(ref idText, value);
            }
        }

        private string nameText;
        public string NameText
        {
            get => nameText;
            set
            {
                if (nameText == null)
                    nameText = value;
                if (!ValueChecker.CheckValueString(value, out value, 100, false))
                    value = Fields.Name;
                Set(ref nameText, value);
            }
        }

        private int street;
        public int Street
        {
            get => street;
            set => Set(ref street, value);
        }

        private string buildingText;
        public string BuildingText
        {
            get => buildingText;
            set
            {
                if (buildingText == null)
                    buildingText = value;
                if (!ValueChecker.CheckValueString(value, out value, 20, false))
                    value = Fields.Building;
                Set(ref buildingText, value);
            }
        }

        private int head;
        public int Head
        {
            get => head;
            set => Set(ref head, value);
        }

        private int bank;
        public int Bank
        {
            get => bank;
            set => Set(ref bank, value);
        }

        private string accountText;
        public string AccountText
        {
            get => accountText;
            set
            {
                if (accountText == null)
                    accountText = value;
                if (!ValueChecker.CheckValueString(value, out value, 20))
                    value = Fields.Account;
                Set(ref accountText, value);
            }
        }

        private string innText;
        public string INNText
        {
            get => innText;
            set
            {
                if (innText == null)
                    innText = value;
                if (!ValueChecker.CheckValueString(value, out value, 10))
                    value = Fields.INN;
                Set(ref innText, value);
            }
        }

        private bool idCheck;
        public bool IdCheck
        {
            get => idCheck;
            set => Set(ref idCheck, value);
        }

        private bool nameCheck;
        public bool NameCheck
        {
            get => nameCheck;
            set => Set(ref nameCheck, value);
        }

        private bool streetCheck;
        public bool StreetCheck
        {
            get => streetCheck;
            set => Set(ref streetCheck, value);
        }

        private bool buildingCheck;
        public bool BuildingCheck
        {
            get => buildingCheck;
            set => Set(ref buildingCheck, value);
        }

        private bool headCheck;
        public bool HeadCheck
        {
            get => headCheck;
            set => Set(ref headCheck, value);
        }

        private bool bankCheck;
        public bool BankCheck
        {
            get => bankCheck;
            set => Set(ref bankCheck, value);
        }

        private bool accountCheck;
        public bool AccountCheck
        {
            get => accountCheck;
            set => Set(ref accountCheck, value);
        }

        private bool innCheck;
        public bool INNCheck
        {
            get => innCheck;
            set => Set(ref innCheck, value);
        }

        public override void ParseFields()
        {
            if (idCheck)
            {
                if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
                Fields.Id = id;
            }
            if (nameCheck)
            {
                if (!ValueChecker.CheckValueString(NameText, out string name, 100, false))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(NameText));
                Fields.Name = name;
            }
            if (streetCheck)
            {
                if (!ValueChecker.CheckValueUint(Street.ToString(), out uint street))
                    throw new ArgumentException("Некорректный параметр!", nameof(Street));
                Fields.StreetId = street;
            }
            if (buildingCheck)
            {
                if (!ValueChecker.CheckValueString(BuildingText, out string building, 20, false))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(BuildingText));
                Fields.Building = building;
            }
            if (headCheck)
            {
                if (!ValueChecker.CheckValueUint(Head.ToString(), out uint head))
                    throw new ArgumentException("Некорректный параметр!", nameof(Head));
                Fields.HeadId = head;
            }
            if (bankCheck)
            {
                if (!ValueChecker.CheckValueUint(Bank.ToString(), out uint bank))
                    throw new ArgumentException("Некорректный параметр!", nameof(Bank));
                Fields.BankId = bank;
            }
            if (accountCheck)
            {
                if (!ValueChecker.CheckValueString(AccountText, out string account, 20, false))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(AccountText));
                Fields.Account = account;
            }
            if (innCheck)
            {
                if (!ValueChecker.CheckValueString(INNText, out string inn, 10, false))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(INNText));
                Fields.INN = inn;
            }
        }
    }
}
