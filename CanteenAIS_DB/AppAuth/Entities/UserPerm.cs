using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public abstract class UserPermEntity : DoubleEntity
    {
        public override uint FirstId { get => UserId; set => UserId = value; }
        public override uint SecondId { get => ElementId; set => ElementId = value; }

        public virtual uint UserId { get; set; }
        [ColumnDisplay("Логин", true, 0)]
        public virtual string UserLogin { get; set; }
        public virtual uint ElementId { get; set; }
        [ColumnDisplay("Элемент меню", true, 1)]
        public virtual string ElementName { get; set; }
        [ColumnDisplay("Чтение", true, 2)]
        public virtual bool CanRead { get; set; }
        [ColumnDisplay("Добавление", true, 3)]
        public virtual bool CanWrite { get; set; }
        [ColumnDisplay("Редактирование", true, 4)]
        public virtual bool CanEdit { get; set; }
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
