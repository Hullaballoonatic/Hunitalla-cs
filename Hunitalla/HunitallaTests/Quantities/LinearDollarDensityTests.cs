using Xunit;
using FluentAssertions;

namespace Hunitalla.Quantities.Tests
{
    public class LinearDollarDensityTests
    {
        [Fact]
        public void LinearDollarDensityTimesDistance_ReturnsDollars()
        {
            var perMileRate = 1.2.Dpm();
            var distance = 3.Miles();

            var expected = 3.60.Dollars();

            var actual = perMileRate * distance;

            actual.Should().Be(expected);
        }

        [Fact]
        public void DistanceTimesLinearDollarDensity_ReturnsDollars()
        {
            var perMileRate = 3.DollarsPerMile();
            var distance = 2.Miles();

            var expected = perMileRate * distance;

            var actual = distance * perMileRate;

            actual.Should().Be(expected);
        }
    }
}