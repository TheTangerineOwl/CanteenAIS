using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.BranchOrder
{
    public class BranchOrderEditVM : BasicEditVM<Entities.BranchOrderEntity, Entities.BranchOrder>
    {
        public BranchOrderEditVM(DataRow row, TableModel<Entities.BranchOrderEntity> tableModel)
            : base(row, tableModel)
        {
            _branches = MainServices.GetInstance().Branches.FetchValues<Entities.Branch>().ToList<Entities.BranchEntity>();
            _branch = Branches.Where(item => item.Id == Fields.BranchId).FirstOrDefault();
            _dateTimePick = Fields.DateTime;
            _id = (int)Fields.Id;
        }

        protected override void Clear()
        {
            Id = (int)Fields.Id;
            Branch = Branches?.Where(item => item.Id == Fields.BranchId).FirstOrDefault();
            DateTimePick = Fields.DateTime;
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

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (!ValueChecker.CheckValueUint(value.ToString(), out uint _))
                    value = (int)Fields.Id;
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
                    value = Fields.DateTime;
                Set(ref _dateTimePick, value);
            }
        }

        public override void ParseFields()
        {
            int BranchId = (int?)Branch?.Id ?? -1;
            if (!ValueChecker.CheckValueUint(Id.ToString(), out uint id))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Id));
            if (!ValueChecker.CheckValueUint(BranchId.ToString(), out uint branchId))
                throw new ArgumentException("Параметр не может быть 0!", nameof(BranchId));
            if (!ValueChecker.CheckValueDateTime(DateTimePick.ToString(), out DateTime time))
                throw new ArgumentException("Некорректное время!", nameof(DateTimePick));
            Fields.Id = id;
            Fields.BranchId = branchId;
            Fields.DateTime = time;
        }
    }
}
