using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.City
{
    public class CityEditVM : BasicEditVM<Entities.CityEntity, Entities.City>
    {
        public CityEditVM(DataRow row, TableModel<Entities.CityEntity> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            IdText = Fields.Id.ToString();
            NameText = Fields.Name;
        }

        private string idText;
        public string IdText
        {
            get => idText;
            set
            {
                if (idText == null)
                    idText = value;
                if (!ValueChecker.CheckValueUint(value, out uint _, false))
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
                if (!ValueChecker.CheckValueString(value, out value, 25, false))
                    value = Fields.Name;
                Set(ref nameText, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(IdText, out uint id))
                throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
            if (!ValueChecker.CheckValueString(NameText, out string name, 25, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(NameText));
            Fields.Id = id;
            Fields.Name = name;
        }
    }
}
