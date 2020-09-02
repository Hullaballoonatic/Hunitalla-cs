using Xunit;
using System;
using FluentAssertions;

namespace Hunitalla.Quantities.Tests
{
    public class DurationTests
    {
        [Fact]
        public void ImplicitDurationConversion_ReturnsTimespan()
        {
            const int numSeconds = 1;

            var duration = numSeconds.Seconds();

            var expected = TimeSpan.FromSeconds(numSeconds);

            TimeSpan actual = duration;

            expected.Should().Be(actual);
        }

        [Fact]
        public void ImplicitTimeSpanConversion_ReturnsDuration()
        {
            const int numSeconds = 1;

            var timespan = TimeSpan.FromSeconds(numSeconds);

            var expected = numSeconds.Seconds();

            Duration actual = timespan;

            expected.Should().Be(actual);
        }
    }
}