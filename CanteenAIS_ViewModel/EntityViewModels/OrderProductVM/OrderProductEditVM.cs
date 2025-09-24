using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.OrderProduct
{
    public class OrderProductEditVM : BasicEditVM<Entities.OrderProductEntity, Entities.OrderProduct>
    {
        public OrderProductEditVM(DataRow orderproductRow, TableModel<Entities.OrderProductEntity> tableModel)
            : base(orderproductRow, tableModel)
        {
            _units = MainServices.GetInstance().MeasureUnits.FetchValues<Entities.MeasureUnit>().ToList();
            _unit = Units.Where(item => item.Id == Fields.UnitId).FirstOrDefault();
            _products = MainServices.GetInstance().Products.FetchValues<Entities.Product>().ToList();
            _product = Products.Where(item => item.Id == Fields.ProductId).FirstOrDefault();
            _amount = Fields.Amount;
        }

        protected override void Clear()
        {
            _unit = Units.Where(item => item.Id == Fields.UnitId).FirstOrDefault();
            _product = Products.Where(item => item.Id == Fields.ProductId).FirstOrDefault();
            _amount = Fields.Amount;
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
            set
            {
                Set(ref _product, value);
                Unit = Units.Where(item => item.Id == value.UnitId).FirstOrDefault() ?? Units.FirstOrDefault();
            }
        }

        private double _amount;
        public double Amount
        {
            get => _amount;
            set
            {
                if (!ValueChecker.CheckValueDouble(value.ToString(), out double _))
                    value = Fields.Amount;
                Set(ref _amount, value);
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
            if (!ValueChecker.CheckValueUint(Product.Id.ToString(), out uint product))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Product.Id));
            Fields.ProductId = product;
            if (!ValueChecker.CheckValueDouble(Amount.ToString(), out double amount))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Amount));
            Fields.Amount = amount;
        }

        public override void Edit()
        {
            ParseFields();
            Row.SetField("ProductId", Fields.ProductId);
            Row.SetField("ProductName", Fields.ProductName);
            Row.SetField("Amount", Fields.Amount);
            Row.SetField("UnitId", Fields.UnitId);
            Row.SetField("UnitName", Fields.UnitName);
        }
    }
}
