using Hunitalla.Quantities;

namespace Hunitalla
{
    public static class QuantityInstantiation
    {
        public static Distance Miles(this int amount) => new Distance(amount, Distance.Mile);
        public static Distance Miles(this double amount) => new Distance(amount, Distance.Mile);
        public static Distance Yards(this int amount) => new Distance(amount, Distance.Yard);
        public static Distance Yards(this double amount) => new Distance(amount, Distance.Yard);
        public static Distance Feet(this int amount) => new Distance(amount, Distance.Foot);
        public static Distance Feet(this double amount) => new Distance(amount, Distance.Foot);
        public static Distance Inches(this int amount) => new Distance(amount, Distance.Inch);
        public static Distance Inches(this double amount) => new Distance(amount, Distance.Inch);

        public static UsDollars Dollars(this int amount) => new UsDollars(amount, UsDollars.Dollar);
        public static UsDollars Dollars(this double amount) => new UsDollars(amount, UsDollars.Dollar);
        public static UsDollars Cents(this double amount) => new UsDollars(amount, UsDollars.Cent);
        public static UsDollars Cents(this int amount) => new UsDollars(amount, UsDollars.Cent);

        public static LinearDollarDensity DollarsPerMile(this int amount) => new LinearDollarDensity(amount, LinearDollarDensity.DollarPerMile);
        public static LinearDollarDensity DollarsPerMile(this double amount) => new LinearDollarDensity(amount, LinearDollarDensity.DollarPerMile);
        public static LinearDollarDensity Dpm(this int amount) => amount.DollarsPerMile();
        public static LinearDollarDensity Dpm(this double amount) => amount.DollarsPerMile();

        public static Duration Seconds(this int amount) => new Duration(amount, Duration.Second);
        public static Duration Seconds(this double amount) => new Duration(amount, Duration.Second);
        public static Duration Minutes(this int amount) => new Duration(amount, Duration.Minute);
        public static Duration Minutes(this double amount) => new Duration(amount, Duration.Minute);
        public static Duration Hours(this int amount) => new Duration(amount, Duration.Hour);
        public static Duration Hours(this double amount) => new Duration(amount, Duration.Hour);
        public static Duration Days(this int amount) => new Duration(amount, Duration.Day);
        public static Duration Days(this double amount) => new Duration(amount, Duration.Day);
        public static Duration Weeks(this int amount) => new Duration(amount, Duration.Week);
        public static Duration Weeks(this double amount) => new Duration(amount, Duration.Week);
        public static Duration Milliseconds(this int amount) => new Duration(amount, Duration.Millisecond);
        public static Duration Milliseconds(this double amount) => new Duration(amount, Duration.Millisecond);

        public static Velocity MilesPerHour(this int amount) => new Velocity(amount, Velocity.MilesPerHour);
        public static Velocity MilesPerHour(this double amount) => new Velocity(amount, Velocity.MilesPerHour);
        public static Velocity Mph(this int amount) => amount.MilesPerHour();
        public static Velocity Mph(this double amount) => amount.MilesPerHour();
        public static Velocity MilesPerMinute(this int amount) => new Velocity(amount, Velocity.MilesPerMinute);
        public static Velocity MilesPerMinute(this double amount) => new Velocity(amount, Velocity.MilesPerMinute);
        public static Velocity MilesPerSecond(this int amount) => new Velocity(amount, Velocity.MilesPerSecond);
        public static Velocity MilesPerSecond(this double amount) => new Velocity(amount, Velocity.MilesPerSecond);
        public static Velocity MilesPerDay(this int amount) => new Velocity(amount, Velocity.MilesPerDay);
        public static Velocity MilesPerDay(this double amount) => new Velocity(amount, Velocity.MilesPerDay);
    }
}
