using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Street
{
    public class StreetFilterVM : BasicFilterVM<Entities.StreetEntity, Entities.Street>
    {
        public StreetFilterVM(TableModel<Entities.StreetEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            IdText = "0";
            NameText = string.Empty;
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

        private int city;
        public int City
        {
            get => city;
            set => Set(ref city, value);
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
                    value = "";
                Set(ref nameText, value);
            }
        }

        private bool idCheck;
        public bool IdCheck
        {
            get => idCheck;
            set => Set(ref idCheck, value);
        }

        private bool cityCheck;
        public bool CityCheck
        {
            get => cityCheck;
            set => Set(ref cityCheck, value);
        }

        private bool nameCheck;
        public bool NameCheck
        {
            get => nameCheck;
            set => Set(ref nameCheck, value);
        }

        public override void ParseFields()
        {
            if (idCheck)
            {
                if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
                Fields.Id = id;
            }
            if (cityCheck)
            {
                if (!ValueChecker.CheckValueUint(City.ToString(), out uint city))
                    throw new ArgumentException("Некорректный параметр!");
                Fields.CityId = city;
            }
            if (nameCheck)
            {
                if (!ValueChecker.CheckValueString(NameText, out string name, 100, false))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(NameText));
                Fields.Name = name;
            }
        }
    }
}
