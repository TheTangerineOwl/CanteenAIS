using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supply
{
    public class SupplyEditVM : BasicEditVM<Entities.SupplyEntity, Entities.Supply>
    {
        public SupplyEditVM(DataRow row, TableModel<Entities.SupplyEntity> tableModel)
            : base(row, tableModel)
        {
            _suppliers = MainServices.GetInstance().Suppliers.FetchValues<Entities.Supplier>().ToList();
            _supplier = Suppliers.Where(item => item.Id == Fields.SupplierId).FirstOrDefault();
            _id = (int)Fields.Id;
            _time = Fields.DateTime;
        }

        protected override void Clear()
        {
            Id = (int)Fields.Id;
            Supplier = Suppliers.Where(item => item.Id == Fields.SupplierId).FirstOrDefault();
            Time = Fields.DateTime;
        }

        private IList<Entities.Supplier> _suppliers;
        public IList<Entities.Supplier> Suppliers
        {
            get => _suppliers;
            set => Set(ref _suppliers, value);
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

        private Entities.Supplier _supplier;
        public Entities.Supplier Supplier
        {
            get => _supplier;
            set => Set(ref _supplier, value);
        }

        private DateTime _time;
        public DateTime Time
        {
            get => _time;
            set
            {
                if (!ValueChecker.CheckValueDateTime(value.ToString(), out DateTime _))
                    value = Fields.DateTime;
                Set(ref _time, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
            if (!ValueChecker.CheckValueUint(Supplier.Id.ToString(), out uint supplier))
                throw new ArgumentException("Некорректный параметр!", nameof(Supplier.Id));
            if (!ValueChecker.CheckValueDateTime(Time.ToString(), out DateTime time))
                throw new ArgumentException("Некорректный параметр!", nameof(Time));
            Fields.Id = id;
            Fields.SupplierId = supplier;
            Fields.DateTime = time;
        }
    }
}
