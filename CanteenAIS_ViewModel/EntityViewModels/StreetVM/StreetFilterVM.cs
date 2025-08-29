using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Street
{
    public class StreetFilterVM : BasicFilterVM<Entities.StreetEntity, Entities.Street>
    {
        public StreetFilterVM(TableModel<Entities.StreetEntity> tableModel)
            : base(tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.CityId = 0;
            Fields.CityName = string.Empty;
            Fields.Name = string.Empty;
        }
    }
}
