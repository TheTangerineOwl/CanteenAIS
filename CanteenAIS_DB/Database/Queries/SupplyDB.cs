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
            "`SupplierId`, `DateTime`" +
            ") VALUES (" +
            "@entitySupplierId, @entityDateTime" +
            ");";

        protected override string QueryRead =>
            "SELECT " +
            "s.`Id` AS `Id`, " +
            "s.`SupplierId` AS `SupplierId`, " +
            "sr.`Name` AS `SupplierName`, " +
            "s.`DateTime` AS `DateTime` " +
            "FROM supplies AS s " +
            "LEFT JOIN suppliers AS sr ON sr.`Id`=s.`SupplierId`;";

        protected override string QueryUpdate =>
            "UPDATE supplies " +
            "SET " +
            "`SupplierId`=@entitySupplierId, " +
            "`DateTime`=@entityDateTime " +
            "WHERE `Id`=@entityId;";

        protected override MySqlParameterCollection FillParameters(SupplyEntity entity, MySqlCommand command, bool withId = false)
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
                result.Add(ParseEntity<TSupply>(row));
            return result;
        }

        public override TSupply ParseEntity<TSupply>(DataRow row)
        {
            return new TSupply
            {
                Id = uint.Parse(row["Id"].ToString()),
                SupplierId = DataRowExtensions.Field<uint>(row, "SupplierId"),
                SupplierName = DataRowExtensions.Field<string>(row, "SupplierName"),
                DateTime = DataRowExtensions.Field<DateTime>(row, "DateTime")
            };
        }
    }
}
