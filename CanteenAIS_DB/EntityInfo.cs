namespace CanteenAIS_DB
{
    /// <summary>
    /// Базовый класс для всех сущностей, представляющих собой таблицы в БД.
    /// </summary>
    public abstract class Entity
    {
        public Entity() { }
    }

    /// <summary>
    /// Базовый класс для всех сущностей с одинарным PK.
    /// </summary>
    public abstract class SimpleEntity : Entity
    {
        /// <summary>
        /// Первичный ключ сущности.
        /// </summary>
        [ColumnDisplay("Id", true, 0)]
        public virtual uint Id { get; set; }

        public SimpleEntity() : base() { }
    }

    /// <summary>
    /// Базовый класс для всех сущностей с двойным PK (таблицы для связей).
    /// </summary>
    public abstract class DoubleEntity : Entity
    {
        /// <summary>
        /// Первое ключевое значение.
        /// </summary>
        [ColumnDisplay("FirstId", true, 0)]
        public virtual uint FirstId { get; set; }
        /// <summary>
        /// Второе ключевое значение.
        /// </summary>
        [ColumnDisplay("SecondId", true, 1)]
        public virtual uint SecondId { get; set; }

        public DoubleEntity() : base() { }
    }
}
