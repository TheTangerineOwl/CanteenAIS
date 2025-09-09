using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class AssortmentGroupDB : BasicSimpleCRUD<AssortmentGroupEntity>
    {
        protected override string TableName => "assortmentgroups";

        protected override MySqlParameterCollection FillParameters(AssortmentGroupEntity entity, MySqlCommand command)
        {
            command.Parameters.AddWithValue("@entityName", entity.Name);
            command.Parameters.AddWithValue("@entityId", entity.Id);
            return command.Parameters;
        }

        protected override IList<TAssortmentGroup> AddFromRows<TAssortmentGroup>(DataTable table)
        {
            IList<TAssortmentGroup> result = new List<TAssortmentGroup>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
                result.Add(ParseEntity<TAssortmentGroup>(row));
            return result;
        }

        public override TAssortmentGroup ParseEntity<TAssortmentGroup>(DataRow row)
        {
            return new TAssortmentGroup
            {
                Id = uint.Parse(row["Id"].ToString()),
                Name = DataRowExtensions.Field<string>(row, "Name")
            };
        }
    }
}
