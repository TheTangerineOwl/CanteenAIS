using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public interface IUserPerm
    {
        uint UserId { get; set; }
        [DisplayName("Логин")]
        string UserLogin { get; set; }
        uint ElementId { get; set; }
        [DisplayName("Элемент меню")]
        string ElementName { get; set; }
        [DisplayName("Чтение")]
        bool CanRead { get; set; }
        [DisplayName("Добавление")]
        bool CanWrite { get; set; }
        [DisplayName("Редактирование")]
        bool CanEdit { get; set; }
        [DisplayName("Удаление")]
        bool CanDelete { get; set; }
    }

    public class UserPerm : IUserPerm
    {
        public uint UserId { get; set; }
        public string UserLogin { get; set; }
        public uint ElementId { get; set; }
        public string ElementName { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        public UserPerm(
            uint userId, string userLogin,
            uint elementId, string elementName,
            bool r, bool w, bool e, bool d
        )
        {
            UserId = userId;
            UserLogin = userLogin;
            ElementId = elementId;
            ElementName = elementName;
            CanRead = r;
            CanWrite = w;
            CanEdit = e;
            CanDelete = d;
        }

        public UserPerm(
            uint userId, uint elementId,
            bool r = false, bool w = false, bool e = false, bool d = false
        )
        {
            UserId = userId;
            ElementId = elementId;
            CanRead = r;
            CanWrite = w;
            CanEdit = e;
            CanDelete = d;
        }
    }
}
