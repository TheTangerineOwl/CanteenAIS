using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public interface IMenuElement
    {
        [DisplayName("Id")]
        uint Id { get; set; }
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

    public class MenuElement : IMenuElement
    {
        public uint Id { get; set; }
        public uint ParentId { get; set; }
        public string ParentName { get; set; }
        public string Name { get; set; }
        public string DllName { get; set; }
        public string FuncName { get; set; }
        public uint Order { get; set; }

        public MenuElement(
            uint id, uint order,
            string parentName = null,
            uint parentId = 0, string name = null, string dllName = null, string funcName = null
        )
        {
            Id = id;
            Order = order;
            ParentId = parentId;
            ParentName = parentName;
            Name = name;
            DllName = dllName;
            FuncName = funcName;
        }

        public MenuElement(
            uint order, string parentName = null, uint parentId = 0, string name = null, string dllName = null, string funcName = null
        )
        {
            Order = order;
            ParentId = parentId;
            ParentName= parentName;
            Name = name;
            DllName = dllName;
            FuncName = funcName;
        }
    }
}
