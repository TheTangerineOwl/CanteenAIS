using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.AssortmentGroup
{
    public class AssortmentGroupAddVM : BasicAddVM<Entities.AssortmentGroup>
    {
        protected AssortmentGroupAddVM(TableModel<Entities.AssortmentGroup> tableModel) : base(tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
        }
    }
}
