using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class RealizationDB : BasicSimpleCRUD<RealizationEntity>
    {
        protected override string TableName => "realizations";

        protected override string QueryCreate =>
            "INSERT INTO realizations (" +
            "`Id`, `DishId`, `Amount`, `DateTime`, `UnitId`" +
            ") VALUES (" +
            "@entityId, @entityDishId, @entityAmount, @entityDateTime, @entityUnitId" +
            ");";

        protected override string QueryRead =>
            "SELECT " +
            "r.`Id` AS `Id`, " +
            "r.`DishId` AS `DishId`, " +
            "d.`Name` AS `DishName`, " +
            "r.`Amount` AS `Amount`, " +
            "r.`DateTime` AS `DateTime`, " +
            "r.`UnitId` AS `UnitId`, " +
            "mu.`Name` AS `UnitName` " +
            "FROM realizations AS r " +
            "LEFT JOIN dishes AS d ON d.`Id`=r.`DishId` " +
            "LEFT JOIN measureunits AS mu ON mu.`Id`=r.`UnitId`;";

        protected override string QueryUpdate =>
            "UPDATE realizations " +
            "SET " +
            "`DishId`=@entityDishId, " +
            "`Amount`=@entityAmount, " +
            "`DateTime`=@entityDateTime, " +
            "`UnitId`=@entityUnitId " +
            "WHERE `Id`=@entityId;";

        protected override MySqlParameterCollection FillParameters(RealizationEntity entity, MySqlCommand command, bool withId = true)
        {
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entityDishId", entity.DishId);
            command.Parameters.AddWithValue("@entityAmount", entity.Amount);
            command.Parameters.AddWithValue("@entityDateTime", entity.DateTime);
            command.Parameters.AddWithValue("@entityUnitId", entity.UnitId);
            return command.Parameters;
        }

        protected override IList<TRealization> AddFromRows<TRealization>(DataTable table)
        {
            IList<TRealization> result = new List<TRealization>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                TRealization info = new TRealization
                {
                    Id = uint.Parse(row["Id"].ToString()),
                    DishId = uint.Parse(row["DishId"].ToString()),
                    DishName = row["DishName"].ToString(),
                    Amount = double.Parse(row["Amount"].ToString()),
                    DateTime = DateTime.Parse(row["DateTime"].ToString()),
                    UnitId = uint.Parse(row["UnitId"].ToString()),
                    UnitName = row["UnitName"].ToString()
                };
                result.Add(info);
            }
            return result;
        }
    }
}
