using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class DishDB : BasicSimpleCRUD<IDish>
    {
        protected override string TableName
        {
            get
            {
                return "dishes";
            }
        }

        protected override string QueryCreate
        {
            get
            {
                return "INSERT INTO dishes (" +
                    "`Id`, `Name`, `GroupId`, `Price`, `Serving`, `UnitId`, `Recipe`, `Picture`" +
                    ") VALUES (" +
                    "@entityId, " +
                    "@entityName, " +
                    "@entityGroupId, " +
                    "@entityPrice, " +
                    "@entityServing, @entityUnitId, @entityRecipe, @entityPicture);";
            }
        }

        protected override string QueryRead
        {
            get
            {
                return $"SELECT " +
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
            }
        }

        protected override string QueryUpdate
        {
            get
            {
                return "UPDATE dishes " +
                    "SET " +
                    "`Name`=@entityName, " +
                    "`GroupId`=@entityGroupId, " +
                    "`Price`=@entityPrice, " +
                    "`Serving`=@entityServing, " +
                    "`UnitId`=@entityUnitId, " +
                    "`Recipe`=@entityRecipe, " +
                    "`Picture`=@entityPicture " +
                    "WHERE `Id`=@entityId;";
            }
        }

        protected override MySqlParameterCollection FillParameters(IDish dish, MySqlCommand command, bool withId = true)
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

        protected override IList<IDish> AddFromRows(DataTable table)
        {
            IList<IDish> result = new List<IDish>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                DishInfo info = new DishInfo
                {
                    id = uint.Parse(row["Id"].ToString()),
                    name = row["Name"].ToString(),
                    groupId = uint.Parse(row["GroupId"].ToString()),
                    groupName = row["GroupName"].ToString(),
                    price = decimal.Parse(row["Price"].ToString()),
                    serving = double.Parse(row["Serving"].ToString()),
                    unitId = uint.Parse(row["UnitId"].ToString()),
                    unitName = row["UnitName"].ToString(),
                    recipe = row["Recipe"].ToString(),
                    picture = row["Picture"].ToString()
                };
                result.Add(new Dish(info));
            }
            return result;
        }
    }
}
