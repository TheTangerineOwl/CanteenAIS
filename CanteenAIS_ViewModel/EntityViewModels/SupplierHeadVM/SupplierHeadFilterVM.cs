using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.SupplierHead
{
    public class SupplierHeadFilterVM : BasicFilterVM<Entities.SupplierHeadEntity, Entities.SupplierHead>
    {
        public SupplierHeadFilterVM(TableModel<Entities.SupplierHeadEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            IdText = "0";
            idCheck = false;
            LastNameText = string.Empty;
            lastNameCheck = false;
            FirstNameText = string.Empty;
            firstNameCheck = false;
            PatronimText = string.Empty;
            patronimCheck = false;
            PhoneText = string.Empty;
            phoneCheck = false;
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
                    value = "1";
                Set(ref idText, value);
            }
        }

        private string lastNameText;
        public string LastNameText
        {
            get => lastNameText;
            set
            {
                if (lastNameText == null)
                    lastNameText = value;
                if (!ValueChecker.CheckValueString(value, out value, 50, false))
                    value = "";
                Set(ref lastNameText, value);
            }
        }

        private string firstNameText;
        public string FirstNameText
        {
            get => firstNameText;
            set
            {
                if (firstNameText == null)
                    firstNameText = value;
                if (!ValueChecker.CheckValueString(value, out value, 50, false))
                    value = "";
                Set(ref firstNameText, value);
            }
        }

        private string patronimText;
        public string PatronimText
        {
            get => patronimText;
            set
            {
                if (patronimText == null)
                    patronimText = value;
                if (!ValueChecker.CheckValueString(value, out value, 50, false))
                    value = "";
                Set(ref patronimText, value);
            }
        }

        private string phoneText;
        public string PhoneText
        {
            get => phoneText;
            set
            {
                if (phoneText == null)
                    phoneText = value;
                if (!ValueChecker.CheckValueString(value, out value, 13, false))
                    value = "";
                Set(ref phoneText, value);
            }
        }

        private bool idCheck;
        public bool IdCheck
        {
            get => idCheck;
            set => Set(ref idCheck, value);
        }

        private bool lastNameCheck;
        public bool LastNameCheck
        {
            get => lastNameCheck;
            set => Set(ref lastNameCheck, value);
        }

        private bool firstNameCheck;
        public bool FirstNameCheck
        {
            get => firstNameCheck;
            set => Set(ref firstNameCheck, value);
        }

        private bool patronimCheck;
        public bool PatronimCheck
        {
            get => patronimCheck;
            set => Set(ref patronimCheck, value);
        }

        private bool phoneCheck;
        public bool PhoneCheck
        {
            get => phoneCheck;
            set => Set(ref phoneCheck, value);
        }

        public override void ParseFields()
        {
            if (idCheck)
            {
                if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
                Fields.Id = id;
            }
            if (lastNameCheck)
            {
                if (!ValueChecker.CheckValueString(LastNameText, out string lastName, 50, false))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(LastNameText));
                Fields.LastName = lastName;
            }
            if (firstNameCheck)
            {
                if (!ValueChecker.CheckValueString(FirstNameText, out string firstName, 50, false))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(FirstNameText));
                Fields.FirstName = firstName;
            }
            if (patronimCheck)
            {
                if (!ValueChecker.CheckValueString(PatronimText, out string patronim, 50, false))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(PatronimText));
                Fields.Patronim = patronim;
            }
            if (phoneCheck)
            {
                if (!ValueChecker.CheckValueString(PhoneText, out string phone, 13, false))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(PhoneText));
                Fields.Phone = phone;
            }
        }
    }
}
