using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.AppAuth.Entities;

namespace CanteenAIS_ViewModel.ManagementViewModels.UserPerm
{
    public class UserPermFilterVM : BasicFilterVM<Entities.UserPermEntity, Entities.UserPerm>
    {
        public UserPermFilterVM(TableModel<Entities.UserPermEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            UserId = 0;
            ElementId = 0;
            CanWrite = false;
            CanRead = false;
            CanDelete = false;
            CanEdit = false;
        }

        private int userId;
        public int UserId
        {
            get => userId;
            set => Set(ref userId, value);
        }

        private int elementId;
        public int ElementId
        {
            get => elementId;
            set => Set(ref elementId, value);
        }

        private bool canRead;
        public bool CanRead
        {
            get => canRead;
            set => Set(ref canRead, value);
        }

        private bool canWrite;
        public bool CanWrite
        {
            get => canWrite;
            set => Set(ref canWrite, value);
        }

        private bool canEdit;
        public bool CanEdit
        {
            get => canEdit;
            set => Set(ref canEdit, value);
        }

        private bool canDelete;
        public bool CanDelete
        {
            get => canDelete;
            set => Set(ref canDelete, value);
        }

        private bool userCheck;
        public bool UserCheck
        {
            get => userCheck;
            set => Set(ref userCheck, value);
        }

        private bool elementCheck;
        public bool ElementCheck
        {
            get => elementCheck;
            set => Set(ref elementCheck, value);
        }

        private bool readCheck;
        public bool ReadCheck
        {
            get => readCheck;
            set => Set(ref readCheck, value);
        }

        private bool writeCheck;
        public bool WriteCheck
        {
            get => writeCheck;
            set => Set(ref writeCheck, value);
        }

        private bool editCheck;
        public bool EditCheck
        {
            get => editCheck;
            set => Set(ref editCheck, value);
        }

        private bool deleteCheck;
        public bool DeleteCheck
        {
            get => deleteCheck;
            set => Set(ref deleteCheck, value);
        }

        public override void ParseFields()
        {
            if (userCheck)
            {
                if (!ValueChecker.CheckValueUint(UserId.ToString(), out uint userid, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(UserId));
                Fields.UserId = userid;
            }
            if (elementCheck)
            {
                if (!ValueChecker.CheckValueUint(ElementId.ToString(), out uint elementid, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(ElementId));
                Fields.ElementId = elementid;
            }
            if (editCheck)
                Fields.CanEdit = CanEdit;
            if (readCheck)
                Fields.CanRead = CanRead;
            if (writeCheck)
                Fields.CanWrite = CanWrite;
            if (deleteCheck)
                Fields.CanDelete = CanDelete;
        }
    }
}
