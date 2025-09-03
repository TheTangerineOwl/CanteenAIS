using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Realization
{
    public class RealizationFilterVM : BasicFilterVM<Entities.RealizationEntity, Entities.Realization>
    {
        public RealizationFilterVM(TableModel<Entities.RealizationEntity> tableModel)
            : base(tableModel)
        {
            _units = MainServices.GetInstance().MeasureUnits.FetchValues<Entities.MeasureUnit>().ToList();
            _unit = Units.FirstOrDefault();
            _unitCheck = false;
            _dishes = MainServices.GetInstance().Dishes.FetchValues<Entities.Dish>().ToList();
            _dish = Dishes.FirstOrDefault();
            _dishCheck = false;
            _amount = 0;
            _amountCheck = false;
            _dateTimePick = DateTime.Now;
            _timeCheck = false;
        }

        protected override void Clear()
        {
            Id = 0;
            IdCheck = false;
            Unit = Units.FirstOrDefault();
            UnitCheck = false;
            Dish = Dishes.FirstOrDefault();
            DishCheck = false;
            Amount = 0;
            AmountCheck = false;
            DateTimePick = DateTime.Now;
            TimeCheck = false;
        }

        private IList<Entities.MeasureUnit> _units;
        public IList<Entities.MeasureUnit> Units
        {
            get => _units;
            set => Set(ref _units, value);
        }

        private IList<Entities.Dish> _dishes;
        public IList<Entities.Dish> Dishes
        {
            get => _dishes;
            set => Set(ref _dishes, value);
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

        private Entities.MeasureUnit _unit;
        public Entities.MeasureUnit Unit
        {
            get => _unit;
            set => Set(ref _unit, value);
        }

        private Entities.Dish _dish;
        public Entities.Dish Dish
        {
            get => _dish;
            set => Set(ref _dish, value);
        }

        private double _amount;
        public double Amount
        {
            get => _amount;
            set
            {
                if (!ValueChecker.CheckValueDouble(value.ToString(), out double _, false))
                    value = 0;
                Set(ref _amount, value);
            }
        }

        private DateTime _dateTimePick;
        public DateTime DateTimePick
        {
            get => _dateTimePick;
            set
            {
                if (!ValueChecker.CheckValueDateTime(value.ToString(), out DateTime _))
                    value = DateTime.Now;
                Set(ref _dateTimePick, value);
            }
        }

        private bool _idCheck;
        public bool IdCheck
        {
            get => _idCheck;
            set => Set(ref _idCheck, value);
        }

        private bool _unitCheck;
        public bool UnitCheck
        {
            get => _unitCheck;
            set => Set(ref _unitCheck, value);
        }

        private bool _dishCheck;
        public bool DishCheck
        {
            get => _dishCheck;
            set => Set(ref _dishCheck, value);
        }

        private bool _amountCheck;
        public bool AmountCheck
        {
            get => _amountCheck;
            set => Set(ref _amountCheck, value);
        }

        private bool _timeCheck;
        public bool TimeCheck
        {
            get => _timeCheck;
            set => Set(ref _timeCheck, value);
        }

        public override void ParseFields()
        {
            if (_idCheck)
            {
                if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
                Fields.Id = id;
            }
            if (_unitCheck)
            {
                if (!ValueChecker.CheckValueUint(Unit.Id.ToString(), out uint unit))
                    throw new ArgumentException("Некорректный параметр!", nameof(Unit.Id));
                Fields.UnitId = unit;
            }
            if (_dishCheck)
            {
                if (!ValueChecker.CheckValueUint(Dish.Id.ToString(), out uint dish))
                    throw new ArgumentException("Некорректный параметр!", nameof(Dish.Id));
                Fields.DishId = dish;
            }
            if (_amountCheck)
            {
                if (!ValueChecker.CheckValueDouble(Amount.ToString(), out double amount))
                    throw new ArgumentException("Некорректный параметр!", nameof(Amount));
                Fields.Amount = amount;
            }
            if (_timeCheck)
            {
                if (!ValueChecker.CheckValueDateTime(DateTimePick.ToString(), out DateTime time))
                    throw new ArgumentException("Некорректное время!", nameof(DateTimePick));
                Fields.DateTime = time;
            }
        }

        public override void Filter()
        {
            ParseFields();
            Model.FetchAndFilter<Entities.Realization>((item) =>
                !(IdCheck && item.Id != Fields.Id) &&
                !(UnitCheck && item.UnitId != Fields.UnitId) &&
                !(DishCheck && item.DishId != Fields.DishId) &&
                !(AmountCheck && item.Amount != Fields.Amount) &&
                !(TimeCheck && item.DateTime != Fields.DateTime)
            );
        }
    }
}
