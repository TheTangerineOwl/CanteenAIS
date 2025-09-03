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
            : base(row, tableModel)
        {
            _id = (int)Fields.Id;
            _name = Fields.Name;
        }

        protected override void Clear()
        {
            Id = (int)Fields.Id;
            Name = Fields.Name;
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (!ValueChecker.CheckValueUint(value.ToString(), out uint _, false))
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
                if (!ValueChecker.CheckValueString(value, out value, 25, false))
                    value = Fields.Name;
                Set(ref _name, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
            if (!ValueChecker.CheckValueString(Name, out string name, 25, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
            Fields.Id = id;
            Fields.Name = name;
        }
    }
}
