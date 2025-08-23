using System;
using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IBranchOrder : ISimpleEntity
    {
        uint BranchId { get; set; }
        [DisplayName("Подразделение")]
        string BranchName { get; set; }
        [DisplayName("Дата")]
        DateTime DateTime { get; set; }
    }

    public class BranchOrderInfo : SimpleInfo
    {
        public uint branchId;
        public string branchName;
        public DateTime dateTime;
    }

    public class BranchOrder : IBranchOrder
    {
        private readonly BranchOrderInfo _info;
        public uint Id { get => _info.id; set => _info.id = value; }
        public uint BranchId { get => _info.branchId; set => _info.branchId = value; }
        public string BranchName { get => _info.branchName; set => _info.branchName = value; }
        public DateTime DateTime { get => _info.dateTime; set => _info.dateTime = value; }

        public BranchOrder(BranchOrderInfo info)
        {
            _info = info;
        }
    }
}
