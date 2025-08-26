using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class BankDB : BasicSimpleCRUD<BankEntity>
    {
        protected override string TableName => "banks";

        protected override MySqlParameterCollection FillParameters(BankEntity entity, MySqlCommand command, bool withId = true)
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
            {
                TBank info = new TBank
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
