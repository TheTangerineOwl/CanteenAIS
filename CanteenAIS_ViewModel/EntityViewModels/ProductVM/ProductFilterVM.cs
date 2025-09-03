using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Product
{
    public class ProductFilterVM : BasicFilterVM<Entities.ProductEntity, Entities.Product>
    {
        public ProductFilterVM(TableModel<Entities.ProductEntity> tableModel)
            : base(tableModel)
        {
            _units = MainServices.GetInstance().MeasureUnits.FetchValues<Entities.MeasureUnit>().ToList();
            _unit = Units.FirstOrDefault();
            _unitCheck = false;
            _suppliers = MainServices.GetInstance().Suppliers.FetchValues<Entities.Supplier>().ToList();
            _supplier = Suppliers.FirstOrDefault();
            _supplierCheck = false;
            _id = 0;
            _idCheck = false;
            _name = string.Empty;
            _nameCheck = false;
            _markup = 0;
            _markupCheck = false;
            _stock = 0;
            _stockCheck = false;
        }

        protected override void Clear()
        {
            Id = 0;
            IdCheck = false;
            Name = string.Empty;
            NameCheck = false;
            Unit = Units.FirstOrDefault();
            UnitCheck = false;
            Markup = 0;
            MarkupCheck = false;
            Stock = 0;
            StockCheck = false;
            Supplier = Suppliers.FirstOrDefault();
            SupplierCheck = false;
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
                    value = 0;
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
                    value = "";
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

        private bool _idCheck;
        public bool IdCheck
        {
            get => _idCheck;
            set => Set(ref _idCheck, value);
        }

        private bool _nameCheck;
        public bool NameCheck
        {
            get => _nameCheck;
            set => Set(ref _nameCheck, value);
        }

        private bool _unitCheck;
        public bool UnitCheck
        {
            get => _unitCheck;
            set => Set(ref _unitCheck, value);
        }

        private bool _markupCheck;
        public bool MarkupCheck
        {
            get => _markupCheck;
            set => Set(ref _markupCheck, value);
        }

        private bool _stockCheck;
        public bool StockCheck
        {
            get => _stockCheck;
            set => Set(ref _stockCheck, value);
        }

        private bool _supplierCheck;
        public bool SupplierCheck
        {
            get => _supplierCheck;
            set => Set(ref _supplierCheck, value);
        }

        public override void ParseFields()
        {
            if (_idCheck)
            {
                if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
                Fields.Id = id;
            }
            if (_nameCheck)
            {
                if (!ValueChecker.CheckValueString(Name, out string name, 100, false))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
                Fields.Name = name;
            }
            if (_unitCheck)
            {
                if (!ValueChecker.CheckValueUint(Unit.Id.ToString(), out uint unit))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Unit));
                Fields.UnitId = unit;
            }
            if (_markupCheck)
            {
                if (!ValueChecker.CheckValueDecimal(Markup.ToString(), out decimal markup))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Markup));
                Fields.Markup = markup;
            }
            if (_stockCheck)
            {
                if (!ValueChecker.CheckValueDouble(Stock.ToString(), out double stock))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Stock));
                Fields.Stock = stock;
            }
            if (_supplierCheck)
            {
                if (!ValueChecker.CheckValueUint(Supplier.Id.ToString(), out uint supplier))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Supplier));
                Fields.SupplierId = supplier;
            }
        }

        public override void Filter()
        {
            ParseFields();
            Model.FetchAndFilter<Entities.Product>((item) =>
                !(IdCheck && item.Id != Fields.Id) &&
                !(NameCheck && !item.Name.Contains(Fields.Name)) &&
                !(UnitCheck && item.UnitId != Fields.UnitId) &&
                !(MarkupCheck && item.Markup != Fields.Markup) &&
                !(StockCheck && item.Stock != Fields.Stock) &&
                !(SupplierCheck && item.SupplierId != Fields.SupplierId)
            );
        }
    }
}
