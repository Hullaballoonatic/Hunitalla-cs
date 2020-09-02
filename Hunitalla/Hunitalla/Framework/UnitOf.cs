using System;

namespace Hunitalla.Framework
{
    /// <summary>
    /// Unit of Measurement in quantity <typeparamref name="Q"/>
    /// </summary>
    /// <typeparam name="Q"></typeparam>
    public abstract class UnitOf<Q> : IComparable<UnitOf<Q>>, IEquatable<UnitOf<Q>> where Q : QuantityOf<Q>
    {
        public abstract string Name { get; }
        public abstract string Symbol { get; }
        public abstract BaseUnitOf<Q> BaseUnit { get; }

        /// <summary>
        /// Generates a string representation of a quantity
        /// </summary>
        /// <param name="amount"></param>
        public virtual string Stringify(double amount) => $"{amount}{Symbol}";

        /// <summary>
        /// Converts <paramref name="amount"/> measured in this unit into an amount in this unit's base unit.
        /// </summary>
        /// <param name="amount"></param>
        public abstract double ConvertToBase(double amount);

        /// <summary>
        /// Converts <paramref name="amount"/> measured in this unit's base unit into an amount in this unit.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public abstract double ConvertFromBase(double amount);

        public bool Equals(UnitOf<Q> other) => CompareTo(other) is 0;
        public int CompareTo(UnitOf<Q> other) => ConvertToBase(1).CompareTo(other.ConvertToBase(1));
    }
}
