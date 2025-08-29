using Entities = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.City
{
    public class CityVM : BasicVM<Entities.CityEntity, Entities.City>
    {
        public CityVM(SimpleModel<Entities.CityEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
