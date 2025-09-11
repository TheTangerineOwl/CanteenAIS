using Entities = CanteenAIS_DB.Database.Entities;
using CanteenAIS_Models;
using CanteenAIS_Models.Models;
using CanteenAIS_ViewModel.BasicViewModels;
using System;
using System.Data;
using System.Windows.Input;

namespace CanteenAIS_ViewModel.EntityViewModels.AssortmentGroup
{
    public class AssortmentGroupVM : BasicVM<Entities.AssortmentGroupEntity, Entities.AssortmentGroup>
    {

        public AssortmentGroupVM(SimpleModel<Entities.AssortmentGroupEntity> tableModel, uint menuElementId)
            : base(tableModel, menuElementId)
        {
        }
    }
}
