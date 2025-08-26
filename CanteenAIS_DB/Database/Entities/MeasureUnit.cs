using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class MeasureUnitEntity : SimpleEntity
    {
        [DisplayName("Имя")]
        public virtual string Name { get; set; }

        public MeasureUnitEntity() { }

        public MeasureUnitEntity(MeasureUnitEntity info)
        {
            Id = info.Id;
            Name = info.Name;
        }
    }

    public class MeasureUnit : MeasureUnitEntity
    {
        public MeasureUnit() { }

        public MeasureUnit(MeasureUnitEntity info) : base(info) { }
    }
}
