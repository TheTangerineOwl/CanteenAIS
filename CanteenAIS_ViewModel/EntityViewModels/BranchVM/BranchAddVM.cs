using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Branch
{
    public class BranchAddVM : BasicAddVM<Entities.BranchEntity, Entities.Branch>
    {
        public BranchAddVM(TableModel<Entities.BranchEntity> tableModel)
            : base(tableModel)
        {
            _id = 1;
            _name = string.Empty;
        }

        protected override void Clear()
        {
            Id = 1;
            Name = string.Empty;
        }

        private uint _id;
        public uint Id
        {
            get => _id;
            set
            {
                if (!ValueChecker.CheckValueUint(value.ToString(), out _))
                    value = 1;
                Set(ref _id, value);
            }
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
            if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, false))
                throw new ArgumentNullException("Некорректное значение!", nameof(Id));
            Fields.Id = id;
            if (!ValueChecker.CheckValueString(Name, out string name, 100, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
            Fields.Name = name;
        }
    }
}
