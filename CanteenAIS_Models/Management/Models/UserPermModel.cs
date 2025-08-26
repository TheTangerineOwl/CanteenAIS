using CanteenAIS_DB;
using CanteenAIS_DB.AppAuth.Entities;
using System.Data;

namespace CanteenAIS_Models.Management.Models
{
    public class UserPermModel : DoubleModel<UserPermEntity>
    {
        public override string TableName => "Права пользователей";

        public UserPermModel(BasicDoubleCRUD<UserPermEntity> context) : base(context) { }

        public override void Add<TResultType>(UserPermEntity info)
        {
            TResultType result = new TResultType
            {
                UserId = info.UserId,
                UserLogin = info.UserLogin,
                ElementId = info.ElementId,
                ElementName = info.ElementName,
                CanRead = info.CanRead,
                CanWrite = info.CanWrite,
                CanDelete = info.CanDelete,
                CanEdit = info.CanEdit
            };
            TableContext.Create(result);
        }

        public override void Update<TResultType>(DataRow row, UserPermEntity info)
        {
            (info.UserId, info.ElementId) = GetPK(row);
            TResultType result = new TResultType
            {
                UserId = info.UserId,
                UserLogin = info.UserLogin,
                ElementId = info.ElementId,
                ElementName = info.ElementName,
                CanRead = info.CanRead,
                CanWrite = info.CanWrite,
                CanDelete = info.CanDelete,
                CanEdit = info.CanEdit
            };
            TableContext.Update(result);
        }

        public override int CompareEntities(UserPermEntity first, UserPermEntity second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.UserId.CompareTo(second.UserId);
            if (compared != 0) return compared;
            compared = first.ElementId.CompareTo(second.ElementId);
            return compared;
        }

        public override bool ContainsString(UserPermEntity entity, string sample)
        {
            return (
                entity.UserLogin.Contains(sample) ||
                entity.ElementName.Contains(sample)
            );
        }
    }
}
