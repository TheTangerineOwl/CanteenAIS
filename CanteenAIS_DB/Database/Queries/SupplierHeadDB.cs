using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class SupplierHeadDB : BasicSimpleCRUD<SupplierHeadEntity>
    {
        protected override string TableName => "supplierheads";

        protected override string QueryCreate =>
            $"INSERT INTO supplierheads (" +
            $"`LastName`, `FirstName`, `Patronim`, `Phone`" +
            $") VALUES (" +
            $"@entityLastName, @entityFirstName, @entityPatronim, @entityPhone" +
            $");";

        protected override string QueryRead => $"SELECT * FROM supplierheads ORDER BY `Id`";

        protected override string QueryUpdate =>
            $"UPDATE supplierheads SET " +
            $"`LastName`=@entityLastName," +
            $"`FirstName`=@entityFirstName," +
            $"`Patronim`=@entityPatronim," +
            $"`Phone`=@entityPhone " +
            $"WHERE `Id`=@entityId";

        protected override string QueryDelete => $"DELETE FROM supplierheads WHERE `Id`=@entityId";

        protected override MySqlParameterCollection FillParameters(SupplierHeadEntity entity, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityLastName", entity.LastName);
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entityFirstName", entity.FirstName);
            command.Parameters.AddWithValue("@entityPatronim", entity.Patronim);
            command.Parameters.AddWithValue("@entityPhone", entity.Phone);
            return command.Parameters;
        }

        protected override IList<THead> AddFromRows<THead>(DataTable table)
        {
            IList<THead> result = new List<THead>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
                result.Add(ParseEntity<THead>(row));
            return result;
        }

        public override THead ParseEntity<THead>(DataRow row)
        {
            return new THead
            {
                Id = uint.Parse(row["Id"].ToString()),
                LastName = DataRowExtensions.Field<string>(row, "LastName"),
                FirstName = DataRowExtensions.Field<string>(row, "FirstName"),
                Patronim = DataRowExtensions.Field<string>(row, "Patronim"),
                Phone = DataRowExtensions.Field<string>(row, "Phone")
            };
        }
    }
}
