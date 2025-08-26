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
            "`Id`, `Name`, `UnitId`, `Markup`, `Stock`, `ProductId`" +
            ") VALUES (" +
            "@entityId, @entityName, @entityUnitId, @entityMarkup, @entityStock, @entitySupplierId);";

        protected override string QueryRead =>
            $"SELECT " +
            $"p.`Id` AS `Id`, " +
            $"p.`Name` AS `Name`, " +
            $"p.`UnitId` AS `UnitId`, " +
            $"mu.`Name` AS `UnitName`, " +
            $"p.`Markup` AS `Markup`, " +
            $"p.`Stock` AS `Stock`, " +
            $"p.`ProductId` AS `ProductId`, " +
            $"sr.`Name` AS `ProductName` " +
            $"FROM products AS p " +
            $"LEFT JOIN measureunits AS mu ON mu.`Id`=p.`UnitId` " +
            $"LEFT JOIN suppliers AS sr ON sr.`Id`=p.`ProductId`;";

        protected override string QueryUpdate =>
            "UPDATE products " +
            "SET " +
            "`Name`=@entityName, " +
            "`UnitId`=@entityUnitId, " +
            "`Markup`=@entityMarkup, " +
            "`Stock`=@entityStock, " +
            "`ProductId`=@entitySupplierId " +
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
            {
                TProduct info = new TProduct
                {
                    Id = uint.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString(),
                    UnitId = uint.Parse(row["UnitId"].ToString()),
                    UnitName = row["UnitName"].ToString(),
                    Markup = decimal.Parse(row["Markup"].ToString()),
                    Stock = double.Parse(row["Stock"].ToString()),
                    SupplierId = uint.Parse(row["SupplierId"].ToString()),
                    SupplierName = row["SupplierName"].ToString()
                };
                result.Add(info);
            }
            return result;
        }
    }
}
