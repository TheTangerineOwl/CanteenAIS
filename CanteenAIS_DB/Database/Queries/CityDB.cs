using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class CityDB : BasicSimpleCRUD<CityEntity>
    {
        protected override string TableName => "cities";

        protected override MySqlParameterCollection FillParameters(CityEntity entity, MySqlCommand command)
        {
            command.Parameters.AddWithValue("@entityName", entity.Name);
            command.Parameters.AddWithValue("@entityId", entity.Id);
            return command.Parameters;
        }

        protected override IList<TCity> AddFromRows<TCity>(DataTable table)
        {
            IList<TCity> result = new List<TCity>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
                result.Add(ParseEntity<TCity>(row));
            return result;
        }

        public override TCity ParseEntity<TCity>(DataRow row)
        {
            return new TCity
            {
                Id = uint.Parse(row["Id"].ToString()),
                Name = DataRowExtensions.Field<string>(row, "Name")
            };
        }
    }
}
