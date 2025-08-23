using System;
using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IBranch : ISimpleEntity
    {
        [DisplayName("Имя")]
        string Name { get; set; }
    }

    public class BranchInfo : SimpleInfo
    {
        public string name;
    }

    public class Branch : IBranch
    {
        private readonly BranchInfo _info;
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

        public Branch(BranchInfo info)
        {
            _info = info;
        }
    }
}
