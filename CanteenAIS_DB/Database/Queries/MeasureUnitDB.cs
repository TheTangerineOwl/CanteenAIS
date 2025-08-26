using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class MeasureUnitDB : BasicSimpleCRUD<MeasureUnitEntity>
    {
        protected override string TableName => "measureunits";

        protected override MySqlParameterCollection FillParameters(MeasureUnitEntity entity, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityName", entity.Name);
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            return command.Parameters;
        }

        protected override IList<TMeasureUnit> AddFromRows<TMeasureUnit>(DataTable table)
        {
            IList<TMeasureUnit> result = new List<TMeasureUnit>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                TMeasureUnit info = new TMeasureUnit
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
