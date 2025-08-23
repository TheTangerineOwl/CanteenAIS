using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class SupplyDB : BasicSimpleCRUD<ISupply>
    {
        protected override string TableName
        {
            get
            {
                return "supplies";
            }
        }

        protected override string QueryCreate
        {
            get
            {
                return "INSERT INTO supplies (" +
                    "`Id`, `ProductId`, `DateTime`" +
                    ") VALUES (" +
                    "@entityId, @entitySupplierId, @entityDateTime" +
                    ");";
            }
        }

        protected override string QueryRead
        {
            get
            {
                return "SELECT " +
                    "s.`Id` AS `Id`, " +
                    "s.`ProductId` AS `ProductId`, " +
                    "sr.`Name` AS `ProductName`, " +
                    "s.`DateTime` AS `DateTime` " +
                    "FROM supplies AS s " +
                    "LEFT JOIN suppliers AS sr ON sr.`Id`=s.`ProductId`;";
            }
        }

        protected override string QueryUpdate
        {
            get
            {
                return "UPDATE supplies " +
                    "SET " +
                    "`ProductId`=@entitySupplierId, " +
                    "`DateTime`=@entityDateTime " +
                    "WHERE `Id`=@entityId;";
            }
        }

        protected override MySqlParameterCollection FillParameters(ISupply entity, MySqlCommand command, bool withId = true)
        {
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entitySupplierId", entity.SupplierId);
            command.Parameters.AddWithValue("@entitySupplierName", entity.SupplierName);
            command.Parameters.AddWithValue("@entityDateTime", entity.DateTime);
            return command.Parameters;
        }

        protected override IList<ISupply> AddFromRows(DataTable table)
        {
            IList<ISupply> result = new List<ISupply>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                SupplyInfo info = new SupplyInfo
                {
                    id = uint.Parse(row["Id"].ToString()),
                    supplierId = uint.Parse(row["ProductId"].ToString()),
                    supplierName = row["ProductName"].ToString(),
                    dateTime = DateTime.Parse(row["DateTime"].ToString())
                };
                result.Add(new Supply(info));
            }
            return result;
        }
    }
}
