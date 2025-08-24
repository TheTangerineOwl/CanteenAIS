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
    public class UserModel : SimpleModel<IUser, UserInfo>
    {
        public override string TableName => "Пользователи";

        public UserModel(BasicSimpleCRUD<IUser> context) : base(context) { }

        public override void Add(UserInfo info)
        {
            TableContext.Create(new User(info));
        }

        public override void Update(DataRow row, UserInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new User(info));
        }

        public override int CompareEntities(IUser first, IUser second)
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

        public override bool ContainsString(IUser entity, string sample)
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
