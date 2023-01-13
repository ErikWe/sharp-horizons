namespace SharpHorizons.Tests.QueryCases.EpochCases.IUniformEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

using Xunit;

internal static class Executor_Create
{
    public static void NullStartEpoch_ArgumentNullException(IUniformEpochRangeFactory factory) => NullStartEpoch_ArgumentNullException(factory.Create);
    public static void NullStartEpoch_ArgumentNullException(Func<IEpoch, IEpoch, int, IEpochRange> factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetValidStopEpoch();
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, stepCount);
    }

    public static void NullStopEpoch_ArgumentNullException(IUniformEpochRangeFactory factory) => NullStopEpoch_ArgumentNullException(factory.Create);
    public static void NullStopEpoch_ArgumentNullException(Func<IEpoch, IEpoch, int, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetNullEpoch();
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, stepCount);
    }

    public static void NullStartAndStopEpochs_ArgumentNullException(IUniformEpochRangeFactory factory) => NullStartAndStopEpochs_ArgumentNullException(factory.Create);
    public static void NullStartAndStopEpochs_ArgumentNullException(Func<IEpoch, IEpoch, int, IEpochRange> factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, stepCount);
    }

    public static void StopEpochEarlierThanStartEpoch_ArgumentException(IUniformEpochRangeFactory factory) => StopEpochEarlierThanStartEpoch_ArgumentException(factory.Create);
    public static void StopEpochEarlierThanStartEpoch_ArgumentException(Func<IEpoch, IEpoch, int, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, stepCount);
    }

    public static void StopEpochSameAsStartEpoch_ArgumentException(IUniformEpochRangeFactory factory) => StopEpochSameAsStartEpoch_ArgumentException(factory.Create);
    public static void StopEpochSameAsStartEpoch_ArgumentException(Func<IEpoch, IEpoch, int, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = startEpoch;
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, stepCount);
    }

    public static void OutOfRangeStepCount_ArgumentOutOfRangeException(IUniformEpochRangeFactory factory, int stepCount) => OutOfRangeStepCount_ArgumentOutOfRangeException(factory.Create, stepCount);
    public static void OutOfRangeStepCount_ArgumentOutOfRangeException(Func<IEpoch, IEpoch, int, IEpochRange> factory, int stepCount)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        AnyError_TException<ArgumentOutOfRangeException>(factory, startEpoch, stopEpoch, stepCount);
    }

    public static void NullStartAndStopEpochsAndOutOfRangeStepCount_ArgumentOutOfRangeException(IUniformEpochRangeFactory factory) => NullStartAndStopEpochsAndOutOfRangeStepCount_ArgumentOutOfRangeException(factory.Create);
    public static void NullStartAndStopEpochsAndOutOfRangeStepCount_ArgumentOutOfRangeException(Func<IEpoch, IEpoch, int, IEpochRange> factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var stepCount = GetOutOfRangeStepCount();

        AnyError_TException<ArgumentOutOfRangeException>(factory, startEpoch, stopEpoch, stepCount);
    }

    private static void AnyError_TException<TException>(Func<IEpoch, IEpoch, int, IEpochRange> factory, IEpoch startEpoch, IEpoch stopEpoch, int stepCount) where TException : Exception
    {
        var exception = Record.Exception(() => factory(startEpoch, stopEpoch, stepCount));

        Assert.IsType<TException>(exception);
    }

    public static void Valid_ExactMatch(IUniformEpochRangeFactory factory, int stepCount) => Valid_ExactMatch(factory.Create, stepCount);
    public static void Valid_ExactMatch(Func<IEpoch, IEpoch, int, IEpochRange> factory, int stepCount)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        var actual = factory(startEpoch, stopEpoch, stepCount);

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
