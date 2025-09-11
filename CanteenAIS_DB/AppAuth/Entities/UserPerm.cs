namespace CanteenAIS_DB.AppAuth.Entities
{
    /// <summary>
    /// Класс для пунктов главного меню.
    /// </summary>
    public abstract class UserPermEntity : DoubleEntity
    {
        public override uint FirstId { get => UserId; set => UserId = value; }
        public override uint SecondId { get => ElementId; set => ElementId = value; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public virtual uint UserId { get; set; }
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        [ColumnDisplay("Логин", true, 0)]
        public virtual string UserLogin { get; set; }
        /// <summary>
        /// Идентификатор элемента меню.
        /// </summary>
        public virtual uint ElementId { get; set; }
        /// <summary>
        /// Имя элемента меню.
        /// </summary>
        [ColumnDisplay("Элемент меню", true, 1)]
        public virtual string ElementName { get; set; }
        /// <summary>
        /// Имеет ли пользователь право на взаимодействие с элементом и чтение данных таблиц?
        /// </summary>
        [ColumnDisplay("Чтение", true, 2)]
        public virtual bool CanRead { get; set; }
        /// <summary>
        /// Имеет ли пользователь право на добавление строк в таблицу?
        /// </summary>
        [ColumnDisplay("Добавление", true, 3)]
        public virtual bool CanWrite { get; set; }
        /// <summary>
        /// Имеет ли пользователь право на редактирование строк в таблице?
        /// </summary>
        [ColumnDisplay("Редактирование", true, 4)]
        public virtual bool CanEdit { get; set; }
        /// <summary>
        /// Имеет ли пользователь право на удаление строк из таблицы?
        /// </summary>
        [ColumnDisplay("Удаление", true, 5)]
        public virtual bool CanDelete { get; set; }

        public UserPermEntity() { }

        public UserPermEntity(UserPermEntity info)
        {
            UserId = info.UserId;
            UserLogin = info.UserLogin;
            ElementId = info.ElementId;
            ElementName = info.ElementName;
            CanRead = info.CanRead;
            CanWrite = info.CanWrite;
            CanEdit = info.CanEdit;
            CanDelete = info.CanDelete;
        }

        public override string ToString()
        {
            return $"({UserLogin}, {ElementName})";
        }
    }

    public class UserPerm : UserPermEntity
    {
        public UserPerm() { }

        public UserPerm(UserPermEntity info) : base(info) { }
    }
}
