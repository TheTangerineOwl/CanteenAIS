using System.ComponentModel;

namespace CanteenAIS_DB
{
    public interface IEntity { }
    public interface ISimpleEntity : IEntity
    {
        [DisplayName("Id")]
        uint Id { get; set; }
    }

    public interface IDoubleEntity : IEntity
    {
        uint FirstId { get; set; }
        uint SecondId { get; set; }
    }

    public abstract class Info { }
    public abstract class SimpleInfo : Info
    {
        public uint id;
    }
    public abstract class DoubleInfo : Info
    {
        public uint firstId;
        public uint secondId;
    }
}
