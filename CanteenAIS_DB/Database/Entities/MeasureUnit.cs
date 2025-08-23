using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public interface IMeasureUnit : ISimpleEntity
    {
        [DisplayName("Имя")]
        string Name { get; set; }
    }

    public class MeasureUnitInfo : SimpleInfo
    {
        public string name;
    }

    public class MeasureUnit : IMeasureUnit
    {
        private readonly MeasureUnitInfo _info;
        public uint Id { get => _info.id; set => _info.id = value; }
        public string Name { get => _info.name; set => _info.name = value; }

        public MeasureUnit(MeasureUnitInfo info)
        {
            _info = info;
        }
    }
}
