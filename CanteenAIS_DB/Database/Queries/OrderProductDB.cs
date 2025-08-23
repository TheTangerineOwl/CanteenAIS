using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class OrderProductDB : BasicDoubleCRUD<IOrderProduct>
    {
        protected override string TableName
        {
            get
            {
                return "orderproducts";
            }
        }

        protected override string QueryCreate
        {
            get
            {
                return "INSERT INTO orderproducts (" +
                    "`OrderId`, `ProductId`, `UnitId`, `Amount`" +
                    ") VALUES (" +
                    "@entityOrderId, @entityProductId, @entityUnitId, @entityAmount" +
                    ");";
            }
        }

        protected override string QueryRead
        {
            get
            {
                return "SELECT " +
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
            }
        }

        protected override string QueryUpdate
        {
            get
            {
                return "UPDATE orderproducts " +
                    "SET " +
                    "`UnitId`=@entityUnitId, " +
                    "`Amount`=@entityAmount " +
                    "WHERE " +
                    "`OrderId`=@entityOrderId AND `ProductId`=@entityProductId;";
            }
        }

        protected override string QueryDelete
        {
            get
            {
                return $"DELETE FROM orderproducts " +
                    $"WHERE `OrderId`=@entityOrderId AND `ProductId`=@entityProductId";
            }
        }

        protected override MySqlParameterCollection FillParameters(IOrderProduct entity, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityOrderId", entity.OrderId);
            command.Parameters.AddWithValue("@entityProductId", entity.ProductId);
            command.Parameters.AddWithValue("@entityAmount", entity.Amount);
            command.Parameters.AddWithValue("@entityUnitId", entity.UnitId);
            return command.Parameters;
        }

        protected override IList<IOrderProduct> AddFromRows(DataTable table)
        {
            IList<IOrderProduct> result = new List<IOrderProduct>();
            if (table == null)
                return new List<IOrderProduct>();
            foreach (DataRow row in table.Rows)
            {
                OrderProductInfo info = new OrderProductInfo{
                    OrderId = uint.Parse(row["OrderId"].ToString()),
                    ProductId = uint.Parse(row["ProductId"].ToString()),
                    productName = row["ProductName"].ToString(),
                    unitId = uint.Parse(row["UnitId"].ToString()),
                    unitName = row["UnitName"].ToString(),
                    amount = double.Parse(row["Amount"].ToString())
                };
                result.Add(new OrderProduct(info));
            }
            return result;
        }

        public override void Delete(uint orderId, uint productId)
        {
            MySqlCommand command = new MySqlCommand(QueryDelete);
            command.Parameters.AddWithValue("@entityOrderId", orderId);
            command.Parameters.AddWithValue("@entityProductId", productId);
            DbConnection.GetInstance().ExecQuery(command, ref exception);
        }
    }
}
