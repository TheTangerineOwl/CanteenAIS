using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Dish
{
    public class DishFilterVM : BasicFilterVM<Entities.DishEntity, Entities.Dish>
    {
        public DishFilterVM(TableModel<Entities.DishEntity> tableModel)
            : base(tableModel)
        {
            _units = MainServices.GetInstance().MeasureUnits.FetchValues<Entities.MeasureUnit>().ToList();
            _unit = Units.FirstOrDefault();
            _unitCheck = false;
            _groups = MainServices.GetInstance().AssortmentGroups.FetchValues<Entities.AssortmentGroup>().ToList();
            _group = Groups.FirstOrDefault();
            _groupCheck = false;
            _id = 0;
            _idCheck = false;
            _name = string.Empty;
            _nameCheck = false;
            _price = 0;
            _priceCheck = false;
            _serving = 0;
            _servingCheck = false;
            _recipe = string.Empty;
            _recipeCheck = false;
            _picture = string.Empty;
            _pictureCheck = false;
        }

        protected override void Clear()
        {
            Unit = Units.FirstOrDefault();
            UnitCheck = false;
            Group = Groups.FirstOrDefault();
            GroupCheck = false;
            Id = 0;
            IdCheck = false;
            Name = string.Empty;
            NameCheck = false;
            Price = 0;
            PriceCheck = false;
            Serving = 0;
            ServingCheck = false;
            Recipe = string.Empty;
            RecipeCheck = false;
            Picture = string.Empty;
            PictureCheck = false;
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

        private bool _idCheck;
        public bool IdCheck
        {
            get => _idCheck;
            set => Set(ref _idCheck, value);
        }

        private bool _nameCheck;
        public bool NameCheck
        {
            get => _nameCheck;
            set => Set(ref _nameCheck, value);
        }

        private bool _groupCheck;
        public bool GroupCheck
        {
            get => _groupCheck;
            set => Set(ref _groupCheck, value);
        }

        private bool _priceCheck;
        public bool PriceCheck
        {
            get => _priceCheck;
            set => Set(ref _priceCheck, value);
        }

        private bool _servingCheck;
        public bool ServingCheck
        {
            get => _servingCheck;
            set => Set(ref _servingCheck, value);
        }

        private bool _unitCheck;
        public bool UnitCheck
        {
            get => _unitCheck;
            set => Set(ref _unitCheck, value);
        }

        private bool _recipeCheck;
        public bool RecipeCheck
        {
            get => _recipeCheck;
            set => Set(ref _recipeCheck, value);
        }

        private bool _pictureCheck;
        public bool PictureCheck
        {
            get => _pictureCheck;
            set => Set(ref _pictureCheck, value);
        }

        public override void ParseFields()
        {
            if (_idCheck)
            {
                if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
                Fields.Id = id;
            }
            if (_nameCheck)
            {
                if (!ValueChecker.CheckValueString(Name, out string name, 100))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
                Fields.Name = name;
            }
            if (_groupCheck)
            {
                if (!ValueChecker.CheckValueUint(Group.Id.ToString(), out uint group))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Group.Id));
                Fields.GroupId = group;
            }
            if (_priceCheck)
            {
                if (!ValueChecker.CheckValueDecimal(Price.ToString(), out decimal price))
                    throw new ArgumentException("Некорректное значение параметра!", nameof(Price));
                Fields.Price = price;
            }
            if (_servingCheck)
            {
                if (!ValueChecker.CheckValueDouble(Serving.ToString(), out double serving))
                    throw new ArgumentException("Некорректное значение параметра!", nameof(Serving));
                Fields.Serving = serving;
            }
            if (_unitCheck)
            {
                if (!ValueChecker.CheckValueUint(Unit.Id.ToString(), out uint unit))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Unit.Id));
                Fields.UnitId = unit;
            }
            if (_recipeCheck)
            {
                if (!ValueChecker.CheckValueString(Recipe, out string recipe, 2500))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(Recipe));
                Fields.Recipe = recipe;
            }
            if (_pictureCheck)
            {
                if (!ValueChecker.CheckValueString(Picture, out string picture, 200))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(Picture));
                Fields.Picture = picture;
            }
        }

        public override void Filter()
        {
            ParseFields();
            Model.FetchAndFilter<Entities.Dish>((item) =>
                !(IdCheck && item.Id != Fields.Id) &&
                !(NameCheck && !item.Name.Contains(Fields.Name)) &&
                !(GroupCheck && item.GroupId != Fields.GroupId) &&
                !(PriceCheck && item.Price != Fields.Price) &&
                !(ServingCheck && item.Serving != Fields.Serving) &&
                !(UnitCheck && item.UnitId != Fields.UnitId) &&
                !(RecipeCheck && !item.Recipe.Contains(Fields.Recipe)) &&
                !(PictureCheck && !item.Picture.Contains(Fields.Picture))
            );
        }
    }
}
