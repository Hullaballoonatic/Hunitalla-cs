using Hunitalla.Framework;
using System;

namespace Hunitalla.Quantities
{
    public class Duration : QuantityOf<Duration>
    {
        public static readonly BaseUnitOf<Duration> Second = new BaseUnitOf<Duration>("Second", "s");
        public static readonly UnitOf<Duration> Minute = DerivedUnitOf<Duration>.ByRatio("Minute", "min", Second, 60);
        public static readonly UnitOf<Duration> Hour = DerivedUnitOf<Duration>.ByRatio("Hour", "hr", Minute, 60);
        public static readonly UnitOf<Duration> Day = DerivedUnitOf<Duration>.ByRatio("Day", "day", Hour, 24);
        public static readonly UnitOf<Duration> Week = DerivedUnitOf<Duration>.ByRatio("Week", "wk", Day, 7);
        public static readonly UnitOf<Duration> Millisecond = DerivedUnitOf<Duration>.ByRatio("Millisecond", "ms", Second, 1, 1000);

        public static implicit operator TimeSpan(Duration duration) => TimeSpan.FromMilliseconds(duration.In(Millisecond));
        public static implicit operator Duration(TimeSpan timespan) => new Duration(timespan.TotalSeconds, Second);

        public override double Amount { get; }
        public override UnitOf<Duration> Unit { get; }

        public Duration(double amount, UnitOf<Duration> unit)
        {
            Amount = amount;
            Unit = unit;
        }
    }
}
