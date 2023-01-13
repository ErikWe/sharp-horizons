namespace SharpHorizons.Tests.QueryCases.EpochCases.IFixedEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

using Xunit;

internal static class Executor_Create
{
    public static void NullStartEpoch_ArgumentNullException(IFixedEpochRangeFactory factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetValidStopEpoch();
        var deltaTime = GetValidTime();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, deltaTime);
    }

    public static void NullStopEpoch_ArgumentNullException(IFixedEpochRangeFactory factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaTime = GetValidTime();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, deltaTime);
    }

    public static void NullStartAndStopEpochs_ArgumentNullException(IFixedEpochRangeFactory factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaTime = GetValidTime();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, deltaTime);
    }

    public static void StopEpochEarlierThanStartEpoch_ArgumentException(IFixedEpochRangeFactory factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var deltaTime = GetValidTime();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, deltaTime);
    }

    public static void StopEpochSameAsStartEpoch_ArgumentException(IFixedEpochRangeFactory factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = startEpoch;
        var deltaTime = GetValidTime();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, deltaTime);
    }

    public static void InvalidDeltaTime_ArgumentException(IFixedEpochRangeFactory factory, Time deltaTime)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, deltaTime);
    }

    public static void OutOfRangeDeltaTime_ArgumentOutOfRangeException(IFixedEpochRangeFactory factory, Time deltaTime)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        AnyError_TException<ArgumentOutOfRangeException>(factory, startEpoch, stopEpoch, deltaTime);
    }

    public static void NullStartAndStopEpochsAndInvalidDeltaTime_ArgumentException(IFixedEpochRangeFactory factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaTime = GetInvalidTime();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, deltaTime);
    }

    private static void AnyError_TException<TException>(IFixedEpochRangeFactory factory, IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime) where TException : Exception
    {
        var exception = Record.Exception(() => factory.Create(startEpoch, stopEpoch, deltaTime));

        Assert.IsType<TException>(exception);
    }

    public static void Valid_ExactMatch(IFixedEpochRangeFactory factory, Time deltaTime)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        var actual = factory.Create(startEpoch, stopEpoch, deltaTime);

        Assert.Equal(startEpoch, actual.StartEpoch.Epoch);
        Assert.Equal(stopEpoch, actual.StopEpoch.Epoch);

        Assert.Equal(EpochSelectionMode.Range, actual.Selection);
        Assert.Equal(EpochFormat.JulianDays, actual.Format);
        Assert.Equal(CalendarType.Gregorian, actual.Calendar);
        Assert.Equal(TimeSystem.UT, actual.TimeSystem);
        Assert.Equal(Time.Zero, actual.Offset);
    }

    private static Time GetInvalidTime() => new(double.NaN);
    private static Time GetValidTime() => new(1);

    private static IEpoch GetNullEpoch() => null!;
    private static IEpoch GetValidStartEpoch() => new JulianDay(0);
    private static IEpoch GetValidStopEpoch() => new JulianDay(1);
    private static IEpoch GetEarlierStopEpoch() => new JulianDay(-1);
}
