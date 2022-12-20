namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using System;
using System.Collections.Generic;

using Xunit;

public class CastToInstant
{
    [Theory]
    [MemberData(nameof(Instants))]
    public void Valid(Instant instant)
    {
        var epoch = (Epoch)instant;

        Assert.Equal(instant, epoch.Instant);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => (Instant)(Epoch)null!);
    }

    public static IEnumerable<object[]> Instants() => new object[][]
    {
        new object[] { Instant.MaxValue },
        new object[] { Instant.MinValue },
        new object[] { Instant.FromJulianDate(0) },
        new object[] { Instant.FromJulianDate(-10.14) },
        new object[] { Instant.FromJulianDate(10.14) }
    };
}
