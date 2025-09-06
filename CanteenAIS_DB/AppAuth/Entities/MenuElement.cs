using System.ComponentModel;

namespace CanteenAIS_DB.AppAuth.Entities
{
    public abstract class MenuElementEntity : SimpleEntity
    {
        [ColumnDisplay("Родитель", true, 0)]
        public virtual string ParentName { get; set; }
        public virtual uint? ParentId { get; set; }
        [ColumnDisplay("Имя", true, 1)]
        public virtual string Name { get; set; }
        [ColumnDisplay("Библиотека", true, 2)]
        public virtual string DllName { get; set; }
        [ColumnDisplay("Функция", true, 3)]
        public virtual string FuncName { get; set; }
        [ColumnDisplay("Порядок", true, 4)]
        public virtual uint Order { get; set; }

        [ColumnDisplay("Доступно по умолчанию", true, 5)]
        public virtual bool IsAllowedByDefault { get; set; }

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
            IsAllowedByDefault = info.IsAllowedByDefault;
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
