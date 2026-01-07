namespace Hunitalla.Framework;

/// <summary>
/// Represents the Base Unit of Measurement for a Quantity <typeparamref name="Q"/> from which all other Units are derived.
/// </summary>
/// <typeparam name="Q"></typeparam>
public class BaseUnit<Q>(string Name, string Symbol) : Unit<Q> where Q : QuantityOf<Q>
{
    public BaseUnitOf<Q> BaseUnit => this;

    public override double ConvertFromBase(double amount) => amount;
    public override double ConvertToBase(double amount) => amount;
}
