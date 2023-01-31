namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using SharpMeasures;

using System;

using Xunit;

public class Operator_Subtract_IEpoch
{
    private static Time Target(JulianDay julianDay, IEpoch other) => julianDay - other;

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleIEpoch))]
    public void NullLHS_ArgumentNullException(IEpoch other)
    {
        var julianDay = Datasets.GetNullJulianDay();

        AnyError_TException<ArgumentNullException>(julianDay, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void NullRHS_ArgumentNullException(JulianDay julianDay)
    {
        var other = Datasets.GetNullIEpoch();

        AnyError_TException<ArgumentNullException>(julianDay, other);
    }

    [Fact]
    public void NullLHSAndRHS_ArgumentNullException()
    {
        var julianDay = Datasets.GetNullJulianDay();
        var other = Datasets.GetNullIEpoch();

        AnyError_TException<ArgumentNullException>(julianDay, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay_UnconvertibleIEpoch))]
    public void UnconvertibleRHS_ArgumentException(JulianDay julianDay, IEpoch other) => AnyError_TException<ArgumentException>(julianDay, other);

    [Theory]
    [ClassData(typeof(Datasets.UnconvertibleIEpoch))]
    public void NullLHSAndUnconvertibleRHS_ArgumentNullException(IEpoch other)
    {
        var julianDay = Datasets.GetNullJulianDay();

        AnyError_TException<ArgumentNullException>(julianDay, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay_ConvertibleIEpoch))]
    public void Convertible_ExactMatchDifference(JulianDay julianDay, IEpoch other)
    {
        var expected = julianDay.Difference(other);

        var actual = Target(julianDay, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidJulianDay))]
    public void SameInstance_Zero(JulianDay julianDay)
    {
        var actual = Target(julianDay, julianDay);

        Assert.Equal(Time.Zero, actual);
    }

    private static void AnyError_TException<TException>(JulianDay julianDay, IEpoch other) where TException : Exception
    {
        var exception = Record.Exception(() => Target(julianDay, other));

        Assert.IsType<TException>(exception);
    }
}
