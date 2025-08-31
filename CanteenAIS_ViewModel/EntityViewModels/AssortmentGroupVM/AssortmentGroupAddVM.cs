using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.AssortmentGroup
{
    public class AssortmentGroupAddVM : BasicAddVM<Entities.AssortmentGroupEntity, Entities.AssortmentGroup>
    {
        public AssortmentGroupAddVM(TableModel<Entities.AssortmentGroupEntity> tableModel) : base(tableModel)
        {
            Clear();
        }

        protected override void Clear()
        {
            //IdText = "1";
            NameText = string.Empty;
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
                if (!ValueChecker.CheckValueString(value, out value, 50, false))
                    value = "";
                Set(ref nameText, value);
            }
        }

        public override void ParseFields()
        {
            //if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                //throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
            if (!ValueChecker.CheckValueString(NameText, out string name, 50, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(NameText));
            //Fields.Id = id;
            Fields.Name = name;
        }
    }
}
