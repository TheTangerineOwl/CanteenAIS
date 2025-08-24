using CanteenAIS_DB;
using CanteenAIS_DB.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenAIS_Models.Models
{
    public class IngredientModel : DoubleModel<IIngredient, IngredientInfo>
    {
        public override string TableName => "Ингредиенты";

        public IngredientModel(BasicDoubleCRUD<IIngredient> context) : base(context) { }

        public override void Add(IngredientInfo info)
        {
            TableContext.Create(new Ingredient(info));
        }

        public override void Update(DataRow row, IngredientInfo info)
        {
            (info.firstId, info.secondId) = GetPK(row);
            TableContext.Update(new Ingredient(info));
        }

        public override int CompareEntities(IIngredient first, IIngredient second)
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

        public override bool ContainsString(IIngredient entity, string sample)
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
