using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class SupplyDB : BasicSimpleCRUD<SupplyEntity>
    {
        protected override string TableName => "supplies";

        protected override string QueryCreate =>
            "INSERT INTO supplies (" +
            "`Id`, `ProductId`, `DateTime`" +
            ") VALUES (" +
            "@entityId, @entitySupplierId, @entityDateTime" +
            ");";

        protected override string QueryRead =>
            "SELECT " +
            "s.`Id` AS `Id`, " +
            "s.`ProductId` AS `ProductId`, " +
            "sr.`Name` AS `ProductName`, " +
            "s.`DateTime` AS `DateTime` " +
            "FROM supplies AS s " +
            "LEFT JOIN suppliers AS sr ON sr.`Id`=s.`ProductId`;";

        protected override string QueryUpdate =>
            "UPDATE supplies " +
            "SET " +
            "`ProductId`=@entitySupplierId, " +
            "`DateTime`=@entityDateTime " +
            "WHERE `Id`=@entityId;";

        protected override MySqlParameterCollection FillParameters(SupplyEntity entity, MySqlCommand command, bool withId = true)
        {
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entitySupplierId", entity.SupplierId);
            command.Parameters.AddWithValue("@entitySupplierName", entity.SupplierName);
            command.Parameters.AddWithValue("@entityDateTime", entity.DateTime);
            return command.Parameters;
        }

        protected override IList<TSupply> AddFromRows<TSupply>(DataTable table)
        {
            IList<TSupply> result = new List<TSupply>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                TSupply info = new TSupply
                {
                    Id = uint.Parse(row["Id"].ToString()),
                    SupplierId = uint.Parse(row["ProductId"].ToString()),
                    SupplierName = row["ProductName"].ToString(),
                    DateTime = DateTime.Parse(row["DateTime"].ToString())
                };
                result.Add(info);
            }
            return result;
        }
    }
}
