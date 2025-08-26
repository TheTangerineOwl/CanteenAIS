using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class DishDB : BasicSimpleCRUD<DishEntity>
    {
        protected override string TableName => "dishes";

        protected override string QueryCreate => "INSERT INTO dishes (" +
            "`Id`, `Name`, `GroupId`, `Price`, `Serving`, `UnitId`, `Recipe`, `Picture`" +
            ") VALUES (" +
            "@entityId, " +
            "@entityName, " +
            "@entityGroupId, " +
            "@entityPrice, " +
            "@entityServing, @entityUnitId, @entityRecipe, @entityPicture);";

        protected override string QueryRead => $"SELECT " +
            $"d.`Id` AS `Id`, " +
            $"d.`Name` AS `Name`, " +
            $"d.`GroupId` AS `GroupId`, " +
            $"ag.`Name` AS `GroupName`, " +
            $"d.`Price` AS `Price`, " +
            $"d.`Serving` AS `Serving`, " +
            $"d.`UnitId` AS `UnitId`, " +
            $"mu.`Name` AS `UnitName`, " +
            $"d.`Recipe` AS `Recipe`, " +
            $"d.`Picture` AS `Picture` " +
            $"FROM dishes AS d " +
            $"LEFT JOIN assortmentgroups AS ag ON `GroupId`=ag.`Id` " +
            $"LEFT JOIN measureunits AS mu ON `UnitId`=mu.`Id`;";

        protected override string QueryUpdate => "UPDATE dishes " +
            "SET " +
            "`Name`=@entityName, " +
            "`GroupId`=@entityGroupId, " +
            "`Price`=@entityPrice, " +
            "`Serving`=@entityServing, " +
            "`UnitId`=@entityUnitId, " +
            "`Recipe`=@entityRecipe, " +
            "`Picture`=@entityPicture " +
            "WHERE `Id`=@entityId;";

        protected override MySqlParameterCollection FillParameters(DishEntity dish, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityName", dish.Name);
            if (withId)
                command.Parameters.AddWithValue("@entityId", dish.Id);
            command.Parameters.AddWithValue("@entityGroupId", dish.GroupId);
            command.Parameters.AddWithValue("@entityServing", dish.Serving);
            command.Parameters.AddWithValue("@entityUnitId", dish.UnitId);
            command.Parameters.AddWithValue("@entityPrice", dish.Price);
            command.Parameters.AddWithValue("@entityRecipe", dish.Recipe);
            command.Parameters.AddWithValue("@entityPicture", dish.Picture);
            return command.Parameters;
        }

        protected override IList<TDish> AddFromRows<TDish>(DataTable table)
        {
            IList<TDish> result = new List<TDish>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                TDish info = new TDish
                {
                    Id = uint.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString(),
                    GroupId = uint.Parse(row["GroupId"].ToString()),
                    GroupName = row["GroupName"].ToString(),
                    Price = decimal.Parse(row["Price"].ToString()),
                    Serving = double.Parse(row["Serving"].ToString()),
                    UnitId = uint.Parse(row["UnitId"].ToString()),
                    UnitName = row["UnitName"].ToString(),
                    Recipe = row["Recipe"].ToString(),
                    Picture = row["Picture"].ToString()
                };
                result.Add(info);
            }
            return result;
        }
    }
}
