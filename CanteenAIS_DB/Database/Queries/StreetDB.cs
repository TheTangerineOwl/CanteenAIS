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
            "`CityId`, `Name`" +
            ") VALUES (" +
            "@entityCityId, @entityName" +
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
                result.Add(ParseEntity<TStreet>(row));
            return result;
        }

        public override TStreet ParseEntity<TStreet>(DataRow row)
        {
            return new TStreet
            {
                Id = uint.Parse(row["Id"].ToString()),
                CityId = DataRowExtensions.Field<uint>(row, "CityId"),
                CityName = DataRowExtensions.Field<string>(row, "CityName"),
                Name = DataRowExtensions.Field<string>(row, "Name")
            };
        }
    }
}
