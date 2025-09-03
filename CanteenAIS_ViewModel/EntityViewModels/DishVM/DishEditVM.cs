using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Dish
{
    public class DishEditVM : BasicEditVM<Entities.DishEntity, Entities.Dish>
    {
        public DishEditVM(DataRow row, TableModel<Entities.DishEntity> tableModel)
            : base(row, tableModel)
        {
            _units = MainServices.GetInstance().MeasureUnits.FetchValues<Entities.MeasureUnit>().ToList();
            _unit = Units.Where(item => item.Id == Fields.UnitId).FirstOrDefault();
            _groups = MainServices.GetInstance().AssortmentGroups.FetchValues<Entities.AssortmentGroup>().ToList();
            _group = Groups.Where(item => item.Id == Fields.GroupId).FirstOrDefault();
            _id = Fields.Id;
            _name = Fields.Name;
            _price = Fields.Price;
            _serving = Fields.Serving;
            _recipe = Fields.Recipe;
            _picture = Fields.Picture;
        }

        protected override void Clear()
        {
            Unit = Units.Where(item => item.Id == Fields.UnitId).FirstOrDefault();
            Group = Groups.Where(item => item.Id == Fields.GroupId).FirstOrDefault();
            Id = Fields.Id;
            Name = Fields.Name;
            Price = Fields.Price;
            Serving = Fields.Serving;
            Recipe = Fields.Recipe;
            Picture = Fields.Picture;
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

        private uint _id;
        public uint Id
        {
            get => _id;
            set
            {
                if (!ValueChecker.CheckValueUint(value.ToString(), out uint _, true))
                    value = Fields.Id;
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
                if (!ValueChecker.CheckValueString(value, out value, 100, false))
                    value = Fields.Name;
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
                    value = Fields.Price;
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
                    value = Fields.Serving;
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
                    value = Fields.Recipe;
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
                    value = Fields.Picture;
                Set(ref _picture, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
            Fields.Id = id;
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
