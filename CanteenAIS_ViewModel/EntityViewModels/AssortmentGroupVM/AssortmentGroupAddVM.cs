using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.AssortmentGroup
{
    public class AssortmentGroupAddVM : BasicAddVM<Entities.AssortmentGroupEntity, Entities.AssortmentGroup>
    {
        public AssortmentGroupAddVM(TableModel<Entities.AssortmentGroupEntity> tableModel) : base(tableModel)
        {
            _name = string.Empty;
            Clear();
        }

        protected override void Clear()
        {
            Name = string.Empty;
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value == _name)
                    return;
                if (_name == null)
                    _name = value;
                if (!ValueChecker.CheckValueString(value, out value, 50, false))
                    value = "";
                Set(ref _name, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueString(Name, out string name, 50, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
            Fields.Name = name;
        }
    }
}
