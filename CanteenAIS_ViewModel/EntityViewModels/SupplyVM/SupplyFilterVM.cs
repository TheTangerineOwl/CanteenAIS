using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supply
{
    public class SupplyFilterVM : BasicFilterVM<Entities.SupplyEntity, Entities.Supply>
    {
        public SupplyFilterVM(TableModel<Entities.SupplyEntity> tableModel)
            : base(tableModel)
        {
            _suppliers = MainServices.GetInstance().Suppliers.FetchValues<Entities.Supplier>().ToList();
            _supplier = Suppliers.FirstOrDefault();
            _supplierCheck = false;
            _id = 1;
            _idCheck = false;
            _time = DateTime.Now;
            _timeCheck = false;
        }

        protected override void Clear()
        {
            Id = 1;
            IdCheck = false;
            Supplier = Suppliers.FirstOrDefault();
            SupplierCheck = false;
            Time = DateTime.Now;
            TimeCheck = false;
        }

        private IList<Entities.Supplier> _suppliers;
        public IList<Entities.Supplier> Suppliers
        {
            get => _suppliers;
            set => Set(ref _suppliers, value);
        }

        private uint _id;
        public uint Id
        {
            get => _id;
            set
            {
                if (!ValueChecker.CheckValueUint(value.ToString(), out uint _, true))
                    value = 0;
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
                    value = DateTime.Now;
                Set(ref _time, value);
            }
        }

        private bool _idCheck;
        public bool IdCheck
        {
            get => _idCheck;
            set => Set(ref _idCheck, value);
        }

        private bool _supplierCheck;
        public bool SupplierCheck
        {
            get => _supplierCheck;
            set => Set(ref _supplierCheck, value);
        }

        private bool _timeCheck;
        public bool TimeCheck
        {
            get => _timeCheck;
            set => Set(ref _timeCheck, value);
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

        public override void Filter()
        {
            ParseFields();
            Model.FetchAndFilter<Entities.Supply>((item) =>
                !(IdCheck && item.Id != Fields.Id) &&
                !(SupplierCheck && item.SupplierId != Fields.SupplierId) &&
                !(TimeCheck && item.DateTime != Fields.DateTime)
            );
        }
    }
}
