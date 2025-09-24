using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Realization
{
    public class RealizationAddVM : BasicAddVM<Entities.RealizationEntity, Entities.Realization>
    {
        public RealizationAddVM(TableModel<Entities.RealizationEntity> tableModel)
            : base(tableModel)
        {
            _id = 1;
            _dishes = MainServices.GetInstance().Dishes.FetchValues<Entities.Dish>().ToList();
            _dish = Dishes.FirstOrDefault();
            _units = MainServices.GetInstance().MeasureUnits.FetchValues<Entities.MeasureUnit>().ToList();
            _unit = Units.Where(item => item.Id == _dish.UnitId).FirstOrDefault() ?? Units.FirstOrDefault();
            _amount = 0;
            _dateTimePick = DateTime.Now;
        }

        protected override void Clear()
        {
            Id = 1;
            Unit = Units.Where(item => item.Id == _dish.UnitId).FirstOrDefault() ?? Units.FirstOrDefault();
            Dish = Dishes.FirstOrDefault();
            Amount = 0;
            DateTimePick = DateTime.Now;
        }

        private uint _id;
        public uint Id
        {
            get => _id;
            set
            {
                if (!ValueChecker.CheckValueUint(value.ToString(), out _))
                    value = 1;
                Set(ref _id, value);
            }
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
            set
            {
                Set(ref _dish, value);
                Unit = Units.Where(item => item.Id == value.UnitId).FirstOrDefault() ?? Units.FirstOrDefault();
            }
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

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, false))
                throw new ArgumentNullException("Некорректное значение!", nameof(Id));
            Fields.Id = id;

            if (!ValueChecker.CheckValueUint(Unit.Id.ToString(), out uint unit))
                throw new ArgumentException("Некорректный параметр!", nameof(Unit.Id));
            Fields.UnitId = unit;

            if (!ValueChecker.CheckValueUint(Dish.Id.ToString(), out uint dish))
                throw new ArgumentException("Некорректный параметр!", nameof(Dish.Id));
            Fields.DishId = dish;

            if (!ValueChecker.CheckValueDouble(Amount.ToString(), out double amount))
                throw new ArgumentException("Некорректный параметр!", nameof(Amount));
            Fields.Amount = amount;

            if (!ValueChecker.CheckValueDateTime(DateTimePick.ToString(), out DateTime time))
                throw new ArgumentException("Некорректное время!", nameof(DateTimePick));
            Fields.DateTime = time;
        }
    }
}
