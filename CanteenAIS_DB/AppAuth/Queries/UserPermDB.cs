using CanteenAIS_DB.AppAuth.Entities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CanteenAIS_DB.AppAuth.Queries
{
    public class UserPermDB : BasicDoubleCRUD<UserPermEntity>
    {
        protected override string TableName => "userperms";

        protected override string QueryCreate => "INSERT INTO userperms (" +
            "`UserId`, `ElementId`, `CanRead`, `CanWrite`, `CanEdit`, `CanDelete`" +
            ") VALUES (" +
            "@entityUserId, @entityElementId, @entityCanRead, " +
            "@entityCanWrite, @entityCanEdit, @entityCanDelete" +
            ");";

        protected override string QueryRead => "SELECT " +
            "up.`UserId` AS `UserId`, " +
            "u.`Login` AS `UserLogin`, " +
            "up.`ElementId` AS `ElementId`, " +
            "me.`Name` AS `ElementName`, " +
            "up.`CanRead` AS `CanRead`, " +
            "up.`CanWrite` AS `CanWrite`, " +
            "up.`CanEdit` AS `CanEdit`, " +
            "up.`CanDelete` AS `CanDelete` " +
            "FROM userperms AS up " +
            "LEFT JOIN users AS u ON u.`Id`=up.`UserId` " +
            "LEFT JOIN menuelements AS me ON me.`Id`=up.`ElementId`;";

        protected override string QueryUpdate => "UPDATE userperms " +
            "SET " +
            "`CanRead`=@entityCanRead, " +
            "`CanWrite`=@entityCanWrite, " +
            "`CanEdit`=@entityCanEdit, " +
            "`CanDelete`=@entityCanDelete " +
            "WHERE `UserId`=@entityUserId AND `ElementId`=@entityElementId;";

        protected override string QueryDelete => "DELETE FROM userperms " +
            "WHERE `UserId`=@entityUserId AND `ElementId`=@entityElementId;";

        protected override MySqlParameterCollection FillParameters(UserPermEntity entity, MySqlCommand command)
        {
            command.Parameters.AddWithValue("@entityUserId", entity.UserId);
            command.Parameters.AddWithValue("@entityElementId", entity.ElementId);
            command.Parameters.AddWithValue("@entityCanRead", entity.CanRead);
            command.Parameters.AddWithValue("@entityCanWrite", entity.CanWrite);
            command.Parameters.AddWithValue("@entityCanEdit", entity.CanEdit);
            command.Parameters.AddWithValue("@entityCanDelete", entity.CanDelete);
            return command.Parameters;
        }

        protected override IList<TUserPerm> AddFromRows<TUserPerm>(DataTable table)
        {
            IList<TUserPerm> result = new List<TUserPerm>();
            if (table == null)
                return new List<TUserPerm>();
            foreach (DataRow row in table.Rows)
                result.Add(ParseEntity<TUserPerm>(row));
            return result;
        }

        public override void Delete(uint userId, uint elementId)
        {
            MySqlCommand command = new MySqlCommand(QueryDelete);
            command.Parameters.AddWithValue("@entityUserId", userId);
            command.Parameters.AddWithValue("@entityElementId", elementId);
            DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
        }

        protected override string FirstIdName => "UserId";
        protected override string SecondIdName => "ElementId";

        public override TUserPerm ParseEntity<TUserPerm>(DataRow row)
        {
            string[] trueValues = { "1", "true", "True"};
            return new TUserPerm
            {
                UserId = uint.Parse(row["UserId"].ToString()),
                UserLogin = row["UserLogin"].ToString(),
                ElementId = uint.Parse(row["ElementId"].ToString()),
                ElementName = row["ElementName"].ToString(),
                CanRead = trueValues.Contains(row["CanRead"].ToString()),
                CanWrite = trueValues.Contains(row["CanWrite"].ToString()),
                CanEdit = trueValues.Contains(row["CanEdit"].ToString()),
                CanDelete = trueValues.Contains(row["CanDelete"].ToString())
            };
        }
    }
}
