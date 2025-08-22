using System;
using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface ISupply
    {
        [DisplayName("Id")]
        uint Id { get; set; }
        uint SupplierId { get; set; }
        [DisplayName("Поставщик")]
        string SupplierName { get; set; }
        [DisplayName("Время")]
        DateTime DateTime { get; set; }
    }
    public class Supply : ISupply
    {
        public uint Id { get; set; }
        public uint SupplierId { get; set; }
        public string SupplierName { get; set; }
        public DateTime DateTime { get; set; }

        public Supply(uint id, uint supplierId, string supplierName, DateTime dateTime)
        {
            Id = id;
            SupplierId = supplierId;
            SupplierName = supplierName;
            DateTime = dateTime;
        }
        public Supply(uint supplierId, DateTime date)
        {
            SupplierId = supplierId;
            DateTime = date;
        }
    }
}
