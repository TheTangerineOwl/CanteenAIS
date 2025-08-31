using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.BranchOrder
{
    public class BranchOrderAddVM : BasicAddVM<Entities.BranchOrderEntity, Entities.BranchOrder>
    {
        public BranchOrderAddVM(TableModel<Entities.BranchOrderEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            IdText = "0";
            BranchIdText = "0";
            DateTimeFill = DateTime.Now;
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

        private DateTime dateTimeFill;
        public DateTime DateTimeFill
        {
            get => dateTimeFill;
            set
            {
                if (!ValueChecker.CheckValueDateTime(value.ToString(), out DateTime _))
                    value = DateTime.Now;
                Set(ref dateTimeFill, value);
            }
        }

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
            if (!ValueChecker.CheckValueUint(BranchIdText, out uint branchId))
                throw new ArgumentException("Параметр не может быть 0!", nameof(BranchIdText));
            if (!ValueChecker.CheckValueDateTime(DateTimeFill.ToString(), out DateTime time))
                throw new ArgumentException("Некорректное время!", nameof(DateTimeFill));
            Fields.Id = id;
            Fields.BranchId = branchId;
            Fields.DateTime = DateTimeFill;
        }
    }
}
