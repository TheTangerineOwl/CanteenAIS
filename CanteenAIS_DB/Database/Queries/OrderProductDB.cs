using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;
using Org.BouncyCastle.Crypto;

namespace CanteenAIS_DB.Database.Queries
{
    public class OrderProductDB : BasicDoubleCRUD<OrderProductEntity>
    {
        protected override string TableName => "orderproducts";

        protected override string QueryCreate =>
            "INSERT INTO orderproducts (" +
            "`OrderId`, `ProductId`, `UnitId`, `Amount`" +
            ") VALUES (" +
            "@entityOrderId, @entityProductId, @entityUnitId, @entityAmount" +
            ");";

        protected override string QueryRead =>
            "SELECT " +
            "op.`OrderId` AS `OrderId`, " +
            "op.`ProductId` AS `ProductId`, " +
            "p.`Name` AS `ProductName`, " +
            "op.`Amount` AS `Amount`, " +
            "op.`UnitId` AS `UnitId`, " +
            "mu.`Name` AS `UnitName` " +
            "FROM orderproducts AS op " +
            "LEFT JOIN branchorders AS bo ON bo.`Id`=`OrderId` " +
            "LEFT JOIN products AS p ON p.`Id`=`ProductId` " +
            "LEFT JOIN measureunits AS mu ON mu.`Id`=op.`UnitId`;";

        protected override string QueryUpdate =>
            "UPDATE orderproducts " +
            "SET " +
            "`UnitId`=@entityUnitId, " +
            "`Amount`=@entityAmount " +
            "WHERE " +
            "`OrderId`=@entityOrderId AND `ProductId`=@entityProductId;";

        protected override string QueryDelete =>
            $"DELETE FROM orderproducts " +
            $"WHERE `OrderId`=@entityOrderId AND `ProductId`=@entityProductId";

        protected override MySqlParameterCollection FillParameters(OrderProductEntity entity, MySqlCommand command)
        {
            command.Parameters.AddWithValue("@entityOrderId", entity.OrderId);
            command.Parameters.AddWithValue("@entityProductId", entity.ProductId);
            command.Parameters.AddWithValue("@entityAmount", entity.Amount);
            command.Parameters.AddWithValue("@entityUnitId", entity.UnitId);
            return command.Parameters;
        }

        protected override IList<TOrderProduct> AddFromRows<TOrderProduct>(DataTable table)
        {
            IList<TOrderProduct> result = new List<TOrderProduct>();
            if (table == null)
                return new List<TOrderProduct>();
            foreach (DataRow row in table.Rows)
                result.Add(ParseEntity<TOrderProduct>(row));
            return result;
        }

        public override void Delete(uint orderId, uint productId)
        {
            MySqlCommand command = new MySqlCommand(QueryDelete);
            command.Parameters.AddWithValue("@entityOrderId", orderId);
            command.Parameters.AddWithValue("@entityProductId", productId);
            DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
        }

        protected override string FirstIdName => "OrderId";
        protected override string SecondIdName => "ProductId";

        public override TOrderProduct ParseEntity<TOrderProduct>(DataRow row)
        {
            return new TOrderProduct
            {
                OrderId = uint.TryParse(row["OrderId"].ToString(), out uint did) ? did : 0,
                ProductId = uint.TryParse(row["ProductId"].ToString(), out uint pid) ? pid : 0,
                ProductName = DataRowExtensions.Field<string>(row, "ProductName"),
                UnitId = DataRowExtensions.Field<uint>(row, "UnitId"),
                UnitName = DataRowExtensions.Field<string>(row, "UnitName"),
                Amount = DataRowExtensions.Field<double>(row, "Amount")
            };
        }
    }
}
