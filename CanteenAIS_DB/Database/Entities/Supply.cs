using System;
using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class SupplyEntity : SimpleEntity
    {
        public virtual uint SupplierId { get; set; }
        [DisplayName("Поставщик")]
        [ColumnOrder(1)]
        public virtual string SupplierName { get; set; }
        [DisplayName("Время")]
        [ColumnOrder(2)]
        public virtual DateTime DateTime { get; set; }

        public SupplyEntity() { }

        public SupplyEntity(SupplyEntity info)
        {
            Id = info.Id;
            SupplierId = info.SupplierId;
            SupplierName = info.SupplierName;
            DateTime = info.DateTime;
        }
    }

    public class Supply : SupplyEntity
    {
        public Supply() { }

        public Supply(SupplyEntity info) : base(info) { }
    }
}
