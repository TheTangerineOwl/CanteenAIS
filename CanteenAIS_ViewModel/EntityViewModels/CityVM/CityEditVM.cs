using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.City
{
    public class CityEditVM : BasicEditVM<Entities.CityEntity, Entities.City>
    {
        public CityEditVM(DataRow row, TableModel<Entities.CityEntity> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.Name = string.Empty;
        }
    }
}
