using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Street
{
    public class StreetFilterVM : BasicFilterVM<Entities.StreetEntity, Entities.Street>
    {
        public StreetFilterVM(TableModel<Entities.StreetEntity> tableModel)
            : base(tableModel)
        {
            _cities = MainServices.GetInstance().Cities.FetchValues<Entities.City>().ToList();
            _city = Cities.FirstOrDefault();
            _cityCheck = false;
            _id = 0;
            _name = string.Empty;
        }

        protected override void Clear()
        {
            City = Cities.FirstOrDefault();
            Id = 0;
            Name = string.Empty;
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (!ValueChecker.CheckValueUint(value.ToString(), out uint _, true))
                    value = 0;
                Set(ref _id, value);
            }
        }

        private IList<Entities.City> _cities;
        public IList<Entities.City> Cities
        {
            get => _cities;
            set => Set(ref _cities, value);
        }

        private Entities.City _city;
        public Entities.City City
        {
            get => _city;
            set => Set(ref _city, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == null)
                    _name = value;
                if (!ValueChecker.CheckValueString(value, out value, 50, false))
                    value = "";
                Set(ref _name, value);
            }
        }

        private bool _idCheck;
        public bool IdCheck
        {
            get => _idCheck;
            set => Set(ref _idCheck, value);
        }

        private bool _cityCheck;
        public bool CityCheck
        {
            get => _cityCheck;
            set => Set(ref _cityCheck, value);
        }

        private bool _nameCheck;
        public bool NameCheck
        {
            get => _nameCheck;
            set => Set(ref _nameCheck, value);
        }

        public override void ParseFields()
        {
            if (_idCheck)
            {
                if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
                Fields.Id = id;
            }
            if (_cityCheck)
            {
                if (!ValueChecker.CheckValueUint(City.Id.ToString(), out uint city))
                    throw new ArgumentException("Некорректный параметр!");
                Fields.CityId = city;
            }
            if (_nameCheck)
            {
                if (!ValueChecker.CheckValueString(Name, out string name, 50, false))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
                Fields.Name = name;
            }
        }

        public override void Filter()
        {
            ParseFields();
            Model.FetchAndFilter<Entities.Street>((item) =>
                !(IdCheck && item.Id != Fields.Id) &&
                !(NameCheck && !item.Name.Contains(Fields.Name)) &&
                !(CityCheck && item.CityId != Fields.CityId)
            );
        }
    }
}
