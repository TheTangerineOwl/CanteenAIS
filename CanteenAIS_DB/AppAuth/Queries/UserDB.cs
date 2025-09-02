using CanteenAIS_DB.AppAuth.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CanteenAIS_DB.AppAuth.Queries
{
    public class UserDB : BasicSimpleCRUD<UserEntity>
    {
        protected override string TableName => "users";

        protected override string QueryCreate => "INSERT INTO users (" +
                    "`Login`, `Password`, `LastName`, `FirstName`, `Patronim`, `DateOfBirth`" +
                    ") VALUES (" +
                    "@entityLogin, @entityPassword, @entityLastName, @entityFirstName, @entityPatronim, @entityDateOfBirth" +
                    ");";

        protected override string QueryRead => "SELECT " +
                    "u.`Id` AS `Id`, " +
                    "u.`Login` AS `Login`, " +
                    "u.`Password` AS `Password`, " +
                    "u.`LastName` AS `LastName`, " +
                    "u.`FirstName` AS `FirstName`, " +
                    "u.`Patronim` AS `Patronim`, " +
                    "u.`DateOfBirth` AS `DateOfBirth` " +
                    "FROM users AS u;";

        protected override string QueryUpdate => "UPDATE users " +
                    "SET " +
                    "`Login`=@entityLogin, " +
                    "`Password`=@entityPassword, " +
                    "`LastName`=@entityLastName, " +
                    "`FirstName`=@entityFirstName, " +
                    "`Patronim`=@entityPatronim, " +
                    "`DateOfBirth`=@entityDateOfBirth " +
                    "WHERE `Id`=@entityId;";

        protected override MySqlParameterCollection FillParameters(UserEntity entity, MySqlCommand command, bool withId = true)
        {
            if (withId)
                command.Parameters.AddWithValue("@entityId", entity.Id);
            command.Parameters.AddWithValue("@entityLogin", entity.Login);
            command.Parameters.AddWithValue("@entityPassword", entity.Password);
            command.Parameters.AddWithValue("@entityLastName", entity.LastName);
            command.Parameters.AddWithValue("@entityFirstName", entity.FirstName);
            command.Parameters.AddWithValue("@entityPatronim", entity.Patronim);
            command.Parameters.AddWithValue("@entityDateOfBirth", entity.DateOfBirth);
            return command.Parameters;
        }

        protected override IList<TUser> AddFromRows<TUser>(DataTable table)
        {
            IList<TUser> result = new List<TUser>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
                result.Add(ParseEntity<TUser>(row));
            return result;
        }

        public override TUser ParseEntity<TUser>(DataRow row)
        {
            TUser user = new TUser
            {
                Id = uint.Parse(row["Id"].ToString()),
                Login = DataRowExtensions.Field<string>(row, "Login"),
                Password = DataRowExtensions.Field<string>(row, "Password"),
                LastName = DataRowExtensions.Field<string>(row, "LastName"),
                FirstName = DataRowExtensions.Field<string>(row, "FirstName"),
                Patronim = DataRowExtensions.Field<string>(row, "Patronim"),
                DateOfBirth = DataRowExtensions.Field<DateTime?>(row, "DateOfBirth")
            };
            return user;
        }
    }
}
