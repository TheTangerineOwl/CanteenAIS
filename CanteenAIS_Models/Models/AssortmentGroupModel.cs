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
    public class AssortmentGroupModel : SimpleModel<IAssortmentGroup, AssortmentGroupInfo>
    {
        public override string TableName => "Группа ассортимента";

        public AssortmentGroupModel(BasicSimpleCRUD<IAssortmentGroup> context) : base(context) { }

        public override void Add(AssortmentGroupInfo info)
        {
            TableContext.Create(new AssortmentGroup(info));
        }

        public override void Update(DataRow row, AssortmentGroupInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new AssortmentGroup(info));
        }

        public override int CompareEntities(IAssortmentGroup first, IAssortmentGroup second)
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

        public override bool ContainsString(IAssortmentGroup entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.Name.Contains(sample)
            );
        }
    }
}
