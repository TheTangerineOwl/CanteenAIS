using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class SupplierDB : BasicSimpleCRUD<SupplierEntity>
    {
        protected override string TableName => "suppliers";

        protected override string QueryCreate => "INSERT INTO suppliers (" +
            "`Id`, `Name`, `StreetId`, `Building`, `HeadId`, `BankId`, `Account`, `INN`" +
            ") VALUES (" +
            "@entityId, " +
            "@entityName, " +
            "@entityStreetId, " +
            "@entityBUilding, " +
            "@entityHeadId, " +
            "@entityBankId, " +
            "@entityAccount, " +
            "@entityINN" +
            ");";

        protected override string QueryRead =>
            "SELECT " +
            "sr.`Id` AS `Id`, " +
            "sr.`Name` AS `Name`, " +
            "sr.`StreetId` AS `StreetId`, " +
            "c.`Name` AS `CityName`, " +
            "st.`Name` AS `StreetName`, " +
            "sr.`Building` AS `Building`, " +
            "sr.`HeadId` AS `HeadId`, " +
            "sh.`FullName` AS `HeadName`, " +
            "sh.`Phone` AS `HeadPhone`, " +
            "sr.`BankId` AS `BankId`, " +
            "b.`Name` AS `BankName`, " +
            "sr.`Account` AS `Account`, " +
            "sr.`INN` AS `INN` " +
            "FROM suppliers AS sr " +
            "LEFT JOIN streets AS st ON st.`Id`=sr.`StreetId` " +
            "LEFT JOIN cities AS c ON c.`Id`=st.`CityId` " +
            "LEFT JOIN supplierheads AS sh ON sh.`Id`=sr.`HeadId` " +
            "LEFT JOIN banks AS b ON b.`Id`=sr.`BankId`;";

        protected override string QueryUpdate =>
            "UPDATE suppliers " +
            "SET " +
            "`Name`=@entityName, " +
            "`StreetId`=@entityStreetId, " +
            "`Building`=@entityBuilding, " +
            "`HeadId`=@entityHeadId, " +
            "`BankId`=@entityBankId, " +
            "`Account`=@entityAccount, " +
            "`INN`=@entityINN " +
            "WHERE `Id`=@entityId;";

        protected override string QueryDelete => $"DELETE FROM suppliers WHERE Id=@entityId";

        protected override MySqlParameterCollection FillParameters(SupplierEntity entity, MySqlCommand command, bool withId = true)
        {
            command.Parameters.AddWithValue("@entityName", entity.Name);
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entityBuilding", entity.Building);
            command.Parameters.AddWithValue("@entityStreetId", entity.StreetId);
            command.Parameters.AddWithValue("@entityHeadId", entity.HeadId);
            command.Parameters.AddWithValue("@entityBankId", entity.BankId);
            command.Parameters.AddWithValue("@entityAccount", entity.Account);
            command.Parameters.AddWithValue("@entityINN", entity.INN);
            return command.Parameters;
        }

        protected override IList<TSupplier> AddFromRows<TSupplier>(DataTable table)
        {
            IList<TSupplier> result = new List<TSupplier>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                TSupplier info = new TSupplier
                {
                    Id = uint.Parse(row["Id"].ToString()),
                    Name = row["Name"].ToString(),
                    StreetId = uint.Parse(row["StreetId"].ToString()),
                    CityName = row["CityName"].ToString(),
                    StreetName = row["StreetName"].ToString(),
                    Building = row["Building"].ToString(),
                    HeadId = uint.Parse(row["HeadId"].ToString()),
                    HeadName = row["HeadName"].ToString(),
                    HeadPhone = row["HeadPhone"].ToString(),
                    BankId = uint.Parse(row["BankId"].ToString()),
                    BankName = row["BankName"].ToString(),
                    Account = row["Account"].ToString(),
                    INN = row["INN"].ToString()
                };
                result.Add(info);
            }
            return result;
        }
    }
}
