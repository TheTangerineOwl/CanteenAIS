using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public abstract class UserEntity : SimpleEntity
    {
        [DisplayName("Логин")]
        [ColumnOrder(0)]
        public virtual string Login { get; set; }
        [DisplayName("Пароль")]
        [ColumnOrder(1)]
        public virtual string Password { get; set; }
        [DisplayName("Фамилия")]
        [ColumnOrder(2)]
        public virtual string LastName { get; set; }
        [DisplayName("Имя")]
        [ColumnOrder(3)]
        public virtual string FirstName { get; set; }
        [DisplayName("Отчество")]
        [ColumnOrder(4)]
        public virtual string Patronim { get; set; }
        [DisplayName("Дата рождения")]
        [ColumnOrder(5)]
        public virtual DateTime? DateOfBirth { get; set; }

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

        public override string ToString()
        {
            return Login + " (" + string.Join(" ", LastName, FirstName, Patronim) + ")";
        }
    }

    public class User : UserEntity
    {
        public User() { }

        public User(UserEntity info) : base(info) { }
    }
}
