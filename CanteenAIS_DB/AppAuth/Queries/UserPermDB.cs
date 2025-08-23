using CanteenAIS_DB.AppAuth.Entities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace CanteenAIS_DB.AppAuth.Queries
{
    public class UserPermDB : BasicDoubleCRUD<IUserPerm>
    {
        protected override string TableName
        {
            get
            {
                return "userperms";
            }
        }

        protected override string QueryCreate
        {
            get
            {
                return "INSERT INTO userperms (" +
                    "`UserId`, `ElementId`, `CanRead`, `CanWrite`, `CanEdit`, `CanDelete`" +
                    ") VALUES (" +
                    "@entityUserId, @entityElementId, @entityCanRead, @entityCanWrite, @entityCanEdit, @entityCanDelete" +
                    ");";
            }
        }

        protected override string QueryRead
        {
            get
            {
                return "SELECT " +
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
            }
        }

        protected override string QueryUpdate
        {
            get
            {
                return "UPDATE userperms " +
                    "SET " +
                    "`CanRead`=@entityCanRead, " +
                    "`CanWrite`=@entityCanWrite, " +
                    "`CanEdit`=@entityCanEdit, " +
                    "`CanDelete`=@entityCanDelete " +
                    "WHERE `UserId`=@entityUserId AND `ElementId`=@entityElementId;";
            }
        }

        protected override string QueryDelete
        {
            get
            {
                return "DELETE FROM userperms WHERE `UserId`=@entityUserId AND `ElementId`=@entityElementId;";
            }
        }

        protected override MySqlParameterCollection FillParameters(IUserPerm entity, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityUserId", entity.UserId);
            command.Parameters.AddWithValue("@entityElementId", entity.ElementId);
            command.Parameters.AddWithValue("@entityCanRead", entity.CanRead);
            command.Parameters.AddWithValue("@entityCanWrite", entity.CanWrite);
            command.Parameters.AddWithValue("@entityCanEdit", entity.CanEdit);
            command.Parameters.AddWithValue("@entityCanDelete", entity.CanDelete);
            return command.Parameters;
        }

        protected override IList<IUserPerm> AddFromRows(DataTable table)
        {
            IList<IUserPerm> result = new List<IUserPerm>();
            if (table == null)
                return new List<IUserPerm>();
            foreach (DataRow row in table.Rows)
            {
                UserPermInfo info = new UserPermInfo
                {
                    UserId = uint.Parse(row["UserId"].ToString()),
                    userLogin = row["UserLogin"].ToString(),
                    ElementId = uint.Parse(row["ElementId"].ToString()),
                    elementName = row["ElementName"].ToString(),
                    canRead = bool.Parse(row["CanRead"].ToString()),
                    canWrite = bool.Parse(row["CanWrite"].ToString()),
                    canEdit = bool.Parse(row["CanEdit"].ToString()),
                    canDelete = bool.Parse(row["CanDelete"].ToString())
                };
                result.Add(new UserPerm(info));
            }
            return result;
        }

        public override void Delete(uint userId, uint elementId)
        {
            MySqlCommand command = new MySqlCommand(QueryDelete);
            command.Parameters.AddWithValue("@entityUserId", userId);
            command.Parameters.AddWithValue("@entityElementId", elementId);
            DbConnection.GetInstance().ExecQuery(command, ref exception);
        }
    }
}
