using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Product
{
    public class ProductAddVM : BasicAddVM<Entities.ProductEntity, Entities.Product>
    {
        public ProductAddVM(TableModel<Entities.ProductEntity> tableModel)
            : base(tableModel)
        {
            _units = MainServices.GetInstance().MeasureUnits.FetchValues<Entities.MeasureUnit>().ToList();
            _unit = Units.FirstOrDefault();
            _suppliers = MainServices.GetInstance().Suppliers.FetchValues<Entities.Supplier>().ToList();
            _supplier = Suppliers.FirstOrDefault();
            _name = string.Empty;
            _markup = 0;
            _stock = 0;
        }

        protected override void Clear()
        {
            Name = string.Empty;
            Unit = Units.FirstOrDefault();
            Markup = 0;
            Stock = 0;
            Supplier = Suppliers.FirstOrDefault();
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


        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == null)
                    _name = value;
                if (!ValueChecker.CheckValueString(value, out value, 100, false))
                    value = string.Empty;
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
                    value = 0;
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
                    value = 0;
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
