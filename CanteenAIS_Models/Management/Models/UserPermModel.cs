using CanteenAIS_DB;
using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_DB.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenAIS_Models.Management.Models
{
    public class UserPermModel : DoubleModel<IUserPerm, UserPermInfo>
    {
        public override string TableName => "Права пользователей";

        public UserPermModel(BasicDoubleCRUD<IUserPerm> context) : base(context) { }

        public override void Add(UserPermInfo info)
        {
            TableContext.Create(new UserPerm(info));
        }

        public override void Update(DataRow row, UserPermInfo info)
        {
            (info.UserId, info.ElementId) = GetPK(row);
            TableContext.Update(new UserPerm(info));
        }

        public override int CompareEntities(IUserPerm first, IUserPerm second)
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

        public override bool ContainsString(IUserPerm entity, string sample)
        {
            return (
                entity.UserLogin.Contains(sample) ||
                entity.ElementName.Contains(sample)
            );
        }
    }
}
