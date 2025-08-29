using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Product
{
    public class ProductAddVM : BasicAddVM<Entities.ProductEntity, Entities.Product>
    {
        public ProductAddVM(TableModel<Entities.ProductEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
            Fields.UnitId = 0;
            Fields.UnitName = string.Empty;
            Fields.Markup = 0;
            Fields.Stock = 0;
            Fields.SupplierId = 0;
            Fields.SupplierName = string.Empty;
        }
    }
}
