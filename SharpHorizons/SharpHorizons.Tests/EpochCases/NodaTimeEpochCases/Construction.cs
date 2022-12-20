namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using System.Collections.Generic;

using Xunit;

public class Construction
{
    [Theory]
    [MemberData(nameof(ValidInstants))]
    public void Constructor_Valid(Instant instant)
    {
        Epoch epoch = new(instant);

        Assert.Equal(instant, epoch.Instant);
    }

    [Theory]
    [MemberData(nameof(ValidInstants))]
    public void Initialization_Valid(Instant instant)
    {
        Epoch epoch = new() { Instant = instant };

        Assert.Equal(instant, epoch.Instant);
    }

    [Theory]
    [MemberData(nameof(ValidInstants))]
    public void CastFromInstant_Valid(Instant instant)
    {
        var epoch = (Epoch)instant;

        Assert.Equal(instant, epoch.Instant);
    }

    public static IEnumerable<object[]> ValidInstants() => new object[][]
    {
        new object[] { Instant.MaxValue },
        new object[] { Instant.MinValue },
        new object[] { Instant.FromJulianDate(0) },
        new object[] { Instant.FromJulianDate(-10.14) },
        new object[] { Instant.FromJulianDate(10.14) }
    };
}
