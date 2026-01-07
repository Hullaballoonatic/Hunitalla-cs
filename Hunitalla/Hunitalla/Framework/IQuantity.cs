namespace Hunitalla.Framework;

/// <summary>
/// Represents a measurement of <typeparamref name="Q"/> in a given unit
/// </summary>
/// <typeparam name="Q"></typeparam>
public interface IQuantity<Q> : IEquatable<Q>,
                                IEquatable<IQuantity<Q>>,
                                IEqualityComparer<Q>,
                                IEqualityComparer<IQuantity<Q>>,
                                IComparable<Q>,
                                IComparable<IQuantity<Q>>
    where Q : IQuantity<Q>
{
    /// <summary>
    /// Numerical measurement
    /// </summary>
    double Amount { get; }

    /// <summary>
    /// Unit of measurement
    /// </summary>
    Unit<Q> Unit { get; }

    /// <summary>
    /// The measurement after being converted to the base unit for this Quantity
    /// </summary>
    double BaseAmount => Unit.ConvertToBase(Amount);

    /// <summary>
    /// Returns amount after conversion into given <paramref name="unit"/>
    /// </summary>
    /// <param name="unit"></param>
    /// <example><c>2.Hours().In(Duration.Minute) == 120</c></example>
    double In(Unit<Q> unit) => unit.ConvertFromBase(BaseAmount);

    Q Of(double amount) => IQuantity.Of(amount, Unit);

    Q Shift(IQuantity<Q> other)
    {
        var amount = Unit().ConvertFromBase(BaseAmount + other.BaseAmount);

        return Quantify(amount);
    }

    Q Scale(double scalar) => Quantify(Amount * scalar);

    void VerifyComparable(IQuantity<Q> other)
    {
        if (Unit.Base != other.Unit.Base)
            throw new ArgumentException($"Cannot compare quantities of '{GetType().Name}' to '{other.GetType().Name}' because they have different BaseUnits.");
    }

    int GetHashCode() => 31 * Unit().GetHashCode() + Amount().GetHashCode();
    int GetHashCode(Q obj) => obj.GetHashCode();
    int GetHashCode(IQuantity<Q> obj) => obj.GetHashCode();

    string ToString() => Unit().Stringify(Amount());

    bool Equals(object obj) => obj is IQuantity<Q> q && Equals(q);
    bool Equals(IQuantity<Q> x, IQuantity<Q> y) => x.Equals(y);
    bool Equals(Q x, Q y) => x.Equals(y);

    bool Equals(Q other)
    {
        const double EQUALITY_PRECISION = 1e-10;

        return Math.Abs(BaseAmount - other.BaseAmount) < EQUALITY_PRECISION;
    }

    bool Equals(IQuantity<Q> other)
    {
        VerifyComparable(other);

        return Equals((Q)other);
    }

    int CompareTo(Q other)
    {
        if (Equals(other))
        {
            return 0;
        }

        return BaseAmount.CompareTo(other.BaseAmount);
    }

    int CompareTo(IQuantity<Q> other)
    {
        VerifyComparable(other);

        return CompareTo((Q)other);
    }

    static Q operator -(IQuantity<Q> a) => a.Scale(-1);
    static Q operator +(IQuantity<Q> a, IQuantity<Q> b) => a.Shift(b);
    static Q operator -(IQuantity<Q> a, IQuantity<Q> b) => a.Shift(-b);
    static Q operator *(IQuantity<Q> a, double scalar) => a.Scale(scalar);
    static Q operator *(IQuantity<Q> a, int scalar) => a.Scale(scalar);
    static Q operator *(double a, IQuantity<Q> quantity) => quantity.Scale(a);
    static Q operator *(int a, IQuantity<Q> quantity) => quantity.Scale(a);
    static Q operator /(IQuantity<Q> a, double divisor) => a.Scale(1 / divisor);
    static Q operator /(IQuantity<Q> a, int divisor) => a.Scale(1.0 / divisor);

    static bool operator ==(IQuantity<Q> a, IQuantity<Q> b) => a.Equals(b);
    static bool operator !=(IQuantity<Q> a, IQuantity<Q> b) => !(a == b);

    static bool operator <(IQuantity<Q> a, IQuantity<Q> b) => a.CompareTo(b) < 0;
    static bool operator <=(IQuantity<Q> a, IQuantity<Q> b) => a.CompareTo(b) <= 0;
    static bool operator >(IQuantity<Q> a, IQuantity<Q> b) => !(a <= b);
    static bool operator >=(IQuantity<Q> a, IQuantity<Q> b) => !(a < b);

    static bool operator <(IQuantity<Q> a, Q b) => a.CompareTo(b) < 0;
    static bool operator <=(IQuantity<Q> a, Q b) => a.CompareTo(b) <= 0;
    static bool operator >(IQuantity<Q> a, Q b) => !(a <= b);
    static bool operator >=(IQuantity<Q> a, Q b) => !(a < b);

    static abstract Q Of(double amount, Unit<Q> unit);
}