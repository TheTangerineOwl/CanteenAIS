using CanteenAIS_DB;
using CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_DB.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenAIS_Models.Management.Models
{
    public class MenuElementModel : SimpleModel<IMenuElement, ElementInfo>
    {
        public override string TableName => "Главное меню";

        public MenuElementModel(BasicSimpleCRUD<IMenuElement> context) : base(context) { }

        public override void Add(ElementInfo info)
        {
            TableContext.Create(new MenuElement(info));
        }

        public override void Update(DataRow row, ElementInfo info)
        {
            info.id = GetId(row);
            TableContext.Update(new MenuElement(info));
        }

        public override int CompareEntities(IMenuElement first, IMenuElement second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.Id.CompareTo(second.Id);
            if (compared != 0) return compared;
            compared = first.ParentId.CompareTo(second.ParentId);
            if (compared != 0) return compared;
            compared = string.Compare(first.Name, second.Name);
            if (compared != 0) return compared;
            compared = first.DllName.CompareTo(second.DllName);
            if (compared != 0) return compared;
            compared = first.FuncName.CompareTo(second.FuncName);
            if (compared != 0) return compared;
            compared = first.Order.CompareTo(second.Order);
            if (compared != 0) return compared;
            return 0;
        }

        public override bool ContainsString(IMenuElement entity, string sample)
        {
            return (
                entity.Id.ToString().Contains(sample) ||
                entity.Name.Contains(sample) ||
                entity.ParentId.ToString().Contains(sample) ||
                entity.DllName.Contains(sample) ||
                entity.FuncName.Contains(sample) ||
                entity.Order.ToString().Contains(sample)
            );
        }
    }
}
