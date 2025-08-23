using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public interface IUser : ISimpleEntity
    {
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

    public class UserInfo : SimpleInfo
    {
        public string login;
        public string password;
        public string lastName;
        public string firstName;
        public string patronim;
        public DateTime dateOfBirth;
    }

    public class User : IUser
    {
        private readonly UserInfo _info;
        public uint Id { get => _info.id; set => _info.id = value; }
        public string Login { get => _info.login; set => _info.login = value; }
        public string Password { get => _info.password; set => _info.password = value; }
        public string LastName { get => _info.lastName; set => _info.lastName = value; }
        public string FirstName { get => _info.firstName; set => _info.firstName = value; }
        public string Patronim { get => _info.patronim; set => _info.patronim = value; }
        public DateTime DateOfBirth { get => _info.dateOfBirth; set => _info.dateOfBirth = value; }

        public ObservableCollection<IUserPerm> userPerms { get; set; }

        public User(UserInfo info)
        {
            _info = info;
        }
    }
}
