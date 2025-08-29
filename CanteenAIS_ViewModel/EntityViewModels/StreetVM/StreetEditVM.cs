using CanteenAIS_Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System.Data;
using Entities = CanteenAIS_DB.Database.Entities;

namespace CanteenAIS_ViewModel.EntityViewModels.Street
{
    public class StreetEditVM : BasicEditVM<Entities.StreetEntity, Entities.Street>
    {
        public StreetEditVM(DataRow row, TableModel<Entities.StreetEntity> tableModel)
            : base(row, tableModel) { }

        protected override void Clear()
        {
            Fields.Id = 0;
            Fields.CityId = 0;
            Fields.CityName = string.Empty;
            Fields.Name = string.Empty;
        }
    }
}
