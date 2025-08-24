using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class BankModel : SimpleModel<IBank, BankInfo>
    {
        public override string TableName => "Банки";

        public BankModel(BasicSimpleCRUD<IBank> context) : base(context) { }

        public override void Add(BankInfo info)
        {
            TableContext.Create(new Bank(info));
        }

        public override void Update(DataRow row, BankInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new Bank(info));
        }

        public override int CompareEntities(IBank first, IBank second)
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

        public override bool ContainsString(IBank entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.Name.Contains(sample)
            );
        }
    }
}
