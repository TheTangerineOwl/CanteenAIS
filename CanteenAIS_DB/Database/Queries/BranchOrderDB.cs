using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class BranchOrderDB : BasicSimpleCRUD<BranchOrderEntity>
    {
        protected override string TableName => "branchorders";

        protected override string QueryCreate => $"INSERT INTO branchorders (" +
            $"`Id`, `BranchId`, `DateTime`" +
            $") VALUES (" +
            $"@entityId, @entityBranchId, @entityDateTime" +
            $");";

        protected override string QueryRead => $"SELECT " +
            $"bo.`Id` AS `Id`, " +
            $"bo.`BranchId` AS `BranchId`, " +
            $"br.`Name` AS `BranchName`, " +
            $"bo.`DateTime` AS `DateTime` " +
            $"FROM branchorders AS bo " +
            $"LEFT JOIN branches AS br ON br.`Id`=bo.`BranchId`;";

        protected override string QueryUpdate => $"UPDATE branchorders " +
            $"SET " +
            $"`BranchId`=@entityBranchId, " +
            $"`DateTime`=@entityDateTime " +
            $"WHERE `Id`=@entityId;";

        protected override MySqlParameterCollection FillParameters(BranchOrderEntity entity, MySqlCommand command)
        {
            command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entityDateTime", entity.DateTime);
            command.Parameters.AddWithValue("@entityBranchId", entity.BranchId);
            return command.Parameters;
        }

        protected override IList<TBranchOrder> AddFromRows<TBranchOrder>(DataTable table)
        {
            IList<TBranchOrder> result = new List<TBranchOrder>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
                result.Add(ParseEntity<TBranchOrder>(row));
            return result;
        }

        public override TBranchOrder ParseEntity<TBranchOrder>(DataRow row)
        {
            return new TBranchOrder
            {
                Id = uint.Parse(row["Id"].ToString()),
                DateTime = DataRowExtensions.Field<DateTime>(row, "DateTime"),
                BranchId = DataRowExtensions.Field<uint>(row, "BranchId"),
                BranchName = DataRowExtensions.Field<string>(row, "BranchName")
            };
        }
    }
}
