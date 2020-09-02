using FluentAssertions;
using Xunit;

namespace Hunitalla.Quantities.Tests
{
    public class VelocityTests
    {
        [Fact]
        public void VelocityTimesDuration_ReturnsDistance()
        {
            var velocity = 3.Mph();
            var duration = 60.Minutes();

            var expected = 3.Miles();

            var actual = velocity * duration;

            actual.Should().Be(expected);
        }

        [Fact]
        public void DurationTimesVelocity_ReturnsDistance()
        {
            var velocity = 123.Mph();
            var duration = 321.Minutes();

            var expected = velocity * duration;

            var actual = duration * velocity;

            actual.Should().Be(expected);
        }
    }
}