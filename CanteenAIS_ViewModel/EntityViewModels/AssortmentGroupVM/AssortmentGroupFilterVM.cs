using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.AssortmentGroup
{
    public class AssortmentGroupFilterVM : BasicFilterVM<Entities.AssortmentGroupEntity, Entities.AssortmentGroup>
    {
        public AssortmentGroupFilterVM(TableModel<Entities.AssortmentGroupEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
        }
    }
}
