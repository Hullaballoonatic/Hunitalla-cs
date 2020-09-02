using FluentAssertions;
using Hunitalla.Quantities;
using Xunit;

namespace Hunitalla.Tests
{
    public class QuantityInstantiationTests
    {
        private const int i = 1;
        private const double d = 1;

        [Fact]
        public void Miles_ReturnsExpected()
        {
            var expected = new Distance(i, Distance.Mile);

            var actual = i.Miles();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleMiles_ReturnsExpected()
        {
            var expected = new Distance(d, Distance.Mile);

            var actual = d.Miles();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Yards_ReturnsExpected()
        {
            var expected = new Distance(i, Distance.Yard);

            var actual = i.Yards();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleYards_ReturnsExpected()
        {
            var expected = new Distance(d, Distance.Yard);

            var actual = d.Yards();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Feet_ReturnsExpected()
        {
            var expected = new Distance(i, Distance.Foot);

            var actual = i.Feet();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleFeet_ReturnsExpected()
        {
            var expected = new Distance(d, Distance.Foot);

            var actual = d.Feet();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Inches_ReturnsExpected()
        {
            var expected = new Distance(i, Distance.Inch);

            var actual = i.Inches();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleInches_ReturnsExpected()
        {
            var expected = new Distance(d, Distance.Inch);

            var actual = d.Inches();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Dollars_ReturnsExpected()
        {
            var expected = new UsDollars(i, UsDollars.Dollar);

            var actual = i.Dollars();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleDollars_ReturnsExpected()
        {
            var expected = new UsDollars(d, UsDollars.Dollar);

            var actual = d.Dollars();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Cents_ReturnsExpected()
        {
            var expected = new UsDollars(i, UsDollars.Cent);

            var actual = i.Cents();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleCents_ReturnsExpected()
        {
            var expected = new UsDollars(d, UsDollars.Cent);

            var actual = d.Cents();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Dpm_ReturnsExpected()
        {
            var expected = new LinearDollarDensity(i, LinearDollarDensity.DollarPerMile);

            var actual = i.Dpm();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleDpm_ReturnsExpected()
        {
            var expected = new LinearDollarDensity(d, LinearDollarDensity.DollarPerMile);

            var actual = d.Dpm();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Seconds_ReturnsExpected()
        {
            var expected = new Duration(i, Duration.Second);

            var actual = i.Seconds();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleSeconds_ReturnsExpected()
        {
            var expected = new Duration(d, Duration.Second);

            var actual = d.Seconds();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Minutes_ReturnsExpected()
        {
            var expected = new Duration(i, Duration.Minute);

            var actual = i.Minutes();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleMinutes_ReturnsExpected()
        {
            var expected = new Duration(d, Duration.Minute);

            var actual = d.Minutes();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Hours_ReturnsExpected()
        {
            var expected = new Duration(i, Duration.Hour);

            var actual = i.Hours();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleHours_ReturnsExpected()
        {
            var expected = new Duration(d, Duration.Hour);

            var actual = d.Hours();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Days_ReturnsExpected()
        {
            var expected = new Duration(i, Duration.Day);

            var actual = i.Days();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleDays_ReturnsExpected()
        {
            var expected = new Duration(d, Duration.Day);

            var actual = d.Days();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Weeks_ReturnsExpected()
        {
            var expected = new Duration(i, Duration.Week);

            var actual = i.Weeks();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleWeeks_ReturnsExpected()
        {
            var expected = new Duration(d, Duration.Week);

            var actual = d.Weeks();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Milliseconds_ReturnsExpected()
        {
            var expected = new Duration(i, Duration.Millisecond);

            var actual = i.Milliseconds();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleMilliseconds_ReturnsExpected()
        {
            var expected = new Duration(d, Duration.Millisecond);

            var actual = d.Milliseconds();

            actual.Should().Be(expected);
        }

        [Fact]
        public void Mph_ReturnsExpected()
        {
            var expected = new Velocity(d, Velocity.MilesPerHour);

            var actual = d.Mph();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleMph_ReturnsExpected()
        {
            var expected = new Velocity(d, Velocity.MilesPerHour);

            var actual = d.Mph();

            actual.Should().Be(expected);
        }

        [Fact]
        public void MilesPerMinute_ReturnsExpected()
        {
            var expected = new Velocity(i, Velocity.MilesPerMinute);

            var actual = i.MilesPerMinute();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleMilesPerMinute_ReturnsExpected()
        {
            var expected = new Velocity(d, Velocity.MilesPerMinute);

            var actual = d.MilesPerMinute();

            actual.Should().Be(expected);
        }

        [Fact]
        public void MilesPerSecond_ReturnsExpected()
        {
            var expected = new Velocity(i, Velocity.MilesPerSecond);

            var actual = i.MilesPerSecond();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleMilesPerSecond_ReturnsExpected()
        {
            var expected = new Velocity(d, Velocity.MilesPerSecond);

            var actual = d.MilesPerSecond();

            actual.Should().Be(expected);
        }

        [Fact]
        public void MilesPerDay_ReturnsExpected()
        {
            var expected = new Velocity(i, Velocity.MilesPerDay);

            var actual = i.MilesPerDay();

            actual.Should().Be(expected);
        }

        [Fact]
        public void DoubleMilesPerDay_ReturnsExpected()
        {
            var expected = new Velocity(d, Velocity.MilesPerDay);

            var actual = d.MilesPerDay();

            actual.Should().Be(expected);
        }
    }
}