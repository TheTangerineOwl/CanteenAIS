using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Dish
{
    public class DishEditVM : BasicEditVM<Entities.DishEntity, Entities.Dish>
    {
        public DishEditVM(DataRow row, TableModel<Entities.DishEntity> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            IdText = Fields.Id.ToString();
            NameText = Fields.Name;
            GroupId = Fields.GroupId;
            PriceText = Fields.Price.ToString();
            ServingText = Fields.Serving.ToString();
            UnitId = Fields.UnitId;
            RecipeText = Fields.Recipe;
            PictureText = Fields.Picture;
        }

        private string idText;
        public string IdText
        {
            get => idText;
            set
            {
                if (idText == null)
                    idText = value;
                if (!ValueChecker.CheckValueUint(value, out uint _, true))
                    value = Fields.Id.ToString();
                Set(ref idText, value);
            }
        }

        private string nameText;
        public string NameText
        {
            get => nameText;
            set
            {
                if (nameText == null)
                    nameText = value;
                if (!ValueChecker.CheckValueString(value, out value, 100, false))
                    value = Fields.Name;
                Set(ref nameText, value);
            }
        }

        private uint groupId;
        public uint GroupId
        {
            get => groupId;
            set => Set(ref groupId, value);
        }

        private string priceText;
        public string PriceText
        {
            get => priceText;
            set
            {
                if (priceText == null)
                    priceText = value;
                if (!ValueChecker.CheckValueDecimal(value, out decimal _))
                    value = Fields.Price.ToString();
                Set(ref priceText, value);
            }
        }

        private string servingText;
        public string ServingText
        {
            get => servingText;
            set
            {
                if (servingText == null)
                    servingText = value;
                if (!ValueChecker.CheckValueDouble(value, out double _))
                    value = Fields.Serving.ToString();
                Set(ref servingText, value);
            }
        }

        private uint unitId;
        public uint UnitId
        {
            get => unitId;
            set => Set(ref unitId, value);
        }

        private string recipeText;
        public string RecipeText
        {
            get => recipeText;
            set
            {
                if (recipeText == null)
                    recipeText = value;
                if (!ValueChecker.CheckValueString(value, out value, 2500, true))
                    value = Fields.Recipe;
                Set(ref recipeText, value);
            }
        }

        private string pictureText;
        public string PictureText
        {
            get => pictureText;
            set
            {
                if (pictureText == null)
                    pictureText = value;
                if (!ValueChecker.CheckValueString(value, out value, 200, true))
                    value = Fields.Picture;
                Set(ref pictureText, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
            if (!ValueChecker.CheckValueString(NameText, out string name, 100))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(NameText));
            if (!ValueChecker.CheckValueUint(GroupId.ToString(), out uint group))
                throw new ArgumentException("Параметр не может быть 0!", nameof(GroupId));
            if (!ValueChecker.CheckValueDecimal(PriceText, out decimal price))
                throw new ArgumentException("Некорректное значение параметра!", nameof(PriceText));
            if (!ValueChecker.CheckValueDouble(ServingText, out double serving))
                throw new ArgumentException("Некорректное значение параметра!", nameof(ServingText));
            if (!ValueChecker.CheckValueUint(UnitId.ToString(), out uint unit))
                throw new ArgumentException("Параметр не может быть 0!", nameof(UnitId));
            if (!ValueChecker.CheckValueString(RecipeText, out string recipe, 2500))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(RecipeText));
            if (!ValueChecker.CheckValueString(PictureText, out string picture, 200))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(PictureText));
            Fields.Id = id;
            Fields.Name = name;
            Fields.GroupId = group;
            Fields.Price = price;
            Fields.Serving = serving;
            Fields.UnitId = unit;
            Fields.Recipe = recipe;
            Fields.Picture = picture;
        }
    }
}
