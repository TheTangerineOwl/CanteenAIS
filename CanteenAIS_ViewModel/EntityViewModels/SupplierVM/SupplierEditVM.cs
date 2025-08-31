using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supplier
{
    public class SupplierEditVM : BasicEditVM<Entities.SupplierEntity, Entities.Supplier>
    {
        public SupplierEditVM(DataRow row, TableModel<Entities.SupplierEntity> tableModel)
            : base(row, tableModel) { }

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

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
            if (!ValueChecker.CheckValueString(NameText, out string name, 100, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(NameText));
            if (!ValueChecker.CheckValueUint(Street.ToString(), out uint street))
                throw new ArgumentException("Некорректный параметр!", nameof(Street));
            if (!ValueChecker.CheckValueString(BuildingText, out string building, 20, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(BuildingText));
            if (!ValueChecker.CheckValueUint(Head.ToString(), out uint head))
                throw new ArgumentException("Некорректный параметр!", nameof(Head));
            if (!ValueChecker.CheckValueUint(Bank.ToString(), out uint bank))
                throw new ArgumentException("Некорректный параметр!", nameof(Bank));
            if (!ValueChecker.CheckValueString(AccountText, out string account, 20, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(AccountText));
            if (!ValueChecker.CheckValueString(INNText, out string inn, 10, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(INNText));
            Fields.Id = id;
            Fields.Name = name;
            Fields.StreetId = street;
            Fields.Building = building;
            Fields.HeadId = head;
            Fields.BankId = bank;
            Fields.Account = account;
            Fields.INN = inn;
        }
    }
}
