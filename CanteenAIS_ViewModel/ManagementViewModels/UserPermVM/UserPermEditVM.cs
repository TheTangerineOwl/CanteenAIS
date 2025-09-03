using CanteenAIS_Models;
using CanteenAIS_Models.Management.Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Entities = CanteenAIS_DB.AppAuth.Entities;

namespace CanteenAIS_ViewModel.ManagementViewModels.UserPerm
{
    public class UserPermEditVM : BasicEditVM<Entities.UserPermEntity, Entities.UserPerm>
    {
        public UserPermEditVM(DataRow row, TableModel<Entities.UserPermEntity> tableModel)
            : base(row, tableModel)
        {
            _users = MainServices.GetInstance().Users.FetchValues<Entities.User>().ToList();
            _user = Users.Where(item => item.Id == Fields.UserId).FirstOrDefault();
            _elements = MenuElementModel.FetchValues().ToList();
            _element = Elements.Where(item => item.Id == Fields.ElementId).FirstOrDefault();
            _canRead = Fields.CanRead;
            _canWrite = Fields.CanWrite;
            _canEdit = Fields.CanEdit;
            _canDelete = Fields.CanDelete;
        }

        protected override void Clear()
        {
            User = Users.Where(item => item.Id == Fields.UserId).FirstOrDefault();
            Element = Elements.Where(item => item.Id == Fields.ElementId).FirstOrDefault();
            CanRead = Fields.CanRead;
            CanWrite = Fields.CanWrite;
            CanEdit = Fields.CanEdit;
            CanDelete = Fields.CanDelete;
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

        public override void ParseFields()
        {
            if (!ValueChecker.CheckValueUint(User.Id.ToString(), out uint userid, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(User.Id));
            Fields.UserId = userid;
            if (!ValueChecker.CheckValueUint(Element.Id.ToString(), out uint elementid, true))
                throw new ArgumentException("Параметр не может быть 0!", nameof(Element.Id));
            Fields.ElementId = elementid;
            Fields.CanEdit = CanEdit;
            Fields.CanRead = CanRead;
            Fields.CanWrite = CanWrite;
            Fields.CanDelete = CanDelete;
        }
    }
}
