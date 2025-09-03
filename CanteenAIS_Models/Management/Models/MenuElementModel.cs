using CanteenAIS_DB;
using CanteenAIS_DB.AppAuth.Entities;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace CanteenAIS_Models.Management.Models
{
    public static class MenuElementModel // : SimpleModel<MenuElementEntity>
    {
        //public override string TableName => "Главное меню";

        //public MenuElementModel(BasicSimpleCRUD<MenuElementEntity> context) : base(context) { }

        //public override void Add<TResult>(MenuElementEntity info)
        //{
        //    TResult result = new TResult
        //    {
        //        Id = info.Id,
        //        ParentId = info.ParentId,
        //        ParentName = info.ParentName,
        //        Name = info.Name,
        //        DllName = info.DllName,
        //        FuncName = info.FuncName,
        //        Order = info.Order
        //    };
        //    TableContext.Create(result);
        //}

        //public override void Update<TResult>(DataRow row, MenuElementEntity info)
        //{
        //    TResult result = new TResult
        //    {
        //        Id = GetId(row),
        //        ParentId = info.ParentId,
        //        ParentName = info.ParentName,
        //        Name = info.Name,
        //        DllName = info.DllName,
        //        FuncName = info.FuncName,
        //        Order = info.Order
        //    };
        //    TableContext.Update(result);
        //}

        //public override int CompareEntities(MenuElementEntity first, MenuElementEntity second)
        //{
        //    if (first == null)
        //        return -1;
        //    if (second == null)
        //        return 1;
        //    int compared = first.Id.CompareTo(second.Id);
        //    if (compared != 0) return compared;
        //    compared = first.ParentId.CompareTo(second.ParentId);
        //    if (compared != 0) return compared;
        //    compared = string.Compare(first.Name, second.Name);
        //    if (compared != 0) return compared;
        //    compared = first.DllName.CompareTo(second.DllName);
        //    if (compared != 0) return compared;
        //    compared = first.FuncName.CompareTo(second.FuncName);
        //    if (compared != 0) return compared;
        //    compared = first.Order.CompareTo(second.Order);
        //    if (compared != 0) return compared;
        //    return 0;
        //}

        //public override bool ContainsString(MenuElementEntity entity, string sample)
        //{
        //    return (
        //        entity.Id.ToString().Contains(sample) ||
        //        entity.Name.Contains(sample) ||
        //        entity.ParentId.ToString().Contains(sample) ||
        //        entity.DllName.Contains(sample) ||
        //        entity.FuncName.Contains(sample) ||
        //        entity.Order.ToString().Contains(sample)
        //    );
        //}

        public static IList<MenuElement> FetchValues()
        {
            return DBContext.GetInstance().MenuElements.Read<MenuElement>();//.ToList();
        }

        public static uint GetCurrentMenuElemId(string elementName)
        {
            IList<MenuElement> res = DBContext.GetInstance().MenuElements.Read<MenuElement>();
            return res.FirstOrDefault(e => "Click" + e.FuncName == elementName).Id;
        }
    }
}
