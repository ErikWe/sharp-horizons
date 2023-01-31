namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using Xunit;

internal static class Asserter
{
    public static void ApproximateJulianDay(JulianDay expected, JulianDay actual) => JulianDayCases.Asserter.Approximate(expected.Day, actual.Day);

    public static void Approximate(DateTimeEpoch expected, DateTimeEpoch actual)
    {
        var difference = expected.DateTimeOffset.Subtract(actual.DateTimeOffset);

        Assert.Equal(0, difference.TotalSeconds, 1);
    }
}
