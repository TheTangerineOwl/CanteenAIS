using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Realization
{
    public class RealizationFilterVM : BasicFilterVM<Entities.RealizationEntity, Entities.Realization>
    {
        public RealizationFilterVM(TableModel<Entities.RealizationEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            IdText = "0";
            idCheck = false;
            Unit = 0;
            unitCheck = false;
            Dish = 0;
            dishCheck = false;
            AmountText = "0";
            amountCheck = false;
            DateTimeFill = DateTime.Now;
            timeCheck = false;
        }

        private string idText;
        public string IdText
        {
            get => idText;
            set
            {
                if (idText == null)
                    idText = value;
                if (!ValueChecker.CheckValueUint(value, out uint _, true))
                    value = "1";
                Set(ref idText, value);
            }
        }

        private int unit;
        public int Unit
        {
            get => unit;
            set => Set(ref unit, value);
        }

        private int dish;
        public int Dish
        {
            get => dish;
            set => Set(ref dish, value);
        }

        private string amountText;
        public string AmountText
        {
            get => amountText;
            set
            {
                if (amountText == null)
                    amountText = value;
                if (!ValueChecker.CheckValueDouble(value, out double _, false))
                    value = "0";
                Set(ref amountText, value);
            }
        }

        private DateTime dateTimeFill;
        public DateTime DateTimeFill
        {
            get => dateTimeFill;
            set
            {
                if (!ValueChecker.CheckValueDateTime(value.ToString(), out DateTime _))
                    value = DateTime.Now;
                Set(ref dateTimeFill, value);
            }
        }

        private bool idCheck;
        public bool IdCheck
        {
            get => idCheck;
            set => Set(ref idCheck, value);
        }

        private bool unitCheck;
        public bool UnitCheck
        {
            get => unitCheck;
            set => Set(ref unitCheck, value);
        }

        private bool dishCheck;
        public bool DishCheck
        {
            get => dishCheck;
            set => Set(ref dishCheck, value);
        }

        private bool amountCheck;
        public bool AmountCheck
        {
            get => amountCheck;
            set => Set(ref amountCheck, value);
        }

        private bool timeCheck;
        public bool TimeCheck
        {
            get => timeCheck;
            set => Set(ref timeCheck, value);
        }

        public override void ParseFields()
        {
            if (idCheck)
            {
                if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
                Fields.Id = id;
            }
            if (unitCheck)
            {
                if (!ValueChecker.CheckValueUint(Unit.ToString(), out uint unit))
                    throw new ArgumentException("Некорректный параметр!", nameof(Unit));
                Fields.UnitId = unit;
            }
            if (dishCheck)
            {
                if (!ValueChecker.CheckValueUint(Dish.ToString(), out uint dish))
                    throw new ArgumentException("Некорректный параметр!", nameof(Dish));
                Fields.DishId = dish;
            }
            if (amountCheck)
            {
                if (!ValueChecker.CheckValueDouble(AmountText, out double amount))
                    throw new ArgumentException("Некорректный параметр!", nameof(AmountText));
                Fields.Amount = amount;
            }
            if (timeCheck)
            {
                if (!ValueChecker.CheckValueDateTime(DateTimeFill.ToString(), out DateTime time))
                    throw new ArgumentException("Некорректное время!", nameof(DateTimeFill));
                Fields.DateTime = time;
            }
        }
    }
}
