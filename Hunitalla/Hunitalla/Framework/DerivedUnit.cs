namespace Hunitalla.Framework;

/// <summary>
/// Represents a unit which is defined as a transformation of another reference unit
/// </summary>
/// <typeparam name="Q"></typeparam>
public class DerivedUnit<Q>(string Name, string Symbol, Unit<Q> Reference, Func<double, double> ToReference, Func<double, double> FromReference) : Unit<Q> where Q : IQuantity<Q>
{
    public Unit<Q> Base => ReferenceUnit.Base;

    public double FromBase(double amount) => FromReference(Reference.FromBase(amount));
    public double ToBase(double amount) => Reference.ToBase(ToReference(amount));

    /// <summary>
    /// Creates a Derived Unit where the transformation from <paramref name="referenceUnit"/> to this unit is defined as a ratio of <paramref name="numReferenceUnits"/> to <paramref name="numDerivedUnits"/>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="symbol"></param>
    /// <param name="referenceUnit"></param>
    /// <param name="numReferenceUnits"></param>
    /// <param name="numDerivedUnits"></param>
    /// <param name="stringify"></param>
    /// <returns></returns>
    public static DerivedUnitOf<Q> ByRatio(string name,
                                           string symbol,
                                           Q reference,
                                           int numDerivedUnits = 1)
    {
        if (reference.Amount is 0 || numDerivedUnits is 0)
        {
            throw new DivideByZeroException($"Impossible bi-directional conversion with given ratio '{reference}':'{numDerivedUnits}{symbol}'");
        }

        return new DerivedUnitOf<Q>(name,
                                    symbol,
                                    reference.Unit,
                                    FromReference: amount => amount * numDerivedUnits / reference.Amount,
                                    ToReference: amount => amount / numDerivedUnits * reference.Amount);
    }
}
