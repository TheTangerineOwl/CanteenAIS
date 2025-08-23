using System;
using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface ISupply : ISimpleEntity
    {
        uint SupplierId { get; set; }
        [DisplayName("Поставщик")]
        string SupplierName { get; set; }
        [DisplayName("Время")]
        DateTime DateTime { get; set; }
    }

    public class SupplyInfo : SimpleInfo
    {
        public uint supplierId;
        public string supplierName;
        public DateTime dateTime;
    }

    public class Supply : ISupply
    {
        private readonly SupplyInfo _info;
        public uint Id { get => _info.id; set => _info.id = value; }
        public uint SupplierId { get => _info.supplierId; set => _info.supplierId = value; }
        public string SupplierName { get => _info.supplierName; set => _info.supplierName = value; }
        public DateTime DateTime { get => _info.dateTime; set => _info.dateTime = value; }

        public Supply(SupplyInfo info)
        {
            _info = info;
        }
    }
}
