using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class BranchDB : BasicSimpleCRUD<BranchEntity>
    {
        protected override string TableName => "branches";

        protected override MySqlParameterCollection FillParameters(BranchEntity entity, MySqlCommand command, bool withId = false)
        {
            command.Parameters.AddWithValue("@entityName", entity.Name);
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            return command.Parameters;
        }

        protected override IList<TBranch> AddFromRows<TBranch>(DataTable table)
        {
            IList<TBranch> result = new List<TBranch>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
                result.Add(ParseEntity<TBranch>(row));
            return result;
        }

        public override TBranch ParseEntity<TBranch>(DataRow row)
        {
            return new TBranch
            {
                Id = uint.Parse(row["Id"].ToString()),
                Name = DataRowExtensions.Field<string>(row, "Name")
            };
        }
    }
}
