using System;

namespace Hunitalla.Framework

/// <summary>
/// Unit of Measurement in quantity <typeparamref name="Q"/>
/// </summary>
/// <typeparam name="Q"></typeparam>
public interface IUnit<Q> : IComparable<IUnit<Q>>, IEquatable<IUnit<Q>> where Q : IQuantity<Q>
{
    string Name();
    string Symbol();
    BaseUnitOf<Q> BaseUnit();

    /// <summary>
    /// Generates a string representation of a quantity
    /// </summary>
    /// <param name="amount"></param>
    string Stringify(double amount) => $"{amount}{Symbol()}";

    /// <summary>
    /// Converts <paramref name="amount"/> measured in this unit into an amount in this unit's base unit.
    /// </summary>
    /// <param name="amount"></param>
    double ConvertToBase(double amount);

    /// <summary>
    /// Converts <paramref name="amount"/> measured in this unit's base unit into an amount in this unit.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    double ConvertFromBase(double amount);

    bool Equals(UnitOf<Q> other) => CompareTo(other) is 0;
    int CompareTo(UnitOf<Q> other) => ConvertToBase(1).CompareTo(other.ConvertToBase(1));
}
