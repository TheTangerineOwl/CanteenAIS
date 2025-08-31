using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Product
{
    public class ProductEditVM : BasicEditVM<Entities.ProductEntity, Entities.Product>
    {
        public ProductEditVM(DataRow row, TableModel<Entities.ProductEntity> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            IdText = Fields.Id.ToString();
            NameText = Fields.Name;
            Unit = (int)Fields.UnitId;
            MarkupText = Fields.Markup.ToString();
            StockText = Fields.Stock.ToString();
            Supplier = (int)Fields.SupplierId;
        }

        private string idText;
        public string IdText
        {
            get => idText;
            set
            {
                if (idText == null)
                    idText = value;
                if (!ValueChecker.CheckValueUint(value, out uint _, true))
                    value = Fields.Id.ToString();
                Set(ref idText, value);
            }
        }

        private string nameText;
        public string NameText
        {
            get => nameText;
            set
            {
                if (nameText == null)
                    nameText = value;
                if (!ValueChecker.CheckValueString(value, out value, 100, false))
                    value = Fields.Name;
                Set(ref nameText, value);
            }
        }

        private int unit;
        public int Unit
        {
            get => unit;
            set => Set(ref unit, value);
        }

        private string markupText;
        public string MarkupText
        {
            get => markupText;
            set
            {
                if (markupText == null)
                    markupText = value;
                if (!ValueChecker.CheckValueDecimal(value, out decimal _))
                    value = Fields.Markup.ToString();
                Set(ref markupText, value);
            }
        }

        private string stockText;
        public string StockText
        {
            get => stockText;
            set
            {
                if (stockText == null)
                    stockText = value;
                if (!ValueChecker.CheckValueDouble(value, out double _))
                    value = Fields.Stock.ToString();
                Set(ref stockText, value);
            }
        }

        private int supplier;
        public int Supplier
        {
            get => supplier;
            set => Set(ref supplier, value);
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
            if (!ValueChecker.CheckValueString(NameText, out string name, 100, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(NameText));
            if (!ValueChecker.CheckValueUint(Unit.ToString(), out uint unit))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Unit));
            if (!ValueChecker.CheckValueDecimal(MarkupText, out decimal markup))
                throw new ArgumentException("Параметр не может быть 0!", nameof(MarkupText));
            if (!ValueChecker.CheckValueDouble(StockText, out double stock))
                throw new ArgumentException("Параметр не может быть 0!", nameof(StockText));
            if (!ValueChecker.CheckValueUint(Supplier.ToString(), out uint supplier))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Supplier));
            Fields.Id = id;
            Fields.Name = name;
            Fields.UnitId = unit;
            Fields.Markup = markup;
            Fields.Stock = stock;
            Fields.SupplierId = supplier;
        }
    }
}
