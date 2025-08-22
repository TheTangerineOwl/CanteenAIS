using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class SupplierHeadDB : BasicSimpleCRUD<ISupplierHead>
    {
        protected override string TableName
        {
            get
            {
                return "supplierheads";
            }
        }

        protected override string QueryCreate
        {
            get
            {
                return $"INSERT INTO supplierheads (" +
                    $"`LastName`, `FirstName`, `Patronim`, `Phone`" +
                    $") VALUES (" +
                    $"@entityLastName, @entityFirstName, @entityPatronim, @entityPhone" +
                    $");";
            }
        }

        protected override string QueryRead
        {
            get
            {
                return $"SELECT * FROM supplierheads ORDER BY `Id`";
            }
        }

        protected override string QueryUpdate
        {
            get
            {
                return $"UPDATE supplierheads SET " +
                    $"`LastName`=@entityLastName," +
                    $"`FirstName`=@entityFirstName," +
                    $"`Patronim`=@entityPatronim," +
                    $"`Phone`=@entityPhone " +
                    $"WHERE `Id`=@entityId";
            }
        }

        protected override string QueryDelete
        {
            get
            {
                return $"DELETE FROM supplierheads WHERE `Id`=@entityId";
            }
        }

        protected override MySqlParameterCollection FillParameters(ISupplierHead entity, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityLastName", entity.LastName);
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entityFirstName", entity.FirstName);
            command.Parameters.AddWithValue("@entityPatronim", entity.Patronim);
            command.Parameters.AddWithValue("@entityPhone", entity.Phone);
            return command.Parameters;
        }

        protected override IList<ISupplierHead> AddFromRows(DataTable table)
        {
            IList<ISupplierHead> result = new List<ISupplierHead>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                result.Add(
                    new SupplierHead(
                        id: uint.Parse(row["Id"].ToString()),
                        lastName: row["LastName"].ToString(),
                        firstName: row["FirstName"].ToString(),
                        patronim: row["Patronim"].ToString(),
                        phone: row["Phone"].ToString()
                ));
            }
            return result;
        }


    }
}
