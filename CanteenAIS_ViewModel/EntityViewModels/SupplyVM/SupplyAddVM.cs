using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supply
{
    public class SupplyAddVM : BasicAddVM<Entities.SupplyEntity, Entities.Supply>
    {
        public SupplyAddVM(TableModel<Entities.SupplyEntity> tableModel)
            : base(tableModel)
        {
            _suppliers = MainServices.GetInstance().Suppliers.FetchValues<Entities.Supplier>().ToList();
            _supplier = Suppliers.FirstOrDefault();
            _time = DateTime.Now;
        }

        protected override void Clear()
        {
            Supplier = Suppliers.FirstOrDefault();
            Time = DateTime.Now;
        }

        private IList<Entities.Supplier> _suppliers;
        public IList<Entities.Supplier> Suppliers
        {
            get => _suppliers;
            set => Set(ref _suppliers, value);
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

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(Supplier.Id.ToString(), out uint supplier))
                throw new ArgumentException("Некорректный параметр!", nameof(Supplier.Id));
            if (!ValueChecker.CheckValueDateTime(Time.ToString(), out DateTime time))
                throw new ArgumentException("Некорректный параметр!", nameof(Time));
            Fields.SupplierId = supplier;
            Fields.DateTime = time;
        }
    }
}
