using CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.BranchOrder
{
    public class BranchOrderAddVM : BasicAddVM<Entities.BranchOrderEntity, Entities.BranchOrder>
    {
        public BranchOrderAddVM(TableModel<Entities.BranchOrderEntity> tableModel)
            : base(tableModel)
        {
            _id = 1;
            _branches = MainServices.GetInstance().Branches.FetchValues<Entities.Branch>().ToList<BranchEntity>();
            _branch = _branches.FirstOrDefault();
            _dateTimePick = DateTime.Now;
        }

        protected override void Clear()
        {
            Id = 1;
            Branch = Branches?.FirstOrDefault();
            DateTimePick = DateTime.Now;
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

        private IList<Entities.BranchEntity> _branches;
        public IList<Entities.BranchEntity> Branches
        {
            get => _branches;
            set
            {
                Set(ref _branches, value);
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

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id, false))
                throw new ArgumentNullException("Некорректное значение!", nameof(Id));
            Fields.Id = id;
            int BranchId = (int?)Branch?.Id ?? -1;
            if (!ValueChecker.CheckValueUint(BranchId.ToString(), out uint branchId))
                throw new ArgumentException("Параметр не может быть 0!", nameof(BranchId));
            if (!ValueChecker.CheckValueDateTime(DateTimePick.ToString(), out DateTime time))
                throw new ArgumentException("Некорректное время!", nameof(DateTimePick));
            Fields.BranchId = branchId;
            Fields.DateTime = time;
        }
    }
}
