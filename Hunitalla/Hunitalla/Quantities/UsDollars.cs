using Hunitalla.Framework;

namespace Hunitalla.Quantities
{
    public class UsDollars : QuantityOf<UsDollars>
    {
        public static readonly BaseUnitOf<UsDollars> Dollar = new BaseUnitOf<UsDollars>("Dollar", "$", it => it.ToString("c"));
        public static readonly UnitOf<UsDollars> Cent = DerivedUnitOf<UsDollars>.ByRatio("Cent", "¢", Dollar, 1, 100);

        public override double Amount { get; }
        public override UnitOf<UsDollars> Unit { get; }

        public static LinearDollarDensity operator /(UsDollars a, Distance b) => new LinearDollarDensity(a.In(Dollar) / b.In(Distance.Mile), LinearDollarDensity.DollarPerMile);

        public UsDollars(double amount, UnitOf<UsDollars> unit)
        {
            Amount = amount;
            Unit = unit;
        }
    }
}
