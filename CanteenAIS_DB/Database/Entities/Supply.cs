using System;
using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class SupplyEntity : SimpleEntity
    {
        [ColumnDisplay("Поставщик_Id")]
        public virtual uint SupplierId { get; set; }
        [ColumnDisplay("Поставщик", true, 1)]
        public virtual string SupplierName { get; set; }
        [ColumnDisplay("Время", true, 2)]
        public virtual DateTime DateTime { get; set; }

        public SupplyEntity() { }

        public SupplyEntity(SupplyEntity info)
        {
            Id = info.Id;
            SupplierId = info.SupplierId;
            SupplierName = info.SupplierName;
            DateTime = info.DateTime;
        }

        public override string ToString()
        {
            return $"{DateTime}_{SupplierName}";
        }
    }

    public class Supply : SupplyEntity
    {
        public Supply() { }

        public Supply(SupplyEntity info) : base(info) { }
    }
}
