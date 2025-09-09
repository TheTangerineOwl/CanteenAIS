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

        protected override MySqlParameterCollection FillParameters(DishEntity dish, MySqlCommand command)
        {
            command.Parameters.AddWithValue("@entityName", dish.Name);
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
                result.Add(ParseEntity<TDish>(row));
            return result;
        }

        public override TDish ParseEntity<TDish>(DataRow row)
        {
            return new TDish
            {
                Id = uint.Parse(row["Id"].ToString()),
                Name = DataRowExtensions.Field<string>(row, "Name"),
                GroupId = DataRowExtensions.Field<uint>(row, "GroupId"),
                GroupName = DataRowExtensions.Field<string>(row, "GroupName"),
                Price = DataRowExtensions.Field<decimal>(row, "Price"),
                Serving = DataRowExtensions.Field<double>(row, "Serving"),
                UnitId = DataRowExtensions.Field<uint>(row, "UnitId"),
                UnitName = DataRowExtensions.Field<string>(row, "UnitName"),
                Recipe = DataRowExtensions.Field<string>(row, "Recipe"),
                Picture = DataRowExtensions.Field<string>(row, "Picture")
            };
        }
    }
}
