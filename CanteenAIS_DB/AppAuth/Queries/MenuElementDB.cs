using CanteenAIS_DB.AppAuth.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CanteenAIS_DB.AppAuth.Queries
{
    public class MenuElementDB : BasicSimpleCRUD<MenuElementEntity>
    {
        protected override string TableName => "menuelements";

        protected override string QueryCreate => "INSERT INTO menuelements (" +
                    "`Id`, `ParentId`, `Name`, `DllName`, `FuncName`, `Order`" +
                    ") VALUES (" +
                    "@entityId, @entityParentId, @entityName, @entityDllName, @entityFuncName, @entityOrder);";

        protected override string QueryRead => "SELECT " +
                    "me.`Id` AS `Id`, " +
                    "me.`ParentId` AS `ParentId`, " +
                    "mep.`Name` AS `ParentName`, " +
                    "me.`Name` AS `Name`, " +
                    "me.`DllName` AS `DllName`, " +
                    "me.`FuncName` AS `FuncName`, " +
                    "me.`Order` AS `Order` " +
                    "FROM menuelements AS me " +
                    "LEFT JOIN menuelements AS mep ON me.`ParentId`=mep.`Id`;";

        protected override string QueryUpdate => "UPDATE menuelements " +
                    "SET " +
                    "`ParentId`=@entityParentId, " +
                    "`Name`=@entityName, " +
                    "`DllName`=@entityDllName, " +
                    "`FuncName`=@entityFuncName, " +
                    "`Order`=@entityOrder " +
                    "WHERE `Id`=@entityId;";

        protected override MySqlParameterCollection FillParameters(MenuElementEntity entity, MySqlCommand command, bool withId = true)
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

        protected override IList<TEntity> AddFromRows<TEntity>(DataTable table)
        {
            IList<TEntity> result = new List<TEntity>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
                result.Add(ParseEntity<TEntity>(row));
            return result;
        }

        public override TElement ParseEntity<TElement>(DataRow row)
        {
            TElement entity = new TElement
            {
                Id = uint.Parse(row["Id"].ToString()),
                Order = DataRowExtensions.Field<uint>(row, "Order"),
                Name = DataRowExtensions.Field<string>(row, "Name"),
                ParentId = DataRowExtensions.Field<uint?>(row, "ParentId"),
                ParentName = DataRowExtensions.Field<string>(row, "ParentName"),
                DllName = DataRowExtensions.Field<string>(row, "DllName"),
                FuncName = DataRowExtensions.Field<string>(row, "FuncName")
            };
            return entity;
        }
    }
}
