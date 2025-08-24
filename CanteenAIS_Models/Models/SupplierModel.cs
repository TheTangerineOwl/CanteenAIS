using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class SupplierModel : SimpleModel<ISupplier, SupplierInfo>
    {
        public override string TableName => "Поставщики";

        public SupplierModel(BasicSimpleCRUD<ISupplier> context) : base(context) { }

        public override void Add(SupplierInfo info)
        {
            TableContext.Create(new Supplier(info));
        }

        public override void Update(DataRow row, SupplierInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new Supplier(info));
        }

        public override int CompareEntities(ISupplier first, ISupplier second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.Id.CompareTo(second.Id);
            if (compared != 0) return compared;
            compared = string.Compare(first.Name, second.Name);
            if (compared != 0) return compared;
            compared = first.StreetId.CompareTo(second.StreetId);
            if (compared != 0) return compared;
            compared = first.Building.CompareTo(second.Building);
            if (compared != 0) return compared;
            compared = first.HeadId.CompareTo(second.HeadId);
            if (compared != 0) return compared;
            compared = first.BankId.CompareTo(second.BankId);
            if (compared != 0) return compared;
            compared = first.Account.CompareTo(second.Account);
            if (compared != 0) return compared;
            return first.INN.CompareTo(second.INN);
        }

        public override bool ContainsString(ISupplier entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.Name.Contains(sample) ||
                entity.StreetName.Contains(sample) ||
                entity.CityName.Contains(sample) ||
                entity.Building.Contains(sample) ||
                entity.HeadName.Contains(sample) ||
                entity.HeadPhone.Contains(sample) ||
                entity.BankName.Contains(sample) ||
                entity.Account.Contains(sample) ||
                entity.INN.Contains(sample)
            );
        }
    }
}
