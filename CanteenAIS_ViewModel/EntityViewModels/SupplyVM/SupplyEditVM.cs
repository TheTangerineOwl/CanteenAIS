using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supply
{
    public class SupplyEditVM : BasicEditVM<Entities.SupplyEntity, Entities.Supply>
    {
        public SupplyEditVM(DataRow row, TableModel<Entities.SupplyEntity> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            IdText = Fields.Id.ToString();
            Supplier = (int)Fields.SupplierId;
            Time = Fields.DateTime;
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
                    value = Fields.Id.ToString();
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
                    value = Fields.DateTime;
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
