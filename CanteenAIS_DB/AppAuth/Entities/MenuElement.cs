using Org.BouncyCastle.Bcpg;
using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public interface IMenuElement : ISimpleEntity
    {
        [DisplayName("Родитель")]
        string ParentName { get; set; }
        uint ParentId { get; set; }
        [DisplayName("Имя")]
        string Name { get; set; }
        [DisplayName("Dll")]
        string DllName { get; set; }
        [DisplayName("Функция")]
        string FuncName { get; set; }
        [DisplayName("Order")]
        uint Order { get; set; }
    }

    public class ElementInfo : SimpleInfo
    {
        public uint parentId;
        public string parentName;
        public string name;
        public string dllName;
        public string funcName;
        public uint order;
    }

    public class MenuElement : IMenuElement
    {
        private readonly ElementInfo _info;
        public uint Id { get => _info.id; set => _info.id = value; }
        public uint ParentId { get => _info.parentId; set => _info.parentId = value; }
        public string ParentName { get => _info.parentName; set => _info.parentName = value; }
        public string Name { get => _info.name; set => _info.name = value; }
        public string DllName { get => _info.dllName; set => _info.dllName = value; }
        public string FuncName { get => _info.funcName; set => _info.funcName = value; }
        public uint Order { get => _info.order; set => _info.order = value; }

        public MenuElement(ElementInfo info)
        {
            _info = info;
        }
    }
}
