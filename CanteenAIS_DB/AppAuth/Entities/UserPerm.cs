using MySqlX.XDevAPI.Common;
using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public interface IUserPerm : IDoubleEntity
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

    public class UserPermInfo : DoubleInfo
    {
        public uint UserId { get => firstId; set => firstId = value; }
        public uint ElementId { get => secondId; set => secondId = value; }
        public string userLogin;
        public string elementName;
        public bool canRead;
        public bool canWrite;
        public bool canEdit;
        public bool canDelete;
    }

    public class UserPerm : IUserPerm
    {
        private readonly UserPermInfo _info;
        public uint UserId { get => _info.UserId; set => _info.UserId = value; }
        public string UserLogin { get => _info.userLogin; set => _info.userLogin = value; }
        public uint ElementId { get => _info.ElementId; set => _info.ElementId = value; }
        public string ElementName { get => _info.elementName; set => _info.elementName = value; }
        public bool CanRead { get => _info.canRead; set => _info.canRead = value; }
        public bool CanWrite { get => _info.canWrite; set => _info.canWrite = value; }
        public bool CanEdit { get => _info.canEdit; set => _info.canEdit = value; }
        public bool CanDelete { get => _info.canDelete; set => _info.canDelete = value; }
        public uint FirstId { get => UserId; set => UserId = value; }
        public uint SecondId { get => ElementId; set => ElementId = value; }

        public UserPerm(UserPermInfo info)
        {
            _info = info;
        }
    }
}
