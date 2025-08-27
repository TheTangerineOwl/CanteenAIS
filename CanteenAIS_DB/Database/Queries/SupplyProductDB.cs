using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class SupplyProductDB : BasicDoubleCRUD<SupplyProductEntity>
    {
        protected override string TableName => "supplyproducts";

        protected override string QueryCreate =>
            "INSERT INTO supplyproducts (" +
            "`SupplyId`, `ProductId`, `Amount`, `UnitId`, `Price`" +
            ") VALUES (" +
            "@entitySupplyId, @entityProductId, @entityAmount, @entityUnitId, @entityPrice" +
            ");";

        protected override string QueryRead =>
            "SELECT " +
            "sp.`SupplyId` AS `SupplyId`, " +
            "sp.`ProductId` AS `ProductId`, " +
            "p.`Name` AS `ProductName`, " +
            "sp.`Amount` AS `Amount`, " +
            "sp.`UnitId` AS `UnitId`, " +
            "mu.`Name` AS `UnitName`, " +
            "sp.`Price` AS `Price` " +
            "FROM supplyproducts AS sp " +
            "LEFT JOIN supplies AS s ON s.`Id`=sp.`SupplyId` " +
            "LEFT JOIN products AS p ON p.`Id`=sp.`ProductId` " +
            "LEFT JOIN measureunits AS mu ON mu.`Id`=sp.`UnitId`;";

        protected override string QueryUpdate =>
            "UPDATE supplyproducts " +
            "SET " +
            "`Amount`=@entityAmount, " +
            "`UnitId`=@entityUnitId, " +
            "`Price`=@entityPrice " +
            "WHERE `SupplyId`=@entitySupplyId AND `ProductId`=@entityProductId;";

        protected override string QueryDelete =>
            $"DELETE FROM supplyproducts " +
            $"WHERE `SupplyId`=@entitySupplyId AND `ProductId`=@entityProductId";

        protected override MySqlParameterCollection FillParameters(SupplyProductEntity entity, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entitySupplyId", entity.SupplyId);
            command.Parameters.AddWithValue("@entityProductId", entity.ProductId);
            command.Parameters.AddWithValue("@entityAmount", entity.Amount);
            command.Parameters.AddWithValue("@entityUnitId", entity.UnitId);
            command.Parameters.AddWithValue("@entityPrice", entity.Price);
            return command.Parameters;
        }

        protected override IList<TSupplyProduct> AddFromRows<TSupplyProduct>(DataTable table)
        {
            IList<TSupplyProduct> result = new List<TSupplyProduct>();
            if (table == null)
                return new List<TSupplyProduct>();
            foreach (DataRow row in table.Rows)
                result.Add(ParseEntity<TSupplyProduct>(row));
            return result;
        }

        public override void Delete(uint supplyId, uint productId)
        {
            MySqlCommand command = new MySqlCommand(QueryDelete);
            command.Parameters.AddWithValue("@entitySupplyId", supplyId);
            command.Parameters.AddWithValue("@entityProductId", productId);
            DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
        }

        protected override string FirstIdName => "SupplyId";
        protected override string SecondIdName => "ProductId";

        public override TSupplyProduct ParseEntity<TSupplyProduct>(DataRow row)
        {
            return new TSupplyProduct
            {
                SupplyId = uint.Parse(row["SupplyId"].ToString()),
                ProductId = uint.Parse(row["ProductId"].ToString()),
                ProductName = DataRowExtensions.Field<string>(row, "ProductName"),
                UnitId = DataRowExtensions.Field<uint>(row, "UnitId"),
                UnitName = DataRowExtensions.Field<string>(row, "UnitName"),
                Amount = DataRowExtensions.Field<double>(row, "Amount"),
                Price = DataRowExtensions.Field<decimal>(row, "Price")
            };
        }
    }
}
