namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System;

using Xunit;

public class CompareTo_IEpoch
{
    private static int Target(ModifiedJulianDay modifiedJulianDay, IEpoch other) => modifiedJulianDay.CompareTo(other);

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_UnconvertibleIEpoch))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_UnconvertibleIEpoch))]
    public void Unconvertible_ArgumentException(ModifiedJulianDay modifiedJulianDay, IEpoch other)
    {
        var exception = Record.Exception(() => Target(modifiedJulianDay, other));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay))]
    public void Null_Positive(ModifiedJulianDay modifiedJulianDay)
    {
        var other = Datasets.GetNullIEpoch();

        var comparison = Target(modifiedJulianDay, other);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.ConvertibleModifiedJulianDay_ConvertibleIEpoch))]
    [ClassData(typeof(Datasets.UnconvertibleModifiedJulianDay_ConvertibleIEpoch))]
    public void Convertible_SameSignAsDoubleComparison(ModifiedJulianDay modifiedJulianDay, IEpoch other)
    {
        var expected = Math.Sign(modifiedJulianDay.Day.CompareTo(getOtherModifiedJulianDayNumber()));

        var actual = Math.Sign(Target(modifiedJulianDay, other));

        Assert.Equal(expected, actual);

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

        Assert.Equal(0, actual);
    }
}
