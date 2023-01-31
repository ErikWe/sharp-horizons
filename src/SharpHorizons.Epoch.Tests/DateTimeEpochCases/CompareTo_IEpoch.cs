﻿namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;

using Xunit;

public class CompareTo_IEpoch
{
    private static int Target(DateTimeEpoch epoch, IEpoch other) => epoch.CompareTo(other);

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch_UnconvertibleIEpoch))]
    public void Unconvertible_ArgumentException(DateTimeEpoch epoch, IEpoch other)
    {
        var exception = Record.Exception(() => Target(epoch, other));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void Null_Positive(DateTimeEpoch epoch)
    {
        var other = Datasets.GetNullIEpoch();

        var comparison = Target(epoch, other);

        Assert.True(comparison > 0);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch_ConvertibleIEpoch))]
    public void Convertible_SameSignAsJulianDayComparison(DateTimeEpoch epoch, IEpoch other)
    {
        var expected = Math.Sign(epoch.ToJulianDay().CompareTo(other));

        var actual = Math.Sign(Target(epoch, other));

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDateTimeEpoch))]
    public void SameInstance_Zero(DateTimeEpoch epoch)
    {
        var actual = Target(epoch, epoch);

        Assert.Equal(0, actual);
    }
}