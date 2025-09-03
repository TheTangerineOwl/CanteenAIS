using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.City
{
    public class CityFilterVM : BasicFilterVM<Entities.CityEntity, Entities.City>
    {
        public CityFilterVM(TableModel<Entities.CityEntity> tableModel)
            : base(tableModel)
        {
            _id = 1;
            _idCheck = false;
            _name = string.Empty;
            _nameCheck = false;
        }

        protected override void Clear()
        {
            Id = 1;
            IdCheck = false;
            Name = string.Empty;
            NameCheck = false;
        }

        private uint _id;
        public uint Id
        {
            get => _id;
            set
            {
                if (!ValueChecker.CheckValueUint(value.ToString(), out uint _, true))
                    value = 0;
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
                if (!ValueChecker.CheckValueString(value, out value, 25, true))
                    value = "";
                Set(ref _name, value);
            }
        }

        private bool _idCheck = false;
        public bool IdCheck
        {
            get => _idCheck;
            set => Set(ref _idCheck, value);
        }

        private bool _nameCheck = false;
        public bool NameCheck
        {
            get => _nameCheck;
            set => Set(ref _nameCheck, value);
        }

        public override void ParseFields()
        {
            if (IdCheck)
            {
                if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
                Fields.Id = id;
            }
            if (NameCheck)
            {
                if (!ValueChecker.CheckValueString(Name, out string name, 25, true))
                    throw new ArgumentNullException("Строка не может быть пустой!", nameof(Name));
                Fields.Name = name;
            }
        }

        public override void Filter()
        {
            ParseFields();
            Model.FetchAndFilter<Entities.City>((item) =>
                !(IdCheck && item.Id != Fields.Id) &&
                !(NameCheck && !string.Equals(item.Name, Fields.Name))
            );
        }
    }
}
