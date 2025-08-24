using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class BankDB : BasicSimpleCRUD<IBank>
    {
        protected override string TableName => "banks";

        protected override MySqlParameterCollection FillParameters(IBank entity, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityName", entity.Name);
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            return command.Parameters;
        }

        protected override IList<IBank> AddFromRows(DataTable table)
        {
            IList<IBank> result = new List<IBank>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                BankInfo info = new BankInfo
                {
                    id = uint.Parse(row["Id"].ToString()),
                    name = row["Name"].ToString()
                };
                result.Add(new Bank(info));
            }
            return result;
        }
    }
}
