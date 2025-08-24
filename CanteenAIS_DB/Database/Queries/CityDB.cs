using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class CityDB : BasicSimpleCRUD<ICity>
    {
        protected override string TableName => "cities";

        protected override MySqlParameterCollection FillParameters(ICity entity, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityName", entity.Name);
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            return command.Parameters;
        }

        protected override IList<ICity> AddFromRows(DataTable table)
        {
            IList<ICity> result = new List<ICity>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                CityInfo info = new CityInfo
                {
                    id = uint.Parse(row["Id"].ToString()),
                    name = row["Name"].ToString()
                };
                result.Add(new City(info));
            }
            return result;
        }
    }
}
