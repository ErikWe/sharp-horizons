namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using SharpMeasures;

using System;

using Xunit;

public class Difference_IEpoch
{
    private static Time Target(ModifiedJulianDay modifiedJulianDay, IEpoch other) => modifiedJulianDay.Difference(other);

    private static int TimePrecision { get; } = 5;

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
    public void Convertible_ApproximateMatchDayDifference(ModifiedJulianDay modifiedJulianDay, IEpoch other)
    {
        var expected = modifiedJulianDay.Day - getOtherModifiedJulianDayNumber();

        var actual = Target(modifiedJulianDay, other);

        Assert.Equal(expected, actual.Days, TimePrecision);

        double getOtherModifiedJulianDayNumber()
        {
            if (other is ModifiedJulianDay otherModifiedJulianDay)
            {
                return otherModifiedJulianDay.Day;
            }

            return other.ToJulianDay().Day - ModifiedJulianDay.Epoch.ToJulianDay().Day;
        }
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
