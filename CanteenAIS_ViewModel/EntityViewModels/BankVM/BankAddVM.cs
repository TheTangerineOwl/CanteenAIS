using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Bank
{
    public class BankAddVM : BasicAddVM<Entities.BankEntity, Entities.Bank>
    {
        public BankAddVM(TableModel<Entities.BankEntity> tableModel)
            : base(tableModel)
        {
            _name = string.Empty;
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
                if (_name == null)
                    _name = value;
                if (!ValueChecker.CheckValueString(value, out value, 100, false))
                    value = "";
                Set(ref _name, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueString(Name, out string name, 100, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
            Fields.Name = name;
        }
    }
}
