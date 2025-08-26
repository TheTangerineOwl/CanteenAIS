using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class StreetDB : BasicSimpleCRUD<StreetEntity>
    {
        protected override string TableName => "streets";

        protected override string QueryCreate => "UPDATE streets " +
            "SET " +
            "`CityId`=@entityCityId, " +
            "`Name`=@entityName " +
            "WHERE `Id`=@entityId;";

        protected override string QueryRead => "SELECT " +
            "s.`Id` AS `Id`, " +
            "s.`CityId` AS `CityId`, " +
            "c.`Name` AS `CityName`, " +
            "s.`Name` AS `Name` " +
            "FROM streets AS s " +
            "LEFT JOIN cities AS c ON c.`Id`=`CityId`;";

        protected override string QueryUpdate => "INSERT INTO streets (" +
            "`Id`, `CityId`, `Name`" +
            ") VALUES (" +
            "@entityId, @entityCityId, @entityName" +
            ");";

        protected override MySqlParameterCollection FillParameters(StreetEntity entity, MySqlCommand command, bool withId = true)
        {
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entityCityId", entity.CityId);
            command.Parameters.AddWithValue("@entityName", entity.Name);
            return command.Parameters;
        }

        protected override IList<TStreet> AddFromRows<TStreet>(DataTable table)
        {
            IList<TStreet> result = new List<TStreet>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                TStreet info = new TStreet
                {
                    Id = uint.Parse(row["Id"].ToString()),
                    CityId = uint.Parse(row["CityId"].ToString()),
                    CityName = row["CityName"].ToString(),
                    Name = row["Name"].ToString()
                };
                result.Add(info);
            }
            return result;
        }
    }
}
