using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class BankDB : BasicSimpleCRUD<BankEntity>
    {
        protected override string TableName => "banks";

        protected override MySqlParameterCollection FillParameters(BankEntity entity, MySqlCommand command, bool withId)
        {
            command.Parameters.AddWithValue("@entityName", entity.Name);
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            return command.Parameters;
        }

        protected override IList<TBank> AddFromRows<TBank>(DataTable table)
        {
            IList<TBank> result = new List<TBank>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
                result.Add(ParseEntity<TBank>(row));
            return result;
        }

        public override TBank ParseEntity<TBank>(DataRow row)
        {
            return new TBank
            {
                Id = uint.Parse(row["Id"].ToString()),
                Name = DataRowExtensions.Field<string>(row, "Name")
            };
        }
    }
}
