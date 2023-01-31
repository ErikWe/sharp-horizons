﻿namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using SharpMeasures;

using System;

using Xunit;

public class IEpoch_Add
{
    private static JulianDay Target(JulianDay julianDay, Time difference)
    {
        return execute(julianDay);

        T execute<T>(IEpoch<T> epoch) where T : IEpoch<T> => epoch.Add(difference);
    }

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.InvalidTimes))]
    public void Invalid_ArgumentException(Time difference) => AnyError_TException<ArgumentException>(difference);

    [Fact]
    public void OutOfBounds_EpochOutOfBoundsException()
    {
        var difference = EpochCases.Datasets.GetOutOfBoundsTime();

        AnyError_TException<EpochOutOfBoundsException>(difference);
    }

    [Theory]
    [ClassData(typeof(EpochCases.Datasets.ValidTimes))]
    public void ApproximateMatch(Time difference)
    {
        var julianDay = Datasets.GetValidJulianDay();

        var expected = julianDay.Day + difference.Days;

        var actual = Target(julianDay, difference);

        Asserter.Approximate(expected, actual.Day);
    }

    private static void AnyError_TException<TException>(Time difference) where TException : Exception
    {
        var julianDay = Datasets.GetValidJulianDay();

        var exception = Record.Exception(() => Target(julianDay, difference));

        Assert.IsType<TException>(exception);
    }
}
