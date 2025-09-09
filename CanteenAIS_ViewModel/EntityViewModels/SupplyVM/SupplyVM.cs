using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using CanteenAIS_ViewModel.EntityViewModels.SupplyProduct;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Supply
{
    public class SupplyVM : BasicVM<Entities.SupplyEntity, Entities.Supply>
    {
        public SupplyVM(SimpleModel<Entities.SupplyEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
