using System.ComponentModel;
using System;
using System.Diagnostics.Eventing.Reader;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IAssortmentGroup : ISimpleEntity
    {
        [DisplayName("Имя")]
        string Name { get; set; }
    }

    public class AssortmentGroupInfo : SimpleInfo
    {
        public string name;
    }

    public class AssortmentGroup : IAssortmentGroup
    {
        private readonly AssortmentGroupInfo _info;
        public uint Id
        {
            get => _info.id;
            set => _info.id = value;
        }
        public string Name
        {
            get => _info.name;
            set => _info.name = value;
        }

        public AssortmentGroup(AssortmentGroupInfo info)
        {
            _info = info;
        }
    }
}
