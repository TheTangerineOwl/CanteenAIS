using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System.Data;

namespace CanteenAIS_Models.Models
{
    public class IngredientModel : DoubleModel<IngredientEntity>
    {
        public override string TableName => "Ингредиенты";

        public IngredientModel(BasicDoubleCRUD<IngredientEntity> context) : base(context) { }

        public override void Add<TResult>(IngredientEntity info)
        {
            TResult result = new TResult
            {
                DishId = info.DishId,
                DishName = info.DishName,
                ProductId = info.ProductId,
                ProductName = info.ProductName,
                Gross = info.Gross,
                Net = info.Net,
                UnitId = info.UnitId,
                UnitName = info.UnitName
            };
            TableContext.Create(result);
        }

        public override void Update<TResult>(DataRow row, IngredientEntity info)
        {
            TResult result = new TResult
            {
                DishId = info.DishId,
                DishName = info.DishName,
                ProductId = info.ProductId,
                ProductName = info.ProductName,
                Gross = info.Gross,
                Net = info.Net,
                UnitId = info.UnitId,
                UnitName = info.UnitName
            };
            (result.DishId, result.ProductId) = GetPK(row);
            TableContext.Update(result);
        }

        public override int CompareEntities(IngredientEntity first, IngredientEntity second)
        {
            if (first == null)
                return -1;
            if (second == null)
                return 1;
            int compared = first.DishId.CompareTo(second.DishId);
            if (compared != 0) return compared;
            compared = first.ProductId.CompareTo(second.ProductId);
            if (compared != 0) return compared;
            compared = first.Gross.CompareTo(second.Gross);
            if (compared != 0) return compared;
            compared = first.Net.CompareTo(second.Net);
            if (compared != 0) return compared;
            return first.UnitId.CompareTo(second.UnitId);
        }

        public override bool ContainsString(IngredientEntity entity, string sample)
        {
            return (
                entity.DishId.ToString().Contains(sample) ||
                entity.ProductId.ToString().Contains(sample) ||
                entity.Gross.ToString().Contains(sample) ||
                entity.Net.ToString().Contains(sample) ||
                entity.UnitName.ToString().Contains(sample)
            );
        }
    }
}
