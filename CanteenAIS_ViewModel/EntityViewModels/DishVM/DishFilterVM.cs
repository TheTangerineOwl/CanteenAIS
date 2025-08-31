using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Dish
{
    public class DishFilterVM : BasicFilterVM<Entities.DishEntity, Entities.Dish>
    {
        public DishFilterVM(TableModel<Entities.DishEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            IdText = "0";
            NameText = string.Empty;
            GroupId = 0;
            PriceText = "0";
            ServingText = "0";
            UnitId = 0;
            RecipeText = string.Empty;
            PictureText = string.Empty;
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
                    value = "1";
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
                    value = "";
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
                    value = "";
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
                    value = "";
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
                    value = "";
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
                    value = "";
                Set(ref pictureText, value);
            }
        }

        private bool idCheck;
        public bool IdCheck
        {
            get => idCheck;
            set => Set(ref idCheck, value);
        }

        private bool nameCheck;
        public bool NameCheck
        {
            get => nameCheck;
            set => Set(ref nameCheck, value);
        }

        private bool groupCheck;
        public bool GroupCheck
        {
            get => groupCheck;
            set => Set(ref groupCheck, value);
        }

        private bool priceCheck;
        public bool PriceCheck
        {
            get => priceCheck;
            set => Set(ref priceCheck, value);
        }

        private bool servingCheck;
        public bool ServingCheck
        {
            get => servingCheck;
            set => Set(ref servingCheck, value);
        }

        private bool unitCheck;
        public bool UnitCheck
        {
            get => unitCheck;
            set => Set(ref unitCheck, value);
        }

        private bool recipeCheck;
        public bool RecipeCheck
        {
            get => recipeCheck;
            set => Set(ref recipeCheck, value);
        }

        private bool pictureCheck;
        public bool PictureCheck
        {
            get => pictureCheck;
            set => Set(ref pictureCheck, value);
        }

        public override void ParseFields()
        {
            if (idCheck)
            {
                if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
                Fields.Id = id;
            }
            if (nameCheck)
            {
                if (!ValueChecker.CheckValueString(NameText, out string name, 100))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(NameText));
                Fields.Name = name;
            }
            if (groupCheck)
            {
                if (!ValueChecker.CheckValueUint(GroupId.ToString(), out uint group))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(GroupId));
                Fields.GroupId = group;
            }
            if (priceCheck)
            {
                if (!ValueChecker.CheckValueDecimal(PriceText, out decimal price))
                    throw new ArgumentException("Некорректное значение параметра!", nameof(PriceText));
                Fields.Price = price;
            }
            if (servingCheck)
            {
                if (!ValueChecker.CheckValueDouble(ServingText, out double serving))
                    throw new ArgumentException("Некорректное значение параметра!", nameof(ServingText));
                Fields.Serving = serving;
            }
            if (unitCheck)
            {
                if (!ValueChecker.CheckValueUint(UnitId.ToString(), out uint unit))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(UnitId));
                Fields.UnitId = unit;
            }
            if (recipeCheck)
            {
                if (!ValueChecker.CheckValueString(RecipeText, out string recipe, 2500))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(RecipeText));
                Fields.Recipe = recipe;
            }
            if (pictureCheck)
            {
                if (!ValueChecker.CheckValueString(PictureText, out string picture, 200))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(PictureText));
                Fields.Picture = picture;
            }
        }
    }
}
