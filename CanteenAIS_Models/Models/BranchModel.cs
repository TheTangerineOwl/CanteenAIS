using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class BranchModel : SimpleModel<BranchEntity>
    {
        public override string TableName => "Отделения";

        public BranchModel(BasicSimpleCRUD<BranchEntity> context) : base(context) { }

        public override void Add<TResult>(BranchEntity info)
        {
            TResult result = new TResult
            {
                //Id = info.Id,
                Name = info.Name
            };
            TableContext.Create(result);
        }

        public override void Add<TResult>(BranchEntity info, out long id)
        {
            TResult result = new TResult
            {
                //Id = info.Id,
                Name = info.Name
            };
            id = TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, BranchEntity info)
        {
            TResult result = new TResult
            {
                Id = GetId(row),
                Name = info.Name
            };
            TableContext.Update(new Branch(info));
        }

        public override int CompareEntities(BranchEntity first, BranchEntity second)
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

        public override bool ContainsString(BranchEntity entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.Name.Contains(sample)
            );
        }
    }
}
