using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class StreetDB : BasicSimpleCRUD<IStreet>
    {
        protected override string TableName
        {
            get
            {
                return "streets";
            }
        }

        protected override string QueryCreate
        {
            get
            {
                return "UPDATE streets " +
                    "SET " +
                    "`CityId`=@entityCityId, " +
                    "`Name`=@entityName " +
                    "WHERE `Id`=@entityId;";
            }
        }

        protected override string QueryRead
        {
            get
            {
                return "SELECT " +
                    "s.`Id` AS `Id`, " +
                    "s.`CityId` AS `CityId`, " +
                    "c.`Name` AS `CityName`, " +
                    "s.`Name` AS `Name` " +
                    "FROM streets AS s " +
                    "LEFT JOIN cities AS c ON c.`Id`=`CityId`;";
            }
        }

        protected override string QueryUpdate
        {
            get
            {
                return "INSERT INTO streets (" +
                    "`Id`, `CityId`, `Name`" +
                    ") VALUES (" +
                    "@entityId, @entityCityId, @entityName" +
                    ");";
            }
        }

        protected override MySqlParameterCollection FillParameters(IStreet entity, MySqlCommand command, bool withId = true)
        {
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entityCityId", entity.CityId);
            command.Parameters.AddWithValue("@entityName", entity.Name);
            return command.Parameters;
        }

        protected override IList<IStreet> AddFromRows(DataTable table)
        {
            IList<IStreet> result = new List<IStreet>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                result.Add(
                    new Street(
                        id: uint.Parse(row["Id"].ToString()),
                        cityId: uint.Parse(row["CityId"].ToString()),
                        cityName: row["CityName"].ToString(),
                        name: row["Name"].ToString()
                ));
            }
            return result;
        }
    }
}
