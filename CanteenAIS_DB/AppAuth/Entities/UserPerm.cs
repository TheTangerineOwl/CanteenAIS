using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public abstract class UserPermEntity : DoubleEntity
    {
        public override uint FirstId { get => UserId; set => UserId = value; }
        public override uint SecondId { get => ElementId; set => ElementId = value; }

        public virtual uint UserId { get; set; }
        [DisplayName("Логин")]
        public virtual string UserLogin { get; set; }
        public virtual uint ElementId { get; set; }
        [DisplayName("Элемент меню")]
        public virtual string ElementName { get; set; }
        [DisplayName("Чтение")]
        public virtual bool CanRead { get; set; }
        [DisplayName("Добавление")]
        public virtual bool CanWrite { get; set; }
        [DisplayName("Редактирование")]
        public virtual bool CanEdit { get; set; }
        [DisplayName("Удаление")]
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
    }

    public class UserPerm : UserPermEntity
    {
        public UserPerm() { }

        public UserPerm(UserPermEntity info) : base(info) { }
    }
}
