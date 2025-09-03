using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Dish
{
    public class DishAddVM : BasicAddVM<Entities.DishEntity, Entities.Dish>
    {
        public DishAddVM(TableModel<Entities.DishEntity> tableModel)
            : base(tableModel)
        {
            _units = MainServices.GetInstance().MeasureUnits.FetchValues<Entities.MeasureUnit>().ToList();
            _unit = Units.FirstOrDefault();
            _groups = MainServices.GetInstance().AssortmentGroups.FetchValues<Entities.AssortmentGroup>().ToList();
            _group = Groups.FirstOrDefault();
            _name = string.Empty;
            _price = 0;
            _serving = 0;
            _recipe = string.Empty;
            _picture = string.Empty;
        }

        protected override void Clear()
        {
            Unit = Units.FirstOrDefault();
            Group = Groups.FirstOrDefault();
            Name = string.Empty;
            Price = 0;
            Serving = 0;
            Recipe = string.Empty;
            Picture = string.Empty;
        }

        private IList<Entities.MeasureUnit> _units;
        public IList<Entities.MeasureUnit> Units
        {
            get => _units;
            set => Set(ref _units, value);
        }

        private IList<Entities.AssortmentGroup> _groups;
        public IList<Entities.AssortmentGroup> Groups
        {
            get => _groups;
            set => Set(ref _groups, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == null)
                    _name = value;
                if (!ValueChecker.CheckValueString(value, out value, 100, false))
                    value = "";
                Set(ref _name, value);
            }
        }

        private Entities.AssortmentGroup _group;
        public Entities.AssortmentGroup Group
        {
            get => _group;
            set => Set(ref _group, value);
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                if (!ValueChecker.CheckValueDecimal(value.ToString(), out decimal _))
                    value = 0;
                Set(ref _price, value);
            }
        }

        private double _serving;
        public double Serving
        {
            get => _serving;
            set
            {
                if (!ValueChecker.CheckValueDouble(value.ToString(), out double _))
                    value = 0;
                Set(ref _serving, value);
            }
        }

        private Entities.MeasureUnit _unit;
        public Entities.MeasureUnit Unit
        {
            get => _unit;
            set => Set(ref _unit, value);
        }

        private string _recipe;
        public string Recipe
        {
            get => _recipe;
            set
            {
                if (_recipe == null)
                    _recipe = value;
                if (!ValueChecker.CheckValueString(value, out value, 2500, true))
                    value = "";
                Set(ref _recipe, value);
            }
        }

        private string _picture;
        public string Picture
        {
            get => _picture;
            set
            {
                if (_picture == null)
                    _picture = value;
                if (!ValueChecker.CheckValueString(value, out value, 200, true))
                    value = "";
                Set(ref _picture, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueString(Name, out string name, 100))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
            Fields.Name = name;
            if (!ValueChecker.CheckValueUint(Group.Id.ToString(), out uint group))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Group.Id));
            Fields.GroupId = group;
            if (!ValueChecker.CheckValueDecimal(Price.ToString(), out decimal price))
                throw new ArgumentException("Некорректное значение параметра!", nameof(Price));
            Fields.Price = price;
            if (!ValueChecker.CheckValueDouble(Serving.ToString(), out double serving))
                throw new ArgumentException("Некорректное значение параметра!", nameof(Serving));
            Fields.Serving = serving;
            if (!ValueChecker.CheckValueUint(Unit.Id.ToString(), out uint unit))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Unit.Id));
            Fields.UnitId = unit;

            if (!ValueChecker.CheckValueString(Recipe, out string recipe, 2500))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Recipe));
            Fields.Recipe = recipe;

            if (!ValueChecker.CheckValueString(Picture, out string picture, 200))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Picture));
            Fields.Picture = picture;
        }
    }
}
