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
            _branches = MainServices.GetInstance().Branches.FetchValues<Entities.Branch>().ToList<BranchEntity>();
            branch = _branches.FirstOrDefault();
            dateTimeFill = DateTime.Now;
            //Clear();
        }

        protected override void Clear()
        {
            //IdText = "0";
            //BranchId = -1;
            Branch = Branches?.FirstOrDefault();
            DateTimeFill = DateTime.Now;
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

        //private string idText;
        //public string IdText
        //{
        //    get => idText;
        //    set
        //    {
        //        if (idText == null)
        //            idText = value;
        //        if (!ValueChecker.CheckValueUint(value, out uint _, true))
        //            value = "1";
        //        Set(ref idText, value);
        //    }
        //}

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
            //if (!ValueChecker.CheckValueUint(IdText, out uint id, true))
            //    throw new ArgumentException("Параметр не может быть 0!", nameof(IdText));
            if (!ValueChecker.CheckValueUint(BranchId.ToString(), out uint branchId))
                throw new ArgumentException("Параметр не может быть 0!", nameof(BranchId));
            if (!ValueChecker.CheckValueDateTime(DateTimeFill.ToString(), out DateTime time))
                throw new ArgumentException("Некорректное время!", nameof(DateTimeFill));
            //Fields.Id = id;
            Fields.BranchId = branchId;
            Fields.DateTime = DateTimeFill;
        }
    }
}
