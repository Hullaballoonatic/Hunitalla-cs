using Xunit;
using FluentAssertions;

namespace Hunitalla.Quantities.Tests
{
    public class DistanceTests
    {
        [Fact]
        public void DistanceDivDuration_ReturnsVelocity()
        {
            var distance = 60.Miles();
            var duration = 60.Minutes();

            var expected = 60.Mph();

            var actual = distance / duration;

            actual.Should().Be(expected);
        }
    }
}