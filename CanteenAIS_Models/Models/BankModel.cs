using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class BankModel : SimpleModel<BankEntity>
    {
        public override string TableName => "Банки";

        public BankModel(BasicSimpleCRUD<BankEntity> context) : base(context) { }

        public override void Add<TResult>(BankEntity info)
        {
            TResult result = new TResult
            {
                Id = info.Id,
                Name = info.Name
            };
            TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, BankEntity info)
        {
            TResult result = new TResult
            {
                Id = info.Id,
                Name = info.Name
            };
            TableContext.Update(result);
        }

        public override int CompareEntities(BankEntity first, BankEntity second)
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

        public override bool ContainsString(BankEntity entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.Name.Contains(sample)
            );
        }
    }
}
