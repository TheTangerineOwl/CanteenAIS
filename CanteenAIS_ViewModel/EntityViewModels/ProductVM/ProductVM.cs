using Entities = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Product
{
    public class ProductVM : BasicVM<Entities.ProductEntity, Entities.Product>
    {
        public ProductVM(SimpleModel<Entities.ProductEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
