using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class MeasureUnitDB : BasicSimpleCRUD<IMeasureUnit>
    {
        protected override string TableName
        {
            get
            {
                return "measureunits";
            }
        }

        protected override MySqlParameterCollection FillParameters(IMeasureUnit entity, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityName", entity.Name);
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            return command.Parameters;
        }

        protected override IList<IMeasureUnit> AddFromRows(DataTable table)
        {
            IList<IMeasureUnit> result = new List<IMeasureUnit>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                MeasureUnitInfo info = new MeasureUnitInfo
                {
                    id = uint.Parse(row["Id"].ToString()),
                    name = row["Name"].ToString()
                };
                result.Add(new MeasureUnit(info));
            }
            return result;
        }
    }
}
