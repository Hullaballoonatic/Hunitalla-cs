using Hunitalla.Framework;

namespace Hunitalla.Quantities
{
    public class Distance : QuantityOf<Distance>
    {
        public static readonly BaseUnitOf<Distance> Mile = new BaseUnitOf<Distance>("Mile", "mi");
        public static readonly UnitOf<Distance> Foot = DerivedUnitOf<Distance>.ByRatio("Foot", "ft", Mile, 1, 5280);
        public static readonly UnitOf<Distance> Yard = DerivedUnitOf<Distance>.ByRatio("Yard", "yd", Foot, 3);
        public static readonly UnitOf<Distance> Inch = DerivedUnitOf<Distance>.ByRatio("Inch", "in", Foot, 1, 12);

        public override double Amount { get; }
        public override UnitOf<Distance> Unit { get; }

        public static Velocity operator /(Distance distance, Duration duration) => new Velocity(distance.In(Mile) / duration.In(Duration.Hour), Velocity.MilesPerHour);

        public Distance(double amount, UnitOf<Distance> unit)
        {
            Amount = amount;
            Unit = unit;
        }
    }
}
