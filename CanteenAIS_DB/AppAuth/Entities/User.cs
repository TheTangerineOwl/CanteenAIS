using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public abstract class UserEntity : SimpleEntity
    {
        [DisplayName("Логин")]
        public virtual string Login { get; set; }
        [DisplayName("Пароль")]
        public virtual string Password { get; set; }
        [DisplayName("Фамилия")]
        public virtual string LastName { get; set; }
        [DisplayName("Имя")]
        public virtual string FirstName { get; set; }
        [DisplayName("Отчество")]
        public virtual string Patronim { get; set; }
        [DisplayName("Дата рождения")]
        public virtual DateTime DateOfBirth { get; set; }

        public virtual ObservableCollection<UserPermEntity> UserPerms { get; set; }

        public UserEntity() { }

        public UserEntity(UserEntity info)
        {
            Id = info.Id;
            Login = info.Login;
            Password = info.Password;
            LastName = info.LastName;
            FirstName = info.FirstName;
            Patronim = info.Patronim;
            DateOfBirth = info.DateOfBirth;
            UserPerms = info.UserPerms;
        }
    }

    public class User : UserEntity
    {
        public User() { }

        public User(UserEntity info) : base(info) { }
    }
}
