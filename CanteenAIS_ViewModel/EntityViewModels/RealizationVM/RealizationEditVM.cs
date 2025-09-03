using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Realization
{
    public class RealizationEditVM : BasicEditVM<Entities.RealizationEntity, Entities.Realization>
    {
        public RealizationEditVM(DataRow row, TableModel<Entities.RealizationEntity> tableModel)
            : base(row, tableModel)
        {
            _id = (int)Fields.Id;
            _units = MainServices.GetInstance().MeasureUnits.FetchValues<Entities.MeasureUnit>().ToList();
            _unit = Units.Where(item => item.Id == Fields.UnitId).FirstOrDefault();
            _dishes = MainServices.GetInstance().Dishes.FetchValues<Entities.Dish>().ToList();
            _dish = Dishes.Where(item => item.Id == Fields.DishId).FirstOrDefault();
            _amount = Fields.Amount;
            _dateTimePick = Fields.DateTime;
        }

        protected override void Clear()
        {
            Id = (int)Fields.Id;
            Unit = Units.Where(item => item.Id == Fields.UnitId).FirstOrDefault();
            Dish = Dishes.Where(item => item.Id == Fields.DishId).FirstOrDefault();
            Amount = Fields.Amount;
            DateTimePick = Fields.DateTime;
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
                    value = (int)Fields.Id;
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
                    value = Fields.Amount;
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
                    value = Fields.DateTime;
                Set(ref _dateTimePick, value);
            }
        }

        public override void ParseFields()
        {

            if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
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
