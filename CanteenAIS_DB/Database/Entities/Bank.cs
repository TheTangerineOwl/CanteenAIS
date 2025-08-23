using System;
using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IBank : ISimpleEntity
    {
        [DisplayName("Имя")]
        string Name { get; set; }
    }

    public class BankInfo : SimpleInfo
    {
        public string name;
    }

    public class Bank : IBank
    {
        private readonly BankInfo _info;
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

        public Bank(BankInfo info)
        {
            _info = info;
        }
    }
}
