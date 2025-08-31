using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Realization
{
    public class RealizationEditVM : BasicEditVM<Entities.RealizationEntity, Entities.Realization>
    {
        public RealizationEditVM(DataRow row, TableModel<Entities.RealizationEntity> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            IdText = Fields.Id.ToString();
            Unit = (int)Fields.UnitId;
            Dish = (int)Fields.DishId;
            AmountText = Fields.Amount.ToString();
            DateTimeFill = Fields.DateTime;
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

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
            if (!ValueChecker.CheckValueUint(Unit.ToString(), out uint unit))
                throw new ArgumentException("Некорректный параметр!", nameof(Unit));
            if (!ValueChecker.CheckValueUint(Dish.ToString(), out uint dish))
                throw new ArgumentException("Некорректный параметр!", nameof(Dish));
            if (!ValueChecker.CheckValueDouble(AmountText, out double amount))
                throw new ArgumentException("Некорректный параметр!", nameof(AmountText));
            if (!ValueChecker.CheckValueDateTime(DateTimeFill.ToString(), out DateTime time))
                throw new ArgumentException("Некорректное время!", nameof(DateTimeFill));
            Fields.Id = id;
            Fields.UnitId = unit;
            Fields.DishId = dish;
            Fields.Amount = amount;
            Fields.DateTime = time;
        }
    }
}
