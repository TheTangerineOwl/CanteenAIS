using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.BranchOrder
{
    public class BranchOrderFilterVM : BasicFilterVM<Entities.BranchOrderEntity, Entities.BranchOrder>
    {
        public BranchOrderFilterVM(TableModel<Entities.BranchOrderEntity> tableModel)
            : base(tableModel)
        {
            _branches = MainServices.GetInstance().Branches.FetchValues<Entities.Branch>().ToList<Entities.BranchEntity>();
            _branch = Branches.FirstOrDefault();
            _branchCheck = false;
            _dateTimePick = DateTime.Now;
            _dateTimeCheck = false;
            _id = 1;
            _idCheck = false;
        }

        protected override void Clear()
        {
            Id = 1;
            IdCheck = false;
            Branch = Branches?.FirstOrDefault();
            BranchCheck = false;
            DateTimePick = DateTime.Now;
            DateTimeCheck = false;
        }

        private IList<Entities.BranchEntity> _branches;
        public IList<Entities.BranchEntity> Branches
        {
            get => _branches;
            set
            {
                Set(ref _branches, value);
            }
        }

        private uint _id;
        public uint Id
        {
            get => _id;
            set
            {
                if (!ValueChecker.CheckValueUint(value.ToString(), out uint _, true))
                    value = 1;
                Set(ref _id, value);
            }
        }

        private Entities.BranchEntity _branch;
        public Entities.BranchEntity Branch
        {
            get => _branch;
            set => Set(ref _branch, value);
        }

        private DateTime _dateTimePick;
        public DateTime DateTimePick
        {
            get => _dateTimePick;
            set
            {
                if (!ValueChecker.CheckValueDateTime(value.ToString(), out DateTime _))
                    value = DateTime.Now;
                Set(ref _dateTimePick, value);
            }
        }

        private bool _idCheck;
        public bool IdCheck
        {
            get => _idCheck;
            set => Set(ref _idCheck, value);
        }

        private bool _branchCheck;
        public bool BranchCheck
        {
            get => _branchCheck;
            set => Set(ref _branchCheck, value);
        }

        private bool _dateTimeCheck;
        public bool DateTimeCheck
        {
            get => _dateTimeCheck;
            set => Set(ref _dateTimeCheck, value);
        }

        public override void ParseFields()
        {
            if (_idCheck)
            {
                if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
                Fields.Id = id;
            }
            if (_branchCheck)
            {
                int BranchId = (int?)Branch?.Id ?? -1;
                if (!ValueChecker.CheckValueUint(BranchId.ToString(), out uint branchId))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(BranchId));
                Fields.BranchId = branchId;
            }
            if (_dateTimeCheck)
            {
                if (!ValueChecker.CheckValueDateTime(DateTimePick.ToString(), out DateTime time))
                    throw new ArgumentException("Некорректное время!", nameof(DateTimePick));
                Fields.DateTime = time;
            }
        }

        public override void Filter()
        {
            ParseFields();
            Model.FetchAndFilter<Entities.BranchOrder>((item) =>
                !(IdCheck && item.Id != Fields.Id) &&
                !(BranchCheck && item.BranchId != Fields.BranchId) &&
                !(DateTimeCheck && item.DateTime != Fields.DateTime)
            );
        }
    }
}
