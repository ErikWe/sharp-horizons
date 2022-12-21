namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class CastToDouble
{
    [Theory]
    [ClassData(typeof(Datasets.JulianDays))]
    public void Valid_ApproximateMatch(JulianDay julianDay)
    {
        var actual = (double)julianDay;

        Asserter.Approximate(julianDay.Day, actual);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => (double)(JulianDay)null!);
    }
}
