using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using Entities = CanteenAIS_DB.AppAuth.Entities;

namespace CanteenAIS_ViewModel.ManagementViewModels.UserPerm
{
    public class UserPermAddVM : BasicAddVM<Entities.UserPermEntity, Entities.UserPerm>
    {
        public UserPermAddVM(TableModel<Entities.UserPermEntity> tableModel)
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

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(UserId.ToString(), out uint userid, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(UserId));
            if (!ValueChecker.CheckValueUint(ElementId.ToString(), out uint elementid, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(ElementId));
            Fields.UserId = userid;
            Fields.ElementId = elementid;
            Fields.CanEdit = CanEdit;
            Fields.CanRead = CanRead;
            Fields.CanWrite = CanWrite;
            Fields.CanDelete = CanDelete;
        }
    }
}
