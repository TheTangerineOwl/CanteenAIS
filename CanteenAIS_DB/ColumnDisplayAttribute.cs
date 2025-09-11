using System;
using System.ComponentModel;

namespace CanteenAIS_DB
{
    /// <summary>
    /// Атрибут для свойств классов сущностей, позволяющий задавать
    /// порядок столбцов в таблице, их имя и видимость.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnDisplayAttribute : DisplayNameAttribute
    {
        /// <summary>
        /// Видим ли столбец.
        /// </summary>
        public bool Visible { get; private set; }

        /// <summary>
        /// Порядок столбца в таблице.
        /// </summary>
        public int Order { get; private set; }

        /// <summary>
        /// Создает атрибут для свойств классов сущностей, позволяющий задавать
        /// порядок столбцов в таблице, их имя и видимость.
        /// </summary>
        /// <param name="name">Отображаемое имя столбца.</param>
        /// <param name="visible">Видим ли столбец.</param>
        /// <param name="order">Порядок столбца в таблице.</param>
        public ColumnDisplayAttribute(string name = null, bool visible = false, int order = -1) 
            : base(name)
        {
            Visible = visible;
            Order = order;
        }
    }
}
