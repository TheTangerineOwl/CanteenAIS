using Entities = CanteenAIS_DB.AppAuth.Entities;
using CanteenAIS_ViewModel.BasicViewModels;
using CanteenAIS_Models;

namespace CanteenAIS_ViewModel.ManagementViewModels.UserPerm
{
    public class UserPermVM : BasicVM<Entities.UserPermEntity, Entities.UserPerm>
    {
        public UserPermVM(TableModel<Entities.UserPermEntity> tableModel, uint menuElementId) : base(tableModel, menuElementId)
        {
        }
    }
}
