namespace SharpHorizons.Tests.QueryCases.EpochCases.IEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

using Xunit;

internal static class Executor_Create
{
    public static void NullStartEpoch_ArgumentNullException(IEpochRangeFactory factory) => NullStartEpoch_ArgumentNullException(factory.Create);
    public static void NullStartEpoch_ArgumentNullException(Func<IEpoch, IEpoch, IStepSize, IEpochRange> factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetValidStopEpoch();
        var stepSize = GetValidStepSize();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, stepSize);
    }

    public static void NullStopEpoch_ArgumentNullException(IEpochRangeFactory factory) => NullStopEpoch_ArgumentNullException(factory.Create);
    public static void NullStopEpoch_ArgumentNullException(Func<IEpoch, IEpoch, IStepSize, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetNullEpoch();
        var stepSize = GetValidStepSize();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, stepSize);
    }

    public static void NullStepSize_ArgumentNullException(IEpochRangeFactory factory) => NullStepSize_ArgumentNullException(factory.Create);
    public static void NullStepSize_ArgumentNullException(Func<IEpoch, IEpoch, IStepSize, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();
        var stepSize = GetNullStepSize();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, stepSize);
    }

    public static void StopEpochEarlierThanStartEpochAndNullStepSize_ArgumentNullException(IEpochRangeFactory factory) => StopEpochEarlierThanStartEpochAndNullStepSize_ArgumentNullException(factory.Create);
    public static void StopEpochEarlierThanStartEpochAndNullStepSize_ArgumentNullException(Func<IEpoch, IEpoch, IStepSize, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var stepSize = GetNullStepSize();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, stepSize);
    }

    public static void StopEpochEarlierThanStartEpoch_ArgumentException(IEpochRangeFactory factory) => StopEpochEarlierThanStartEpoch_ArgumentException(factory.Create);
    public static void StopEpochEarlierThanStartEpoch_ArgumentException(Func<IEpoch, IEpoch, IStepSize, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var stepSize = GetValidStepSize();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, stepSize);
    }

    public static void StopEpochSameAsStartEpoch_ArgumentException(IEpochRangeFactory factory) => StopEpochSameAsStartEpoch_ArgumentException(factory.Create);
    public static void StopEpochSameAsStartEpoch_ArgumentException(Func<IEpoch, IEpoch, IStepSize, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = startEpoch;
        var stepSize = GetValidStepSize();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, stepSize);
    }

    private static void AnyError_TException<TException>(Func<IEpoch, IEpoch, IStepSize, IEpochRange> factory, IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize) where TException : Exception
    {
        var exception = Record.Exception(() => factory(startEpoch, stopEpoch, stepSize));

        Assert.IsType<TException>(exception);
    }

    public static void Valid_ExactMatch(IEpochRangeFactory factory) => Valid_ExactMatch(factory.Create);
    public static void Valid_ExactMatch(Func<IEpoch, IEpoch, IStepSize, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();
        var stepSize = GetValidStepSize();

        var actual = factory(startEpoch, stopEpoch, stepSize);

        Assert.Equal(startEpoch, actual.StartEpoch.Epoch);
        Assert.Equal(stopEpoch, actual.StopEpoch.Epoch);

        Assert.Equal(EpochSelectionMode.Range, actual.Selection);
        Assert.Equal(EpochFormat.JulianDays, actual.Format);
        Assert.Equal(CalendarType.Gregorian, actual.Calendar);
        Assert.Equal(TimeSystem.UT, actual.TimeSystem);
        Assert.Equal(Time.Zero, actual.Offset);
    }

    private static IEpoch GetNullEpoch() => null!;
    private static IEpoch GetValidStartEpoch() => new JulianDay(0);
    private static IEpoch GetValidStopEpoch() => new JulianDay(1);
    private static IEpoch GetEarlierStopEpoch() => new JulianDay(-1);

    private static IStepSize GetNullStepSize() => null!;
    private static IStepSize GetValidStepSize()
    {
        var factory = DependencyInjection.GetRequiredService<IUniformStepSizeFactory>();

        return factory.Create(1);
    }
}
