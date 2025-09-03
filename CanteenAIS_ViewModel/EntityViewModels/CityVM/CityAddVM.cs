using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.City
{
    public class CityAddVM : BasicAddVM<Entities.CityEntity, Entities.City>
    {
        public CityAddVM(TableModel<Entities.CityEntity> tableModel)
            : base(tableModel)
        {
            _name = string.Empty;
        }

        protected override void Clear()
        {
            Name = string.Empty;
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == null)
                    _name = value;
                if (!ValueChecker.CheckValueString(value, out value, 25, false))
                    value = "";
                Set(ref _name, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueString(Name, out string name, 25, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
            Fields.Name = name;
        }
    }
}
