using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class AssortmentGroupDB : BasicSimpleCRUD<IAssortmentGroup>
    {
        protected override string TableName
        {
            get
            {
                return "assortmentgroups";
            }
        }

        protected override MySqlParameterCollection FillParameters(IAssortmentGroup entity, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityName", entity.Name);
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            return command.Parameters;
        }

        protected override IList<IAssortmentGroup> AddFromRows(DataTable table)
        {
            IList<IAssortmentGroup> result = new List<IAssortmentGroup>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                result.Add(
                    new AssortmentGroup(
                        id: uint.Parse(row["Id"].ToString()),
                        name: row["Name"].ToString()
                ));
            }
            return result;
        }
    }
}
