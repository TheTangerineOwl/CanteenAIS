using System;

namespace CanteenAIS_DB
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnOrderAttribute : Attribute
    {
        public int Order { get; private set; }

        public ColumnOrderAttribute(int order)
        {
            Order = order;
        }
    }
}
