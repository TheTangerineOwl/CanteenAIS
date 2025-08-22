using System;
using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IBranchOrder
    {
        [DisplayName("Id")]
        uint Id { get; set; }
        uint BranchId { get; set; }
        [DisplayName("Подразделение")]
        string BranchName { get; set; }
        [DisplayName("Дата")]
        DateTime DateTime { get; set; }
    }

    public class BranchOrder : IBranchOrder
    {
        public uint Id { get; set; }
        public uint BranchId { get; set; }
        public string BranchName { get; set; }
        public DateTime DateTime { get; set; }

        public BranchOrder(uint id, uint branchId, string branchName, DateTime dateTime)
        {
            Id = id;
            BranchId = branchId;
            BranchName = branchName;
            DateTime = dateTime;
        }

        public BranchOrder(uint branchId, DateTime dateTime)
        {
            BranchId = branchId;
            DateTime = dateTime;
        }
    }
}
