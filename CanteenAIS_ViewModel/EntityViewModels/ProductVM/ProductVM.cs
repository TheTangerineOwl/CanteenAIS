using Entitites = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.Product
{
    public class ProductVM : BasicVM<Entitites.Product>
    {
        public ProductVM(SimpleModel<Entitites.Product> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
