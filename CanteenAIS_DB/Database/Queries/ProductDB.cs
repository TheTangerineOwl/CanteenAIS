using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class ProductDB : BasicSimpleCRUD<IProduct>
    {
        protected override string TableName
        {
            get
            {
                return "products";
            }
        }

        protected override string QueryCreate
        {
            get
            {
                return "INSERT INTO products (" +
                    "`Id`, `Name`, `UnitId`, `Markup`, `Stock`, `ProductId`" +
                    ") VALUES (@entityId, @entityName, @entityUnitId, @entityMarkup, @entityStock, @entitySupplierId);";
            }
        }

        protected override string QueryRead
        {
            get
            {
                return $"SELECT " +
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
            }
        }

        protected override string QueryUpdate
        {
            get
            {
                return "UPDATE products " +
                    "SET " +
                    "`Name`=@entityName, " +
                    "`UnitId`=@entityUnitId, " +
                    "`Markup`=@entityMarkup, " +
                    "`Stock`=@entityStock, " +
                    "`ProductId`=@entitySupplierId " +
                    "WHERE `Id`=@entityId;";
            }
        }

        protected override MySqlParameterCollection FillParameters(IProduct entity, MySqlCommand command, bool withId = true)
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

        protected override IList<IProduct> AddFromRows(DataTable table)
        {
            IList<IProduct> result = new List<IProduct>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                IProduct newDish = new Product(
                    id: uint.Parse(row["Id"].ToString()),
                    name: row["Name"].ToString(),
                    unitId: uint.Parse(row["UnitId"].ToString()),
                    unitName: row["UnitName"].ToString(),
                    markup: decimal.Parse(row["Markup"].ToString()),
                    stock: double.Parse(row["Stock"].ToString()),
                    supplierId: uint.Parse(row["ProductId"].ToString()),
                    supplierName: row["ProductName"].ToString()
                );
                result.Add(newDish);
            }
            return result;
        }
    }
}
