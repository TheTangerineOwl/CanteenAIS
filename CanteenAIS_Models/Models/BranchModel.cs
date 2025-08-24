using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenAIS_Models.Models
{
    public class BranchModel : SimpleModel<IBranch, BranchInfo>
    {
        public override string TableName => "Отделения";

        public BranchModel(BasicSimpleCRUD<IBranch> context) : base(context) { }

        public override void Add(BranchInfo info)
        {
            TableContext.Create(new Branch(info));
        }

        public override void Update(DataRow row, BranchInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new Branch(info));
        }

        public override int CompareEntities(IBranch first, IBranch second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.Id.CompareTo(second.Id);
            if (compared != 0) return compared;
            compared = string.Compare(first.Name, second.Name);
            if (compared != 0) return compared;
            return 0;
        }

        public override bool ContainsString(IBranch entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.Name.Contains(sample)
            );
        }
    }
}
