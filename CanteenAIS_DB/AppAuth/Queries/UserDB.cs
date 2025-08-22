using CanteenAIS_DB.AppAuth.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CanteenAIS_DB.AppAuth.Queries
{
    public class UserDB : BasicSimpleCRUD<IUser>
    {
        protected override string TableName
        {
            get
            {
                return "users";
            }
        }

        protected override string QueryCreate
        {
            get
            {
                return "INSERT INTO users (" +
                    "`Id`, `Login`, `Password`, `LastName`, `FirstName`, `Patronim`, `DateOfBirth`" +
                    ") VALUES (" +
                    "@entityId, @entityLogin, @entityPassword, @entityLastName, @entityFirstName, @entityPatronim, @entityDateOfBirth" +
                    ");";
            }
        }

        protected override string QueryRead
        {
            get
            {
                return "SELECT " +
                    "u.`Id` AS `Id`, " +
                    "u.`Login` AS `Login`, " +
                    "u.`Password` AS `Password`, " +
                    "u.`LastName` AS `LastName`, " +
                    "u.`FirstName` AS `FirstName`, " +
                    "u.`Patronim` AS `Patronim`, " +
                    "u.`DateOfBirth` AS `DateOfBirth` " +
                    "FROM users AS u;";
            }
        }

        protected override string QueryUpdate
        {
            get
            {
                return "UPDATE users " +
                    "SET " +
                    "`Login`=@entityLogin, " +
                    "`Password`=@entityPassword, " +
                    "`LastName`=@entityLastName, " +
                    "`FirstName`=@entityFirstName, " +
                    "`Patronim`=@entityPatronim, " +
                    "`DateOfBirth`=@entityDateOfBirth " +
                    "WHERE `Id`=@entityId;";
            }
        }

        protected override MySqlParameterCollection FillParameters(IUser entity, MySqlCommand command, bool withId = true)
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

        protected override IList<IUser> AddFromRows(DataTable table)
        {
            IList<IUser> result = new List<IUser>();
            if (table == null)
                return result;
            foreach (DataRow row in table.Rows)
            {
                result.Add(
                    new User(
                        id: uint.Parse(row["Id"].ToString()),
                        login: row["Login"].ToString(),
                        password: row["Password"].ToString(),
                        lastName: row["LastName"].ToString(),
                        firstName: row["FirstName"].ToString(),
                        patronim: row["Patronim"].ToString(),
                        dateOfBirth: DateTime.Parse(row["DateOfBirth"].ToString())
                ));
            }
            return result;
        }
    }
}
