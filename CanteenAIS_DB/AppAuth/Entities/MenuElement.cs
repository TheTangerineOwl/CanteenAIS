using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public abstract class MenuElementEntity : SimpleEntity
    {
        [DisplayName("Родитель")]
        public virtual string ParentName { get; set; }
        public virtual uint ParentId { get; set; }
        [DisplayName("Имя")]
        public virtual string Name { get; set; }
        [DisplayName("Dll")]
        public virtual string DllName { get; set; }
        [DisplayName("Функция")]
        public virtual string FuncName { get; set; }
        [DisplayName("Order")]
        public virtual uint Order { get; set; }

        public MenuElementEntity() { }

        public MenuElementEntity(MenuElementEntity info)
        {
            Id = info.Id;
            ParentId = info.ParentId;
            ParentName = info.ParentName;
            Name = info.Name;
            DllName = info.DllName;
            FuncName = info.FuncName;
            Order = info.Order;
        }
    }

    public class MenuElement : MenuElementEntity
    {
        public MenuElement() { }

        public MenuElement(MenuElementEntity info) : base(info) { }
    }
}
