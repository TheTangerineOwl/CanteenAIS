using System;
using System.Collections.ObjectModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    /// <summary>
    /// Класс, представляющий пользователя в системе.
    /// </summary>
    public abstract class UserEntity : SimpleEntity
    {
        [ColumnDisplay( "Логин", true, 0)]
        public virtual string Login { get; set; }
        [ColumnDisplay("Пароль", true, 1)]
        public virtual string Password { get; set; }
        [ColumnDisplay("Фамилия", true, 2)]
        public virtual string LastName { get; set; }
        [ColumnDisplay("Имя", true, 3)]
        public virtual string FirstName { get; set; }
        [ColumnDisplay("Отчество", true, 4)]
        public virtual string Patronim { get; set; }
        [ColumnDisplay("Дата рождения", true, 5)]
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
