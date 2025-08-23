using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class BranchOrderDB : BasicSimpleCRUD<IBranchOrder>
    {
        protected override string TableName
        {
            get
            {
                return "branchorders";
            }
        }

        protected override string QueryCreate
        {
            get
            {
                return $"INSERT INTO branchorders (" +
                    $"`BranchId`, `DateTime`" +
                    $") VALUES (" +
                    $"@entityId, @entityDateTime" +
                    $");";
            }
        }

        protected override string QueryRead
        {
            get
            {
                return $"SELECT " +
                    $"bo.`Id` AS `Id`, " +
                    $"bo.`BranchId` AS `BranchId`, " +
                    $"br.`Name` AS `BranchName`, " +
                    $"bo.`DateTime` AS `DateTime` " +
                    $"FROM branchorders AS bo " +
                    $"LEFT JOIN branches AS br ON br.`Id`=bo.`BranchId`;";
            }
        }

        protected override string QueryUpdate
        {
            get
            {
                return $"UPDATE branchorders " +
                    $"SET " +
                    $"`BranchId`=@entityBranchId, " +
                    $"`DateTime`=@entityDateTime " +
                    $"WHERE `Id`=@entityId;";
            }
        }

        protected override MySqlParameterCollection FillParameters(IBranchOrder entity, MySqlCommand command, bool withId = true)
        {
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entityDateTime", entity.DateTime);
            command.Parameters.AddWithValue("@entityBranchId", entity.BranchId);
            return command.Parameters;
        }

        protected override IList<IBranchOrder> AddFromRows(DataTable table)
        {
            IList<IBranchOrder> result = new List<IBranchOrder>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                BranchOrderInfo info = new BranchOrderInfo
                {
                    id = uint.Parse(row["Id"].ToString()),
                    dateTime = DateTime.Parse(row["DateTime"].ToString()),
                    branchId = uint.Parse(row["BranchId"].ToString()),
                    branchName = row["BranchName"].ToString()
                };
                result.Add(new BranchOrder(info));
            }
            return result;
        }
    }
}
