using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Street
{
    public class StreetAddVM : BasicAddVM<Entities.StreetEntity, Entities.Street>
    {
        public StreetAddVM(TableModel<Entities.StreetEntity> tableModel)
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

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
            if (!ValueChecker.CheckValueUint(City.ToString(), out uint city))
                throw new ArgumentException("Некорректный параметр!");
            if (!ValueChecker.CheckValueString(NameText, out string name, 100, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(NameText));
            Fields.Id = id;
            Fields.CityId = city;
            Fields.Name = name;
        }
    }
}
