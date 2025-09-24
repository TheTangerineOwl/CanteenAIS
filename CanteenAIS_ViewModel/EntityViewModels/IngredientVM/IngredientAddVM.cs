using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Ingredient
{
    public class IngredientAddVM : BasicAddVM<Entities.IngredientEntity, Entities.Ingredient>
    {
        public IngredientAddVM(TableModel<Entities.IngredientEntity> tableModel)
            : base(tableModel)
        {
            _products = MainServices.GetInstance().Products.FetchValues<Entities.Product>().ToList();
            _product = Products.FirstOrDefault();
            _units = MainServices.GetInstance().MeasureUnits.FetchValues<Entities.MeasureUnit>().ToList();
            _unit = Units.Where(item => item.Id == _product.UnitId).FirstOrDefault() ?? Units.FirstOrDefault();
            _gross = 0;
            _net = 0;
        }

        protected override void Clear()
        {
            _unit = Units.Where(item => item.Id == _product.UnitId).FirstOrDefault() ?? Units.FirstOrDefault();
            _product = Products.FirstOrDefault();
            _gross = 0;
            _net = 0;
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
                    value = 0;
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
                    value = 0;
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
            Fields.UnitName = Unit.Name;
            if (!ValueChecker.CheckValueUint(Product.Id.ToString(), out uint product))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Product.Id));
            Fields.ProductId = product;
            Fields.ProductName = Product.Name;
            if (!ValueChecker.CheckValueDouble(Gross.ToString(), out double gross))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Gross));
            Fields.Gross = gross;
            if (!ValueChecker.CheckValueDouble(Net.ToString(), out double net))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Net));
            Fields.Net = net;
        }

        public override void Add()
        {
            ParseFields();
            DataRow row = Model.Table.NewRow();
            row.SetField("ProductId", Fields.ProductId);
            row.SetField("ProductName", Fields.ProductName);
            row.SetField("Gross", Fields.Gross);
            row.SetField("Net", Fields.Net);
            row.SetField("UnitId", Fields.UnitId);
            row.SetField("UnitName", Fields.UnitName);
            Model.Table.Rows.Add(row);
            Clear();
        }
    }
}
