using Hunitalla.Framework;

namespace Hunitalla.Quantities
{
    public class LinearDollarDensity : QuantityOf<LinearDollarDensity>
    {
        public static readonly BaseUnitOf<LinearDollarDensity> DollarPerMile = new BaseUnitOf<LinearDollarDensity>("Dollar per Mile", "$/mile");
        public static readonly UnitOf<LinearDollarDensity> DollarPerFoot = DerivedUnitOf<LinearDollarDensity>.ByRatio("Dollar per Foot", "$/ft", DollarPerMile, 1, 5280);

        public override double Amount { get; }
        public override UnitOf<LinearDollarDensity> Unit { get; }

        public static UsDollars operator *(LinearDollarDensity a, Distance b) => new UsDollars(b.In(Distance.Mile) * a.In(DollarPerMile), UsDollars.Dollar);
        public static UsDollars operator *(Distance a, LinearDollarDensity b) => b * a;

        public LinearDollarDensity(double amount, UnitOf<LinearDollarDensity> unit)
        {
            Amount = amount;
            Unit = unit;
        }
    }
}
