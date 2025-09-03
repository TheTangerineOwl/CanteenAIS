using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class ProductDB : BasicSimpleCRUD<ProductEntity>
    {
        protected override string TableName => "products";

        protected override string QueryCreate =>
            "INSERT INTO products (" +
            "`Name`, `UnitId`, `Markup`, `Stock`, `SupplierId`" +
            ") VALUES (" +
            "@entityName, @entityUnitId, @entityMarkup, @entityStock, @entitySupplierId);";

        protected override string QueryRead =>
            $"SELECT " +
            $"p.`Id` AS `Id`, " +
            $"p.`Name` AS `Name`, " +
            $"p.`UnitId` AS `UnitId`, " +
            $"mu.`Name` AS `UnitName`, " +
            $"p.`Markup` AS `Markup`, " +
            $"p.`Stock` AS `Stock`, " +
            $"p.`SupplierId` AS `SupplierId`, " +
            $"sr.`Name` AS `SupplierName` " +
            $"FROM products AS p " +
            $"LEFT JOIN measureunits AS mu ON mu.`Id`=p.`UnitId` " +
            $"LEFT JOIN suppliers AS sr ON sr.`Id`=p.`SupplierId`;";

        protected override string QueryUpdate =>
            "UPDATE products " +
            "SET " +
            "`Name`=@entityName, " +
            "`UnitId`=@entityUnitId, " +
            "`Markup`=@entityMarkup, " +
            "`Stock`=@entityStock, " +
            "`SupplierId`=@entitySupplierId " +
            "WHERE `Id`=@entityId;";

        protected override MySqlParameterCollection FillParameters(ProductEntity entity, MySqlCommand command, bool withId = true)
        {
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entityName", entity.Name);
            command.Parameters.AddWithValue("@entityUnitId", entity.UnitId);
            command.Parameters.AddWithValue("@entityMarkup", entity.Markup);
            command.Parameters.AddWithValue("@entityStock", entity.Stock);
            command.Parameters.AddWithValue("@entitySupplierId", entity.SupplierId);
            return command.Parameters;
        }

        protected override IList<TProduct> AddFromRows<TProduct>(DataTable table)
        {
            IList<TProduct> result = new List<TProduct>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
                result.Add(ParseEntity<TProduct>(row));
            return result;
        }

        public override TProduct ParseEntity<TProduct>(DataRow row)
        {
            return new TProduct
            {
                Id = uint.Parse(row["Id"].ToString()),
                Name = DataRowExtensions.Field<string>(row, "Name"),
                UnitId = DataRowExtensions.Field<uint>(row, "UnitId"),
                UnitName = DataRowExtensions.Field<string>(row, "UnitName"),
                Markup = DataRowExtensions.Field<decimal>(row, "Markup"),
                Stock = DataRowExtensions.Field<double>(row, "Stock"),
                SupplierId = DataRowExtensions.Field<uint>(row, "SupplierId"),
                SupplierName = DataRowExtensions.Field<string>(row, "SupplierName")
            };
        }
    }
}
