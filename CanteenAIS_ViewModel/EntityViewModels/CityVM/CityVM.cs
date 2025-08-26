using Entitites = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;

namespace CanteenAIS_ViewModel.EntityViewModels.City
{
    public class CityVM : BasicVM<Entitites.City>
    {
        public CityVM(SimpleModel<Entitites.City> tableModel, uint menuElementId)
            : base(tableModel, menuElementId) { }
    }
}
