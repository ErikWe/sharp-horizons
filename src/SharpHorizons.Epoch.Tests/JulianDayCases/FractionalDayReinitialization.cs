namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System;

using Xunit;

public class FractionalDayReinitialization
{
    private static JulianDay Target(JulianDay julianDay, float fractionalDay) => julianDay with { FractionalDay = fractionalDay };

    [Theory]
    [ClassData(typeof(Datasets.InvalidJulianDayFractionalDayFloat))]
    public void Invalid_ArgumentException(float fractionalDay) => AnyError_TException<ArgumentException>(fractionalDay);

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeJulianDayFractionalDayFloat))]
    public void OutOfRange_ArgumentOutOfRangeException(float fractionalDay) => AnyError_TException<ArgumentOutOfRangeException>(fractionalDay);

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayFractionalDayFloat))]
    public void Valid_ExactMatch(float fractionalDay)
    {
        var initial = Datasets.GetValidJulianDay();

        var actual = Target(initial, fractionalDay);

        Assert.Equal(fractionalDay, actual.FractionalDay);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDayFractionalDayFloat))]
    public void Valid_OriginalNotModified(float fractionalDay)
    {
        var initial = Datasets.GetValidJulianDay();

        var expected = initial.FractionalDay;

        Target(initial, fractionalDay);

        var actual = initial.FractionalDay;

        Assert.Equal(expected, actual);
    }

    private static void AnyError_TException<TException>(float fractionalDay) where TException : Exception
    {
        var initial = Datasets.GetValidJulianDay();

        var exception = Record.Exception(() => Target(initial, fractionalDay));

        Assert.IsType<TException>(exception);
    }
}
