using System.ComponentModel;

namespace CanteenAIS_DB.Database.Entities
{
    public abstract class MeasureUnitEntity : SimpleEntity
    {
        [DisplayName("Имя")]
        [ColumnOrder(1)]
        public virtual string Name { get; set; }

        public MeasureUnitEntity() { }

        public MeasureUnitEntity(MeasureUnitEntity info)
        {
            Id = info.Id;
            Name = info.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class MeasureUnit : MeasureUnitEntity
    {
        public MeasureUnit() { }

        public MeasureUnit(MeasureUnitEntity info) : base(info) { }
    }
}
