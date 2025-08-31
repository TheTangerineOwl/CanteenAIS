using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supply
{
    public class SupplyAddVM : BasicAddVM<Entities.SupplyEntity, Entities.Supply>
    {
        public SupplyAddVM(TableModel<Entities.SupplyEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            IdText = "0";
            Supplier = 0;
            Time = DateTime.Now;
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

        private int supplier;
        public int Supplier
        {
            get => supplier;
            set => Set(ref supplier, value);
        }

        private DateTime time;
        public DateTime Time
        {
            get => time;
            set
            {
                if (time == DateTime.MinValue)
                    time = value;
                if (!ValueChecker.CheckValueDateTime(value.ToString(), out DateTime _))
                    value = DateTime.Now;
                Set(ref time, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
            if (!ValueChecker.CheckValueUint(Supplier.ToString(), out uint supplier))
                throw new ArgumentException("Некорректный параметр!", nameof(Supplier));
            if (!ValueChecker.CheckValueDateTime(Time.ToString(), out DateTime time))
                throw new ArgumentException("Некорректный параметр!", nameof(Time));
            Fields.Id = id;
            Fields.SupplierId = supplier;
            Fields.DateTime = time;
        }
    }
}
