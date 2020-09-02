using FluentAssertions;
using Xunit;

namespace Hunitalla.Quantities.Tests
{
    public class UsDollarsTests
    {
        [Fact]
        public void UsDollarsDivDistance_ReturnsLinearDollarDensity()
        {
            var dollars = 12.Dollars();
            var distance = 3.Miles();

            var expected = 4.Dpm();

            var actual = dollars / distance;

            actual.Should().Be(expected);
        }
    }
}