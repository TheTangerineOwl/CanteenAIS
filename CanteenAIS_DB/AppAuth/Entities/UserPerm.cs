using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public abstract class UserPermEntity : DoubleEntity
    {
        public override uint FirstId { get => UserId; set => UserId = value; }
        public override uint SecondId { get => ElementId; set => ElementId = value; }

        public virtual uint UserId { get; set; }
        [DisplayName("Логин")]
        [ColumnOrder(0)]
        public virtual string UserLogin { get; set; }
        public virtual uint ElementId { get; set; }
        [DisplayName("Элемент меню")]
        [ColumnOrder(1)]
        public virtual string ElementName { get; set; }
        [DisplayName("Чтение")]
        [ColumnOrder(2)]
        public virtual bool CanRead { get; set; }
        [DisplayName("Добавление")]
        [ColumnOrder(3)]
        public virtual bool CanWrite { get; set; }
        [DisplayName("Редактирование")]
        [ColumnOrder(4)]
        public virtual bool CanEdit { get; set; }
        [DisplayName("Удаление")]
        [ColumnOrder(5)]
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
