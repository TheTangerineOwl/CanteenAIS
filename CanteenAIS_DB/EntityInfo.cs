using System.ComponentModel;

namespace CanteenAIS_DB
{
    public abstract class Entity
    {
        public Entity() { }

        public static void CreateFrom<TResult, TInfo>(out TResult res, TInfo info)
            where TResult : TInfo, new()
            where TInfo : Entity
        {
            res = info.MemberwiseClone() as TResult;
        }

        public abstract void Copy<TResult, TInfo>(ref TResult res, TInfo info)
            where TResult : TInfo
            where TInfo : Entity;
    }
    public abstract class SimpleEntity : Entity
    {
        [DisplayName("Id")]
        [ColumnOrder(0)]
        public virtual uint Id { get; set; }

        public SimpleEntity() : base() { }

        public override void Copy<TResult, TInfo>(ref TResult res, TInfo info)
        {
            if (res is SimpleEntity _res &&
                info is SimpleEntity _info)
                _res.Id = _info.Id;
        }
    }
    public abstract class DoubleEntity : Entity
    {
        [ColumnOrder(0)]
        public virtual uint FirstId { get; set; }
        [ColumnOrder(1)]
        public virtual uint SecondId { get; set; }

        public DoubleEntity() : base() { }

        public override void Copy<TResult, TInfo>(ref TResult res, TInfo info)
        {
            if (res is DoubleEntity _res &&
                info is DoubleEntity _info)
            {
                if (_info.FirstId != default) _res.FirstId = _info.FirstId;
                if (_info.SecondId != default) _res.SecondId = _info.SecondId;
            }
        }
    }
}
