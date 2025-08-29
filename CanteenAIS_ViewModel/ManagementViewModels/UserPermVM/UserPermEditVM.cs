using Entities = CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_ViewModel.BasicViewModels;
using CanteenAIS_Models;
using System.Data;

namespace CanteenAIS_ViewModel.ManagementViewModels.UserPerm
{
    public class UserPermEditVM : BasicEditVM<Entities.UserPermEntity, Entities.UserPerm>
    {
        public UserPermEditVM(DataRow row, TableModel<Entities.UserPermEntity> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            Fields.UserId = 0;
            Fields.UserLogin = string.Empty;
            Fields.ElementId = 0;
            Fields.ElementName = string.Empty;
            Fields.CanRead = false;
            Fields.CanWrite = false;
            Fields.CanEdit = true;
            Fields.CanDelete = false;
        }
    }
}
