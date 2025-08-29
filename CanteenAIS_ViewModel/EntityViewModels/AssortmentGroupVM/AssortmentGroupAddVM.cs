using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.AssortmentGroup
{
    public class AssortmentGroupAddVM : BasicAddVM<Entities.AssortmentGroupEntity, Entities.AssortmentGroup>
    {
        public AssortmentGroupAddVM(TableModel<Entities.AssortmentGroupEntity> tableModel) : base(tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
        }

        private string idText;
        public string IdText
        {
            get => idText;
            set
            {
                if (ValueChecker.CheckValueUint(idText) == 0)
                    value = "1";
                if (idText == null)
                    idText = value;
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
                Set(ref nameText, value);
            }
        }

        public void ParseFields()
        {
            uint id = ValueChecker.CheckValueUint(IdText);
            if (id == 0)
                throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
            if (ValueChecker.CheckValueString(NameText) == null)
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(NameText));
            Fields.Id = id;
            Fields.Name = NameText;
        }

        public override void Add()
        {
            ParseFields();
            base.Add();
        }

        public override void Cancel()
        {
            IdText = "0";
            NameText = "";
            base.Cancel();
        }
    }
}
