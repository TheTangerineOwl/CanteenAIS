using CanteenAIS_DB.AppAuth.Entities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace CanteenAIS_DB.AppAuth.Queries
{
    public class MenuElementDB : BasicSimpleCRUD<IMenuElement>
    {
        protected override string TableName
        {
            get
            {
                return "menuelements";
            }
        }

        protected override string QueryCreate
        {
            get
            {
                return "INSERT INTO menuelements (" +
                    "`Id`, `ParentId`, `Name`, `DllName`, `FuncName`, `Order`" +
                    ") VALUES (" +
                    "@entityId, @entityParentId, @entityName, @entityDllName, @entityFuncName, @entityOrder);";
            }
        }

        protected override string QueryRead
        {
            get
            {
                return "SELECT " +
                    "me.`Id` AS `Id`, " +
                    "me.`ParentId` AS `ParentId`, " +
                    "mep.`Name` AS `ParentName`, " +
                    "me.`Name` AS `Name`, " +
                    "me.`DllName` AS `DllName`, " +
                    "me.`FuncName` AS `FuncName`, " +
                    "me.`Order` AS `Order` " +
                    "FROM canteenapp.menuelements AS me " +
                    "LEFT JOIN canteenapp.menuelements AS mep ON me.`ParentId`=mep.`Id`;";
            }
        }

        protected override string QueryUpdate
        {
            get
            {
                return "UPDATE menuelements " +
                    "SET " +
                    "`ParentId`=@entityParentId, " +
                    "`Name`=@entityName, " +
                    "`DllName`=@entityDllName, " +
                    "`FuncName`=@entityFuncName, " +
                    "`Order`=@entityOrder " +
                    "WHERE `Id`=@entityId;";
            }
        }

        protected override MySqlParameterCollection FillParameters(IMenuElement entity, MySqlCommand command, bool withId = true)
        {
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entityParentId", entity.ParentId);
            command.Parameters.AddWithValue("@entityParentName", entity.ParentName);
            command.Parameters.AddWithValue("@entityName", entity.Name);
            command.Parameters.AddWithValue("@entityDllName", entity.DllName);
            command.Parameters.AddWithValue("@entityFuncName", entity.FuncName);
            command.Parameters.AddWithValue("@entityOrder", entity.Order);
            return command.Parameters;
        }

        protected override IList<IMenuElement> AddFromRows(DataTable table)
        {
            IList<IMenuElement> result = new List<IMenuElement>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                ElementInfo info = new ElementInfo
                {
                    id = uint.Parse(row["Id"].ToString()),
                    order = uint.Parse(row["Order"].ToString()),
                    parentId = uint.Parse(row["ParentId"].ToString()),
                    name = row["Name"].ToString(),
                    dllName = row["DllName"].ToString(),
                    funcName = row["FuncName"].ToString()
                };
                result.Add(new MenuElement(info));
            }
            return result;
        }
    }
}
