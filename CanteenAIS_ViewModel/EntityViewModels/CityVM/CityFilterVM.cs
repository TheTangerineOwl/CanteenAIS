using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.City
{
    public class CityFilterVM : BasicFilterVM<Entities.CityEntity, Entities.City>
    {
        public CityFilterVM(TableModel<Entities.CityEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            IdText = "0";
            IdCheck = false;
            NameText = string.Empty;
            NameCheck = false;
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
                    value = "0";
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
                if (!ValueChecker.CheckValueString(value, out value, 50, true))
                    value = "";
                Set(ref nameText, value);
            }
        }

        private bool idCheck = false;
        public bool IdCheck
        {
            get => idCheck;
            set => Set(ref idCheck, value);
        }

        private bool nameCheck = false;
        public bool NameCheck
        {
            get => nameCheck;
            set => Set(ref nameCheck, value);
        }


        public override void ParseFields()
        {
            if (IdCheck)
            {
                if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
                Fields.Id = id;
            }
            if (NameCheck)
            {
                if (!ValueChecker.CheckValueString(NameText, out string name, 50, true))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(NameText));
                Fields.Name = name;
            }
        }
    }
}
