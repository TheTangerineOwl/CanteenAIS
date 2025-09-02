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
            branch = Branches.Where(item => item.Id == Fields.Id).FirstOrDefault();
            dateTimeFill = Fields.DateTime;
            idText = Fields.Id.ToString();
            //Clear();
        }

        protected override void Clear()
        {
            IdText = Fields.Id.ToString();
            //BranchId = (int)Fields.BranchId;
            Branch = Branches?.Where(item => item.Id == Fields.Id).FirstOrDefault();
            DateTimeFill = Fields.DateTime;
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

        //private int branchId;
        //public int BranchId
        //{
        //    get => branchId;
        //    set
        //    {
        //        Set(ref branchId, value);
        //    }
        //}

        private Entities.BranchEntity branch;
        public Entities.BranchEntity Branch
        {
            get => branch;
            set => Set(ref branch, value);
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
            int BranchId = (int?)Branch?.Id ?? -1;
            if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
            if (!ValueChecker.CheckValueUint(BranchId.ToString(), out uint branchId))
                throw new ArgumentException("Параметр не может быть 0!", nameof(BranchId));
            if (!ValueChecker.CheckValueDateTime(DateTimeFill.ToString(), out DateTime time))
                throw new ArgumentException("Некорректное время!", nameof(DateTimeFill));
            Fields.Id = id;
            Fields.BranchId = branchId;
            Fields.DateTime = DateTimeFill;
        }
    }
}
