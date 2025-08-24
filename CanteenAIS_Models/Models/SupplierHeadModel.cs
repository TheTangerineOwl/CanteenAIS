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
    public class SupplierHeadModel : SimpleModel<ISupplierHead, SupplierHeadInfo>
    {
        public override string TableName => "Руководители";

        public SupplierHeadModel(BasicSimpleCRUD<ISupplierHead> context) : base(context) { }

        public override void Add(SupplierHeadInfo info)
        {
            TableContext.Create(new SupplierHead(info));
        }

        public override void Update(DataRow row, SupplierHeadInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new SupplierHead(info));
        }

        public override int CompareEntities(ISupplierHead first, ISupplierHead second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.Id.CompareTo(second.Id);
            if (compared != 0) return compared;
            compared = first.LastName.CompareTo(second.LastName);
            if (compared != 0) return compared;
            compared = first.FirstName.CompareTo(second.FirstName);
            if (compared != 0) return compared;
            compared = first.Patronim.CompareTo(second.Patronim);
            if (compared != 0) return compared;
            compared = first.Phone.CompareTo(second.Phone);
            if (compared != 0) return compared;
            return 0;
        }

        public override bool ContainsString(ISupplierHead entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.LastName.Contains(sample) ||
                entity.FirstName.Contains(sample) ||
                entity.Patronim.Contains(sample) ||
                entity.Phone.Contains(sample)
            );
        }
    }
}
