using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Ingredient
{
    public class IngredientEditVM : BasicEditVM<Entities.IngredientEntity, Entities.Ingredient>
    {
        public IngredientEditVM(DataRow ingredientRow, TableModel<Entities.IngredientEntity> tableModel)
            : base(ingredientRow, tableModel)
        {
            _units = MainServices.GetInstance().MeasureUnits.FetchValues<Entities.MeasureUnit>().ToList();
            _unit = Units.Where(item => item.Id == Fields.UnitId).FirstOrDefault();
            _products = MainServices.GetInstance().Products.FetchValues<Entities.Product>().ToList();
            _product = Products.Where(item => item.Id == Fields.ProductId).FirstOrDefault();
            _gross = Fields.Gross;
            _net = Fields.Net;
        }

        protected override void Clear()
        {
            _unit = Units.Where(item => item.Id == Fields.UnitId).FirstOrDefault();
            _product = Products.Where(item => item.Id == Fields.ProductId).FirstOrDefault();
            _gross = Fields.Gross;
            _net = Fields.Net;
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

        private double _net;
        public double Net
        {
            get => _net;
            set
            {
                if (!ValueChecker.CheckValueDouble(value.ToString(), out double _))
                    value = Fields.Net;
                Set(ref _net, value);
            }
        }

        private double _gross;
        public double Gross
        {
            get => _gross;
            set
            {
                if (!ValueChecker.CheckValueDouble(value.ToString(), out double _))
                    value = Fields.Gross;
                Set(ref _gross, value);
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
            if (!ValueChecker.CheckValueDouble(Gross.ToString(), out double gross))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Gross));
            Fields.Gross = gross;
            if (!ValueChecker.CheckValueDouble(Net.ToString(), out double net))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Net));
            Fields.Net = net;
        }

        public override void Edit()
        {
            ParseFields();
            Row.SetField("ProductId", Fields.ProductId);
            Row.SetField("ProductName", Fields.ProductName);
            Row.SetField("Gross", Fields.Gross);
            Row.SetField("Net", Fields.Net);
            Row.SetField("UnitId", Fields.UnitId);
            Row.SetField("UnitName", Fields.UnitName);
        }
    }
}
