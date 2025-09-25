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

        protected override string QueryDelete => $"DELETE FROM ingredients " +
            $"WHERE DishId=@entityDishId AND ProductId=@entityProductId";

        protected override MySqlParameterCollection FillParameters(IngredientEntity en, MySqlCommand command, bool withId = false)
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
                result.Add(ParseEntity<TIngredient>(row));
            return result;
        }

        public override void Delete(uint DishId, uint ProductId)
        {
            MySqlCommand command = new MySqlCommand(QueryDelete);
            command.Parameters.AddWithValue("@entityDishId", DishId);
            command.Parameters.AddWithValue("@entityProductId", ProductId);
            DbConnection.GetInstance().ExecMySqlQuery(command, ref exception);
        }

        protected override string FirstIdName => "DishId";
        protected override string SecondIdName => "ProductId";

        public override TIngredient ParseEntity<TIngredient>(DataRow row)
        {
            return new TIngredient
            {
                DishId = uint.TryParse(row["DishId"].ToString(), out uint did) ? did : 0,
                DishName = DataRowExtensions.Field<string>(row, "DishName"),
                ProductId = uint.TryParse(row["ProductId"].ToString(), out uint pid) ? pid : 0,
                ProductName = DataRowExtensions.Field<string>(row, "ProductName"),
                UnitId = DataRowExtensions.Field<uint>(row, "UnitId"),
                UnitName = DataRowExtensions.Field<string>(row, "UnitName"),
                Gross = DataRowExtensions.Field<double>(row, "Gross"),
                Net = DataRowExtensions.Field<double>(row, "Net")
            };
        }
    }
}
