using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class CityDB : BasicSimpleCRUD<CityEntity>
    {
        protected override string TableName => "cities";

        protected override MySqlParameterCollection FillParameters(CityEntity entity, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityName", entity.Name);
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            return command.Parameters;
        }

        protected override IList<TCity> AddFromRows<TCity>(DataTable table)
        {
            IList<TCity> result = new List<TCity>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                TCity info = new TCity
                {
                    Id = uint.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString()
                };
                result.Add(info);
            }
            return result;
        }
    }
}
