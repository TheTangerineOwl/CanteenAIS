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

        protected override MySqlParameterCollection FillParameters(SupplierEntity entity, MySqlCommand command)
        {
            command.Parameters.AddWithValue("@entityName", entity.Name);
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
                result.Add(ParseEntity<TSupplier>(row));
            return result;
        }

        public override TSupplier ParseEntity<TSupplier>(DataRow row)
        {
            return new TSupplier
            {
                Id = uint.Parse(row["Id"].ToString()),
                Name = DataRowExtensions.Field<string>(row, "Name"),
                StreetId = DataRowExtensions.Field<uint>(row, "StreetId"),
                CityName = DataRowExtensions.Field<string>(row, "CityName"),
                StreetName = DataRowExtensions.Field<string>(row, "StreetName"),
                Building = DataRowExtensions.Field<string>(row, "Building"),
                HeadId = DataRowExtensions.Field<uint>(row, "HeadId"),
                HeadName = DataRowExtensions.Field<string>(row, "HeadName"),
                HeadPhone = DataRowExtensions.Field<string>(row, "HeadPhone"),
                BankId = DataRowExtensions.Field<uint>(row, "BankId"),
                BankName = DataRowExtensions.Field<string>(row, "BankName"),
                Account = DataRowExtensions.Field<string>(row, "Account"),
                INN = DataRowExtensions.Field<string>(row, "INN")
            };
        }
    }
}
