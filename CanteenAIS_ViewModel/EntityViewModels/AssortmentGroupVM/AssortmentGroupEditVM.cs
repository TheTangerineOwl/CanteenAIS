using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.AssortmentGroup
{
    public class AssortmentGroupEditVM : BasicEditVM<Entities.AssortmentGroupEntity, Entities.AssortmentGroup>
    {
        public AssortmentGroupEditVM(DataRow row, TableModel<Entities.AssortmentGroupEntity> tableModel)
            : base(row, tableModel)
        {
            _id = Fields.Id;
            _name = Fields.Name;
            Clear();
        }

        protected override void Clear()
        {
            Id = Fields.Id;
            Name = Fields.Name;
        }

        private uint _id;
        public uint Id
        {
            get => _id;
            set
            {
                if (value == _id)
                    return;
                if (!ValueChecker.CheckValueUint(value.ToString(), out uint _, false))
                    value = Fields.Id;
                Set(ref _id, value);
            }
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
                    value = Fields.Name;
                Set(ref _name, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
            if (!ValueChecker.CheckValueString(Name, out string name, 50, false))
                throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
            Fields.Id = id;
            Fields.Name = name;
        }
    }
}
