using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Product
{
    public class ProductFilterVM : BasicFilterVM<Entities.ProductEntity, Entities.Product>
    {
        public ProductFilterVM(TableModel<Entities.ProductEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            IdText = "0";
            NameText = string.Empty;
            Unit = 0;
            MarkupText = "0";
            StockText = "0";
            Supplier = 0;
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
                    value = "1";
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
                    value = "";
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
                    value = "0";
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
                    value = "0";
                Set(ref stockText, value);
            }
        }

        private int supplier;
        public int Supplier
        {
            get => supplier;
            set => Set(ref supplier, value);
        }

        private bool idCheck;
        public bool IdCheck
        {
            get => idCheck;
            set => Set(ref idCheck, value);
        }

        private bool nameCheck;
        public bool NameCheck
        {
            get => nameCheck;
            set => Set(ref nameCheck, value);
        }

        private bool unitCheck;
        public bool UnitCheck
        {
            get => unitCheck;
            set => Set(ref unitCheck, value);
        }

        private bool markupCheck;
        public bool MarkupCheck
        {
            get => markupCheck;
            set => Set(ref markupCheck, value);
        }

        private bool stockCheck;
        public bool StockCheck
        {
            get => stockCheck;
            set => Set(ref stockCheck, value);
        }

        private bool supplierCheck;
        public bool SupplierCheck
        {
            get => supplierCheck;
            set => Set(ref supplierCheck, value);
        }

        public override void ParseFields()
        {
            if (idCheck)
            {
                if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
                Fields.Id = id;
            }
            if (nameCheck)
            {
                if (!ValueChecker.CheckValueString(NameText, out string name, 100, false))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(NameText));
                Fields.Name = name;
            }
            if (unitCheck)
            {
                if (!ValueChecker.CheckValueUint(Unit.ToString(), out uint unit))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Unit));
                Fields.UnitId = unit;
            }
            if (markupCheck)
            {
                if (!ValueChecker.CheckValueDecimal(MarkupText, out decimal markup))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(MarkupText));
                Fields.Markup = markup;
            }
            if (stockCheck)
            {
                if (!ValueChecker.CheckValueDouble(StockText, out double stock))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(StockText));
                Fields.Stock = stock;
            }
            if (supplierCheck)
            {
                if (!ValueChecker.CheckValueUint(Supplier.ToString(), out uint supplier))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Supplier));
                Fields.SupplierId = supplier;
            }
        }
    }
}
