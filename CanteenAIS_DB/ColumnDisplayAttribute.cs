using System;
using System.ComponentModel;

namespace CanteenAIS_DB
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnDisplayAttribute : DisplayNameAttribute
    {
        public bool Visible { get; private set; }

        //public string Name { get; private set; }

        public int Order { get; private set; }

        public ColumnDisplayAttribute(string name = null, bool visible = true, int order = -1) : base(name)
        {
            Visible = visible;
            Order = order;
        }
    }
}
