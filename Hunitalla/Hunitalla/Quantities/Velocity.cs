using Hunitalla.Framework;

namespace Hunitalla.Quantities
{
    public class Velocity : QuantityOf<Velocity>
    {
        public static readonly BaseUnitOf<Velocity> MilesPerHour = new BaseUnitOf<Velocity>("Miles per Hour", "mph");
        public static readonly UnitOf<Velocity> MilesPerMinute = DerivedUnitOf<Velocity>.ByRatio("Miles per Minute", $"{Distance.Mile.Symbol}/{Duration.Minute.Symbol}", MilesPerHour, 1, 60);
        public static readonly UnitOf<Velocity> MilesPerSecond = DerivedUnitOf<Velocity>.ByRatio("Miles per Second", $"{Distance.Mile.Symbol}/{Duration.Second.Symbol}", MilesPerMinute, 1, 60);
        public static readonly UnitOf<Velocity> MilesPerDay = DerivedUnitOf<Velocity>.ByRatio("Miles per Day", $"{Distance.Mile.Symbol}/{Duration.Day.Symbol}", MilesPerHour, 24);

        public override double Amount { get; }
        public override UnitOf<Velocity> Unit { get; }

        public static Distance operator *(Velocity a, Duration b) => new Distance(a.In(MilesPerHour) * b.In(Duration.Hour), Distance.Mile);
        public static Distance operator *(Duration a, Velocity b) => b * a;

        public Velocity(double amount, UnitOf<Velocity> unit)
        {
            Amount = amount;
            Unit = unit;
        }
    }
}
