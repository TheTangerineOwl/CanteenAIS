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
            : base(row, tableModel) { }

        protected override void Clear()
        {
            IdText = Fields.Id.ToString();
            LastNameText = Fields.LastName;
            FirstNameText = Fields.FirstName;
            PatronimText = Fields.Patronim;
            PhoneText = Fields.Phone;
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

        private string lastNameText;
        public string LastNameText
        {
            get => lastNameText;
            set
            {
                if (lastNameText == null)
                    lastNameText = value;
                if (!ValueChecker.CheckValueString(value, out value, 50, false))
                    value = Fields.LastName;
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
                    value = Fields.FirstName;
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
                    value = Fields.Patronim;
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
                    value = Fields.Phone;
                Set(ref phoneText, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
            if (!ValueChecker.CheckValueString(LastNameText, out string lastName, 50, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(LastNameText));
            if (!ValueChecker.CheckValueString(FirstNameText, out string firstName, 50, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(FirstNameText));
            if (!ValueChecker.CheckValueString(PatronimText, out string patronim, 50, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(PatronimText));
            if (!ValueChecker.CheckValueString(PhoneText, out string phone, 13, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(PhoneText));
            Fields.Id = id;
            Fields.LastName = lastName;
            Fields.FirstName = firstName;
            Fields.Patronim = patronim;
            Fields.Phone = phone;
        }
    }
}
