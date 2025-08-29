using Entities = CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_ViewModel.BasicViewModels;
using CanteenAIS_Models;

namespace CanteenAIS_ViewModel.ManagementViewModels.UserPerm
{
    public class UserPermFilterVM : BasicFilterVM<Entities.UserPermEntity, Entities.UserPerm>
    {
        public UserPermFilterVM(TableModel<Entities.UserPermEntity> tableModel)
            : base(tableModel) { }

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
