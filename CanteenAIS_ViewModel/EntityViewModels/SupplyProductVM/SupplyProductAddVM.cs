using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.SupplyProduct
{
    public class SupplyProductAddVM : BasicAddVM<Entities.SupplyProductEntity, Entities.SupplyProduct>
    {
        public SupplyProductAddVM(TableModel<Entities.SupplyProductEntity> tableModel)
            : base(tableModel)
        {
            _units = MainServices.GetInstance().MeasureUnits.FetchValues<Entities.MeasureUnit>().ToList();
            _unit = Units.FirstOrDefault();
            _products = MainServices.GetInstance().Products.FetchValues<Entities.Product>().ToList();
            _product = Products.FirstOrDefault();
            _amount = 0;
            _price = 0;
        }

        protected override void Clear()
        {
            _unit = Units.FirstOrDefault();
            _product = Products.FirstOrDefault();
            _amount = 0;
            _price = 0;
        }

        private IList<Entities.MeasureUnit> _units;
        public IList<Entities.MeasureUnit> Units
        {
            get => _units;
            set => Set(ref _units, value);
        }

        private IList<Entities.Product> _products;
        public IList<Entities.Product> Products
        {
            get => _products;
            set => Set(ref _products, value);
        }

        private Entities.Product _product;
        public Entities.Product Product
        {
            get => _product;
            set => Set(ref _product, value);
        }

        private double _amount;
        public double Amount
        {
            get => _amount;
            set
            {
                if (!ValueChecker.CheckValueDouble(value.ToString(), out double _))
                    value = 0;
                Set(ref _amount, value);
            }
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                if (!ValueChecker.CheckValueDecimal(value.ToString(), out decimal _))
                    value = 0;
                Set(ref _price, value);
            }
        }

        private Entities.MeasureUnit _unit;
        public Entities.MeasureUnit Unit
        {
            get => _unit;
            set => Set(ref _unit, value);
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(Unit.Id.ToString(), out uint unit))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Unit.Id));
            Fields.UnitId = unit;
            Fields.UnitName = Unit.Name;
            if (!ValueChecker.CheckValueUint(Product.Id.ToString(), out uint product))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Product.Id));
            Fields.ProductId = product;
            Fields.ProductName = Product.Name;
            if (!ValueChecker.CheckValueDouble(Amount.ToString(), out double amount))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Amount));
            Fields.Amount = amount;
            if (!ValueChecker.CheckValueDecimal(Price.ToString(), out decimal price))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Amount));
            Fields.Price = price;
        }

        public override void Add()
        {
            ParseFields();
            DataRow row = Model.Table.NewRow();
            row.SetField("ProductId", Fields.ProductId);
            row.SetField("ProductName", Fields.ProductName);
            row.SetField("Amount", Fields.Amount);
            row.SetField("Price", Fields.Amount);
            row.SetField("UnitId", Fields.UnitId);
            row.SetField("UnitName", Fields.UnitName);
            Model.Table.Rows.Add(row);
            Clear();
        }
    }
}
