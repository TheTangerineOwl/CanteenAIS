using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Street
{
    public class StreetAddVM : BasicAddVM<Entities.StreetEntity, Entities.Street>
    {
        public StreetAddVM(TableModel<Entities.StreetEntity> tableModel)
            : base(tableModel)
        {
            _cities = MainServices.GetInstance().Cities.FetchValues<Entities.City>().ToList();
            _city = Cities.FirstOrDefault();
            _name = string.Empty;
        }

        protected override void Clear()
        {
            City = Cities.FirstOrDefault();
            Name = string.Empty;
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

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(City.Id.ToString(), out uint city))
                throw new ArgumentException("Некорректный параметр!");
            Fields.CityId = city;

            if (!ValueChecker.CheckValueString(Name, out string name, 50, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
            Fields.Name = name;
        }
    }
}
