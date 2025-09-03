using System;
using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class BranchOrderEntity : SimpleEntity
    {
        public virtual uint BranchId { get; set; }
        [DisplayName("Подразделение")]
        [ColumnOrder(1)]
        public virtual string BranchName { get; set; }
        [DisplayName("Дата")]
        [ColumnOrder(2)]
        public virtual DateTime DateTime { get; set; }

        public BranchOrderEntity() { }

        public BranchOrderEntity(BranchOrderEntity info)
        {
            Id = info.Id;
            BranchId = info.BranchId;
            BranchName = info.BranchName;
            DateTime = info.DateTime;
        }

        public override string ToString()
        {
            return $"{BranchName}_{DateTime}";
        }
    }

    public class BranchOrder : BranchOrderEntity
    {
        public BranchOrder() { }

        public BranchOrder(BranchOrderEntity info) : base(info) { }
    }
}
