namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using SharpMeasures;

using System;

using Xunit;

public class IEpoch_Difference_IEpoch
{
    private static Time Target(ModifiedJulianDay modifiedJulianDay, IEpoch other)
    {
        return execute(modifiedJulianDay);

        Time execute(IEpoch epoch) => epoch.Difference(other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Null_ArgumentNullException(ModifiedJulianDay modifiedJulianDay)
    {
        var other = Datasets.GetNullIEpoch();

        AnyError_TException<ArgumentNullException>(modifiedJulianDay, other);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_UnconvertibleIEpoch))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_UnconvertibleIEpoch))]
    public void Unconvertible_ArgumentException(ModifiedJulianDay modifiedJulianDay, IEpoch other) => AnyError_TException<ArgumentException>(modifiedJulianDay, other);

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_ConvertibleIEpoch))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_ConvertibleIEpoch))]
    public void Convertible_ExactMatchModifiedJulianDayDifference(ModifiedJulianDay modifiedJulianDay, IEpoch other)
    {
        var expected = modifiedJulianDay.Difference(other);

        var actual = Target(modifiedJulianDay, other);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void SameInstance_Zero(ModifiedJulianDay modifiedJulianDay)
    {
        var actual = Target(modifiedJulianDay, modifiedJulianDay);

        Assert.Equal(Time.Zero, actual);
    }

    private static void AnyError_TException<TException>(ModifiedJulianDay modifiedJulianDay, IEpoch other) where TException : Exception
    {
        var exception = Record.Exception(() => Target(modifiedJulianDay, other));

        Assert.IsType<TException>(exception);
    }
}
