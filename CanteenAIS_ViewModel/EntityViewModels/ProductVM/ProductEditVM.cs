using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Product
{
    public class ProductEditVM : BasicEditVM<Entities.ProductEntity, Entities.Product>
    {
        public ProductEditVM(DataRow row, TableModel<Entities.ProductEntity> tableModel)
            : base(row, tableModel)
        {
            _units = MainServices.GetInstance().MeasureUnits.FetchValues<Entities.MeasureUnit>().ToList();
            _unit = Units.Where(item => item.Id == Fields.UnitId).FirstOrDefault();
            _suppliers = MainServices.GetInstance().Suppliers.FetchValues<Entities.Supplier>().ToList();
            _supplier = Suppliers.Where(item => item.Id == Fields.SupplierId).FirstOrDefault();
            _id = (int)Fields.Id;
            _name = Fields.Name;
            _markup = Fields.Markup;
            _stock = Fields.Stock;
        }

        protected override void Clear()
        {
            Id = (int)Fields.Id;
            Name = Fields.Name;
            Unit = Units.Where(item => item.Id == Fields.UnitId).FirstOrDefault();
            Markup = Fields.Markup;
            Stock = Fields.Stock;
            Supplier = Suppliers.Where(item => item.Id == Fields.SupplierId).FirstOrDefault();
        }

        private IList<Entities.MeasureUnit> _units;
        public IList<Entities.MeasureUnit> Units
        {
            get => _units;
            set => Set(ref _units, value);
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

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == null)
                    _name = value;
                if (!ValueChecker.CheckValueString(value, out value, 100, false))
                    value = Fields.Name;
                Set(ref _name, value);
            }
        }

        private Entities.MeasureUnit _unit;
        public Entities.MeasureUnit Unit
        {
            get => _unit;
            set => Set(ref _unit, value);
        }

        private decimal _markup;
        public decimal Markup
        {
            get => _markup;
            set
            {
                if (!ValueChecker.CheckValueDecimal(value.ToString(), out decimal _))
                    value = Fields.Markup;
                Set(ref _markup, value);
            }
        }

        private double _stock;
        public double Stock
        {
            get => _stock;
            set
            {
                if (!ValueChecker.CheckValueDouble(value.ToString(), out double _))
                    value = Fields.Stock;
                Set(ref _stock, value);
            }
        }

        private Entities.Supplier _supplier;
        public Entities.Supplier Supplier
        {
            get => _supplier;
            set => Set(ref _supplier, value);
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
            Fields.Id = id;
            if (!ValueChecker.CheckValueString(Name, out string name, 100, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
            Fields.Name = name;
            if (!ValueChecker.CheckValueUint(Unit.Id.ToString(), out uint unit))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Unit));
            Fields.UnitId = unit;
            if (!ValueChecker.CheckValueDecimal(Markup.ToString(), out decimal markup))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Markup));
            Fields.Markup = markup;
            if (!ValueChecker.CheckValueDouble(Stock.ToString(), out double stock))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Stock));
            Fields.Stock = stock;
            if (!ValueChecker.CheckValueUint(Supplier.Id.ToString(), out uint supplier))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Supplier));
            Fields.SupplierId = supplier;
        }
    }
}
