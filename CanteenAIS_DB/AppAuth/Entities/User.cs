using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public interface IUser
    {
        uint Id { get; set; }
        [DisplayName("Логин")]
        string Login { get; set; }
        [DisplayName("Пароль")]
        string Password { get; set; }
        [DisplayName("Фамилия")]
        string LastName { get; set; }
        [DisplayName("Имя")]
        string FirstName { get; set; }
        [DisplayName("Отчество")]
        string Patronim { get; set; }
        [DisplayName("Дата рождения")]
        DateTime DateOfBirth { get; set; }

        ObservableCollection<IUserPerm> userPerms { get; set; }
    }

    public class User : IUser
    {
        public uint Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronim { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ObservableCollection<IUserPerm> userPerms { get; set; }

        public User(
            uint id, string login, string password, DateTime dateOfBirth,
            string lastName = null, string firstName = null, string patronim = null
        )
        {
            Id = id;
            Login = login;
            Password = password;
            LastName = lastName;
            FirstName = firstName;
            Patronim = patronim;
            DateOfBirth = dateOfBirth;
        }

        public User(
            string login, string password, DateTime dateOfBirth,
            string lastName = null, string firstName = null, string patronim = null
        )
        {
            Login = login;
            Password = password;
            LastName = lastName;
            FirstName = firstName;
            Patronim = patronim;
            DateOfBirth = dateOfBirth;
        }
    }
}
