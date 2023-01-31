namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class IEpoch_FromJulianDay
{
    private static JulianDay Target(JulianDay julianDay)
    {
        return execute<JulianDay>();

        JulianDay execute<T>() where T : IEpoch<JulianDay> => T.FromJulianDay(julianDay);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var julianDay = Datasets.GetNullJulianDay();

        var exception = Record.Exception(() => Target(julianDay));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void Valid_SameInstance(JulianDay julianDay)
    {
        var actual = Target(julianDay);

        Assert.Same(julianDay, actual);
    }
}
