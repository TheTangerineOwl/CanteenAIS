using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class SupplierModel : SimpleModel<SupplierEntity>
    {
        public override string TableName => "Поставщики";

        public SupplierModel(BasicSimpleCRUD<SupplierEntity> context) : base(context) { }

        public override void Add<TResult>(SupplierEntity info)
        {
            TResult result = new TResult
            {
                //Id = info.Id,
                Name = info.Name,
                CityName = info.CityName,
                StreetId = info.StreetId,
                StreetName = info.StreetName,
                Building = info.Building,
                HeadId = info.HeadId,
                HeadName = info.HeadName,
                HeadPhone = info.HeadPhone,
                BankId = info.BankId,
                BankName = info.BankName,
                Account = info.Account,
                INN = info.INN
            };
            TableContext.Create(result);
        }

        public override void Add<TResult>(SupplierEntity info, out long id)
        {
            TResult result = new TResult
            {
                //Id = info.Id,
                Name = info.Name,
                CityName = info.CityName,
                StreetId = info.StreetId,
                StreetName = info.StreetName,
                Building = info.Building,
                HeadId = info.HeadId,
                HeadName = info.HeadName,
                HeadPhone = info.HeadPhone,
                BankId = info.BankId,
                BankName = info.BankName,
                Account = info.Account,
                INN = info.INN
            };
            id = TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, SupplierEntity info)
        {
            TResult result = new TResult
            {
                Id = GetId(row),
                Name = info.Name,
                CityName = info.CityName,
                StreetId = info.StreetId,
                StreetName = info.StreetName,
                Building = info.Building,
                HeadId = info.HeadId,
                HeadName = info.HeadName,
                HeadPhone = info.HeadPhone,
                BankId = info.BankId,
                BankName = info.BankName,
                Account = info.Account,
                INN = info.INN
            };
            TableContext.Update(result);
        }

        public override int CompareEntities(SupplierEntity first, SupplierEntity second)
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

        public override bool ContainsString(SupplierEntity entity, string sample)
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
