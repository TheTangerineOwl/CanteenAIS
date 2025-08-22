using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class IngredientDB : BasicDoubleCRUD<IIngredient>
    {
        protected override string TableName
        {
            get
            {
                return "ingredients";
            }
        }

        protected override string QueryCreate
        {
            get
            {
                return "INSERT INTO ingredients (" +
                    "`DishId`, `ProductId`, `Gross`, `Net`, `UnitId`" +
                    ") VALUES (" +
                    "@entityDishId, @entityProductId, @entityGross, @entityNet, @entityUnitId" +
                    ");";
            }
        }

        protected override string QueryRead
        {
            get
            {
                return "SELECT " +
                    "i.`DishId` AS `DishId`, " +
                    "d.`Name` AS `DishName`, " +
                    "i.`ProductId` AS `ProductId`, " +
                    "p.`Name` AS `ProductName`, " +
                    "i.`Gross` AS `Gross`, " +
                    "i.`Net` AS `Net`, " +
                    "i.`UnitId` AS `UnitId`, " +
                    "mu.`Name` AS `UnitName` " +
                    "FROM ingredients AS i " +
                    "LEFT JOIN dishes AS d ON `DishId`=d.`Id` " +
                    "LEFT JOIN products AS p ON `ProductId`=p.`Id` " +
                    "LEFT JOIN measureunits AS mu ON i.`UnitId`=mu.`Id`;";
            }
        }

        protected override string QueryUpdate
        {
            get
            {
                return "UPDATE ingredients " +
                    "SET " +
                    "`Gross`=@entityGross, " +
                    "`Net`=@entityNet, " +
                    "`UnitId`=@entityUnitId " +
                    "WHERE " +
                    "`DishId`=@entityDishId AND `ProductId`=@entityProductId;";
            }
        }

        protected override string QueryDelete
        {
            get
            {
                return $"DELETE FROM ingredients" +
                    $"WHERE DishId=@entityDishId AND ProductId=@entityProductId";
            }
        }

        protected override MySqlParameterCollection FillParameters(IIngredient en, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityGross", en.Gross);
            command.Parameters.AddWithValue("@entityNet", en.Net);
            command.Parameters.AddWithValue("@entityDishId", en.DishId);
            command.Parameters.AddWithValue("@entityProductId", en.ProductId);
            command.Parameters.AddWithValue("@entityUnitId", en.UnitId);
            return command.Parameters;
        }

        protected override IList<IIngredient> AddFromRows(DataTable table)
        {
            IList<IIngredient> result = new List<IIngredient>();
            if (table == null)
                return new List<IIngredient>();
            foreach (DataRow row in table.Rows)
            {
                IIngredient entity = new Ingredient(
                    dishId: uint.Parse(row["DishId"].ToString()),
                    dishName: row["DishName"].ToString(),
                    productId: uint.Parse(row["ProductId"].ToString()),
                    productName: row["ProductName"].ToString(),
                    unitId: uint.Parse(row["UnitId"].ToString()),
                    unitName: row["UnitName"].ToString(),
                    gross: double.Parse(row["Gross"].ToString()),
                    net: double.Parse(row["Net"].ToString())
                    );
                result.Add(entity);
            }
            return result;
        }

        public override void Delete(uint DishId, uint ProductId)
        {
            MySqlCommand command = new MySqlCommand(QueryDelete);
            command.Parameters.AddWithValue("@entityDishId", DishId);
            command.Parameters.AddWithValue("@entityProductId", ProductId);
            DbConnect.GetInstance().ExecQuery(command, ref exception);
        }
    }
}
