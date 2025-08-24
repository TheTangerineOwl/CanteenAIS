using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_DB.Database.Queries
{
    public class SupplierDB : BasicSimpleCRUD<ISupplier>
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

        protected override MySqlParameterCollection FillParameters(ISupplier entity, MySqlCommand command, bool withId = true)
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

        protected override IList<ISupplier> AddFromRows(DataTable table)
        {
            IList<ISupplier> result = new List<ISupplier>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                SupplierInfo info = new SupplierInfo
                {
                    id = uint.Parse(row["Id"].ToString()),
                    name = row["Name"].ToString(),
                    streetId = uint.Parse(row["StreetId"].ToString()),
                    cityName = row["CityName"].ToString(),
                    streetName = row["StreetName"].ToString(),
                    building = row["Building"].ToString(),
                    headId = uint.Parse(row["HeadId"].ToString()),
                    headName = row["HeadName"].ToString(),
                    headPhone = row["HeadPhone"].ToString(),
                    bankId = uint.Parse(row["BankId"].ToString()),
                    bankName = row["BankName"].ToString(),
                    account = row["Account"].ToString(),
                    inn = row["INN"].ToString()
                };
                result.Add(new Supplier(info));
            }
            return result;
        }
    }
}
