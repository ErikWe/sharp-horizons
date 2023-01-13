namespace SharpHorizons.Tests.QueryCases.EpochCases.IUniformEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

using Xunit;

internal static class Executor_Create
{
    public static void NullStartEpoch_ArgumentNullException(IUniformEpochRangeFactory factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetValidStopEpoch();
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, stepCount);
    }

    public static void NullStopEpoch_ArgumentNullException(IUniformEpochRangeFactory factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetNullEpoch();
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, stepCount);
    }

    public static void NullStartAndStopEpochs_ArgumentNullException(IUniformEpochRangeFactory factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, stepCount);
    }

    public static void StopEpochEarlierThanStartEpoch_ArgumentException(IUniformEpochRangeFactory factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, stepCount);
    }

    public static void StopEpochSameAsStartEpoch_ArgumentException(IUniformEpochRangeFactory factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = startEpoch;
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, stepCount);
    }

    public static void OutOfRangeStepCount_ArgumentOutOfRangeException(IUniformEpochRangeFactory factory, int stepCount)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        AnyError_TException<ArgumentOutOfRangeException>(factory, startEpoch, stopEpoch, stepCount);
    }

    public static void NullStartAndStopEpochsAndOutOfRangeStepCount_ArgumentOutOfRangeException(IUniformEpochRangeFactory factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var stepCount = GetOutOfRangeStepCount();

        AnyError_TException<ArgumentOutOfRangeException>(factory, startEpoch, stopEpoch, stepCount);
    }

    private static void AnyError_TException<TException>(IUniformEpochRangeFactory factory, IEpoch startEpoch, IEpoch stopEpoch, int stepCount) where TException : Exception
    {
        var exception = Record.Exception(() => factory.Create(startEpoch, stopEpoch, stepCount));

        Assert.IsType<TException>(exception);
    }

    public static void Valid_ExactMatch(IUniformEpochRangeFactory factory, int stepCount)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        var actual = factory.Create(startEpoch, stopEpoch, stepCount);

        Assert.Equal(startEpoch, actual.StartEpoch.Epoch);
        Assert.Equal(stopEpoch, actual.StopEpoch.Epoch);

        Assert.Equal(EpochSelectionMode.Range, actual.Selection);
        Assert.Equal(EpochFormat.JulianDays, actual.Format);
        Assert.Equal(CalendarType.Gregorian, actual.Calendar);
        Assert.Equal(TimeSystem.UT, actual.TimeSystem);
        Assert.Equal(Time.Zero, actual.Offset);
    }

    private static int GetOutOfRangeStepCount() => 0;
    private static int GetValidStepCount() => 1;

    private static IEpoch GetNullEpoch() => null!;
    private static IEpoch GetValidStartEpoch() => new JulianDay(0);
    private static IEpoch GetValidStopEpoch() => new JulianDay(1);
    private static IEpoch GetEarlierStopEpoch() => new JulianDay(-1);
}
