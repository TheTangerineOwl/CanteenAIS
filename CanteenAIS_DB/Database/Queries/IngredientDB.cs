using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class IngredientDB : BasicDoubleCRUD<IngredientEntity>
    {
        protected override string TableName => "ingredients";

        protected override string QueryCreate => "INSERT INTO ingredients (" +
            "`DishId`, `ProductId`, `Gross`, `Net`, `UnitId`" +
            ") VALUES (" +
            "@entityDishId, @entityProductId, @entityGross, @entityNet, @entityUnitId" +
            ");";

        protected override string QueryRead => "SELECT " +
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

        protected override string QueryUpdate => "UPDATE ingredients " +
            "SET " +
            "`Gross`=@entityGross, " +
            "`Net`=@entityNet, " +
            "`UnitId`=@entityUnitId " +
            "WHERE " +
            "`DishId`=@entityDishId AND `ProductId`=@entityProductId;";

        protected override string QueryDelete => $"DELETE FROM ingredients" +
            $"WHERE DishId=@entityDishId AND ProductId=@entityProductId";

        protected override MySqlParameterCollection FillParameters(IngredientEntity en, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityGross", en.Gross);
            command.Parameters.AddWithValue("@entityNet", en.Net);
            command.Parameters.AddWithValue("@entityDishId", en.DishId);
            command.Parameters.AddWithValue("@entityProductId", en.ProductId);
            command.Parameters.AddWithValue("@entityUnitId", en.UnitId);
            return command.Parameters;
        }

        protected override IList<TIngredient> AddFromRows<TIngredient>(DataTable table)
        {
            IList<TIngredient> result = new List<TIngredient>();
            if (table == null)
                return new List<TIngredient>();
            foreach (DataRow row in table.Rows)
            {
                TIngredient info = new TIngredient
                {
                    DishId = uint.Parse(row["DishId"].ToString()),
                    DishName = row["DishName"].ToString(),
                    ProductId = uint.Parse(row["ProductId"].ToString()),
                    ProductName = row["ProductName"].ToString(),
                    UnitId = uint.Parse(row["UnitId"].ToString()),
                    UnitName = row["UnitName"].ToString(),
                    Gross = double.Parse(row["Gross"].ToString()),
                    Net = double.Parse(row["Net"].ToString())
                };
                result.Add(info);
            }
            return result;
        }

        public override void Delete(uint DishId, uint ProductId)
        {
            MySqlCommand command = new MySqlCommand(QueryDelete);
            command.Parameters.AddWithValue("@entityDishId", DishId);
            command.Parameters.AddWithValue("@entityProductId", ProductId);
            DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
        }
    }
}
