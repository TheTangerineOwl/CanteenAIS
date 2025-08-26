using CanteenAIS_DB;
using CanteenAIS_DB.AppAuth.Entities;
using System.Data;

namespace CanteenAIS_Models.Management.Models
{
    public class UserModel : SimpleModel<UserEntity>
    {
        public override string TableName => "Пользователи";

        public UserModel(BasicSimpleCRUD<UserEntity> context) : base(context) { }

        public override void Add<TResultType>(UserEntity info)
        {
            TResultType res = new TResultType
            {
                Id = info.Id,
                Login = info.Login,
                Password = info.Password,
                LastName = info.LastName,
                FirstName = info.FirstName,
                Patronim = info.Patronim,
                DateOfBirth = info.DateOfBirth,
                UserPerms = info.UserPerms
            };
            TableContext.Create(res);
        }

        public override void Update<TResultType>(DataRow row, UserEntity info)
        {
            TResultType result = new TResultType
            {
                Id = GetId(row),
                Login = info.Login,
                Password = info.Password,
                LastName = info.LastName,
                FirstName = info.FirstName,
                Patronim = info.Patronim,
                DateOfBirth = info.DateOfBirth,
                UserPerms = info.UserPerms
            };
            TableContext.Update(result);
        }

        public override int CompareEntities(UserEntity first, UserEntity second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.Id.CompareTo(second.Id);
            if (compared != 0) return compared;
            compared = first.Login.CompareTo(second.Login);
            if (compared != 0) return compared;
            compared = first.LastName.CompareTo(second.LastName);
            if (compared != 0) return compared;
            compared = first.FirstName.CompareTo(second.FirstName);
            if (compared != 0) return compared;
            compared = first.Patronim.CompareTo(second.Patronim);
            if (compared != 0) return compared;
            compared = first.DateOfBirth.CompareTo(second.DateOfBirth);
            if (compared != 0) return compared;
            return 0;
        }

        public override bool ContainsString(UserEntity entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.Login.Contains(sample) ||
                entity.LastName.Contains(sample) ||
                entity.FirstName.Contains(sample) ||
                entity.Patronim.Contains(sample) ||
                entity.DateOfBirth.ToString().Contains(sample)
            );
        }
    }
}
