using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.BranchOrder
{
    public class BranchOrderFilterVM : BasicFilterVM<Entities.BranchOrderEntity, Entities.BranchOrder>
    {
        public BranchOrderFilterVM(TableModel<Entities.BranchOrderEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            IdText = "0";
            BranchIdText = "0";
            DateTimeBefore = DateTime.MinValue;
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

        private string branchIdText;
        public string BranchIdText
        {
            get => branchIdText;
            set
            {
                if (branchIdText == null)
                    branchIdText = value;
                if (!ValueChecker.CheckValueUint(value, out uint _))
                    value = "0";
                Set(ref branchIdText, value);
            }
        }

        private DateTime dateTimeBefore;
        public DateTime DateTimeBefore
        {
            get => dateTimeBefore;
            set
            {
                if (!ValueChecker.CheckValueDateTime(value.ToString(), out DateTime _))
                    value = DateTime.MinValue;
                Set(ref dateTimeBefore, value);
            }
        }

        private bool idCheck;
        public bool IdCheck
        {
            get => idCheck;
            set => Set(ref idCheck, value);
        }

        private bool branchIdCheck;
        public bool BranchIdCheck
        {
            get => branchIdCheck;
            set => Set(ref branchIdCheck, value);
        }

        private bool timeBeforeCheck;
        public bool TimeBeforeCheck
        {
            get => timeBeforeCheck;
            set => Set(ref timeBeforeCheck, value);
        }

        public override void ParseFields()
        {
            if (idCheck)
            {
                if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
                Fields.Id = id;
            }
            if (branchIdCheck)
            {
                if (!ValueChecker.CheckValueUint(BranchIdText, out uint branchId))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(BranchIdText));
                Fields.BranchId = branchId;
            }
            if (timeBeforeCheck)
            {
                if (!ValueChecker.CheckValueDateTime(DateTimeBefore.ToString(), out DateTime time))
                    throw new ArgumentException("Некорректное время!", nameof(DateTimeBefore));
                Fields.DateTime = DateTimeBefore;
            }
        }
    }
}
