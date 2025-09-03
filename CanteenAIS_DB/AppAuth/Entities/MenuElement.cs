using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public abstract class MenuElementEntity : SimpleEntity
    {
        [DisplayName("Родитель")]
        [ColumnOrder(0)]
        public virtual string ParentName { get; set; }
        public virtual uint? ParentId { get; set; }
        [DisplayName("Имя")]
        [ColumnOrder(1)]
        public virtual string Name { get; set; }
        [DisplayName("Dll")]
        [ColumnOrder(2)]
        public virtual string DllName { get; set; }
        [DisplayName("Функция")]
        [ColumnOrder(3)]
        public virtual string FuncName { get; set; }
        [DisplayName("Order")]
        [ColumnOrder(4)]
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

        public override string ToString()
        {
            return Name;
        }
    }

    public class MenuElement : MenuElementEntity
    {
        public MenuElement() { }

        public MenuElement(MenuElementEntity info) : base(info) { }
    }
}
