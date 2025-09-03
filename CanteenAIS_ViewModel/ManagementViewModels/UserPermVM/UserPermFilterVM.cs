using CanteenAIS_Models;
using CanteenAIS_Models.Management.Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities = CanteenAIS_DB.AppAuth.Entities;

namespace CanteenAIS_ViewModel.ManagementViewModels.UserPerm
{
    public class UserPermFilterVM : BasicFilterVM<Entities.UserPermEntity, Entities.UserPerm>
    {
        public UserPermFilterVM(TableModel<Entities.UserPermEntity> tableModel)
            : base(tableModel)
        {
            _users = MainServices.GetInstance().Users.FetchValues<Entities.User>().ToList();
            _user = Users.FirstOrDefault();
            _userCheck = false;
            _elements = MenuElementModel.FetchValues().ToList();
            _element = Elements.FirstOrDefault();
            _elementCheck = false;
            _canRead = false;
            _readCheck = false;
            _canWrite = false;
            _writeCheck = false;
            _canEdit = false;
            _editCheck = false;
            _canDelete = false;
            _deleteCheck = false;
        }

        protected override void Clear()
        {
            User = Users.FirstOrDefault();
            UserCheck = false;
            Element = Elements.FirstOrDefault();
            ElementCheck = false;
            CanWrite = false;
            WriteCheck = false;
            CanRead = false;
            ReadCheck = false;
            CanDelete = false;
            DeleteCheck = false;
            CanEdit = false;
            EditCheck = false;
        }

        private IList<Entities.User> _users;
        public IList<Entities.User> Users
        {
            get => _users;
            set => Set(ref _users, value);
        }

        private IList<Entities.MenuElement> _elements;
        public IList<Entities.MenuElement> Elements
        {
            get => _elements;
            set => Set(ref _elements, value);
        }

        private Entities.User _user;
        public Entities.User User
        {
            get => _user;
            set => Set(ref _user, value);
        }

        private Entities.MenuElement _element;
        public Entities.MenuElement Element
        {
            get => _element;
            set => Set(ref _element, value);
        }

        private bool _canRead;
        public bool CanRead
        {
            get => _canRead;
            set => Set(ref _canRead, value);
        }

        private bool _canWrite;
        public bool CanWrite
        {
            get => _canWrite;
            set => Set(ref _canWrite, value);
        }

        private bool _canEdit;
        public bool CanEdit
        {
            get => _canEdit;
            set => Set(ref _canEdit, value);
        }

        private bool _canDelete;
        public bool CanDelete
        {
            get => _canDelete;
            set => Set(ref _canDelete, value);
        }

        private bool _userCheck;
        public bool UserCheck
        {
            get => _userCheck;
            set => Set(ref _userCheck, value);
        }

        private bool _elementCheck;
        public bool ElementCheck
        {
            get => _elementCheck;
            set => Set(ref _elementCheck, value);
        }

        private bool _readCheck;
        public bool ReadCheck
        {
            get => _readCheck;
            set => Set(ref _readCheck, value);
        }

        private bool _writeCheck;
        public bool WriteCheck
        {
            get => _writeCheck;
            set => Set(ref _writeCheck, value);
        }

        private bool _editCheck;
        public bool EditCheck
        {
            get => _editCheck;
            set => Set(ref _editCheck, value);
        }

        private bool _deleteCheck;
        public bool DeleteCheck
        {
            get => _deleteCheck;
            set => Set(ref _deleteCheck, value);
        }

        public override void ParseFields()
        {
            if (_userCheck)
            {
                if (!ValueChecker.CheckValueUint(User.Id.ToString(), out uint userid, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(User.Id));
                Fields.UserId = userid;
            }
            if (_elementCheck)
            {
                if (!ValueChecker.CheckValueUint(Element.Id.ToString(), out uint elementid, true))
                    throw new ArgumentException("Параметр не может быть 0!", nameof(Element.Id));
                Fields.ElementId = elementid;
            }
            if (_editCheck)
                Fields.CanEdit = CanEdit;
            if (_readCheck)
                Fields.CanRead = CanRead;
            if (_writeCheck)
                Fields.CanWrite = CanWrite;
            if (_deleteCheck)
                Fields.CanDelete = CanDelete;
        }

        public override void Filter()
        {
            ParseFields();
            Model.FetchAndFilter<Entities.UserPerm>((item) =>
                !(UserCheck && item.UserId != Fields.UserId) &&
                !(ElementCheck && item.ElementId != Fields.ElementId) &&
                !(ReadCheck && item.CanRead != Fields.CanRead) &&
                !(WriteCheck && item.CanWrite != Fields.CanWrite) &&
                !(EditCheck && item.CanEdit != Fields.CanEdit) &&
                !(DeleteCheck && item.CanDelete != Fields.CanDelete)
            );
        }
    }
}
