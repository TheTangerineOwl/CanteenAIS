using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class RealizationDB : BasicSimpleCRUD<IRealization>
    {
        protected override string TableName
        {
            get
            {
                return "realizations";
            }
        }

        protected override string QueryCreate
        {
            get
            {
                return "INSERT INTO realizations (" +
                    "`Id`, `DishId`, `Amount`, `DateTime`, `UnitId`" +
                    ") VALUES (" +
                    "@entityId, @entityDishId, @entityAmount, @entityDateTime, @entityUnitId" +
                    ");";
            }
        }

        protected override string QueryRead
        {
            get
            {
                return "SELECT " +
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
            }
        }

        protected override string QueryUpdate
        {
            get
            {
                return "UPDATE realizations " +
                    "SET " +
                    "`DishId`=@entityDishId, " +
                    "`Amount`=@entityAmount, " +
                    "`DateTime`=@entityDateTime, " +
                    "`UnitId`=@entityUnitId " +
                    "WHERE `Id`=@entityId;";
            }
        }

        protected override MySqlParameterCollection FillParameters(IRealization entity, MySqlCommand command, bool withId = true)
        {
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entityDishId", entity.DishId);
            command.Parameters.AddWithValue("@entityAmount", entity.Amount);
            command.Parameters.AddWithValue("@entityDateTime", entity.DateTime);
            command.Parameters.AddWithValue("@entityUnitId", entity.UnitId);
            return command.Parameters;
        }

        protected override IList<IRealization> AddFromRows(DataTable table)
        {
            IList<IRealization> result = new List<IRealization>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                result.Add(
                    new Realization(
                        id: uint.Parse(row["Id"].ToString()),
                        dishId: uint.Parse(row["DishId"].ToString()),
                        dishName: row["DishName"].ToString(),
                        amount: double.Parse(row["Amount"].ToString()),
                        dateTime: DateTime.Parse(row["DateTime"].ToString()),
                        unitId: uint.Parse(row["UnitId"].ToString()),
                        unitName: row["UnitName"].ToString()
                ));
            }
            return result;
        }
    }
}
