namespace SharpHorizons.Tests.QueryCases.EpochCases.ICalendarEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.ComponentModel;

using Xunit;

internal static class Executor_Create
{
    public static void NullStartEpoch_ArgumentNullException(ICalendarEpochRangeFactory factory) => NullStartEpoch_ArgumentNullException(factory.Create);
    public static void NullStartEpoch_ArgumentNullException(Func<IEpoch, IEpoch, int, CalendarStepSizeUnit, IEpochRange> factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetValidStopEpoch();
        var count = GetValidCount();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, count, unit);
    }

    public static void NullStopEpoch_ArgumentNullException(ICalendarEpochRangeFactory factory) => NullStopEpoch_ArgumentNullException(factory.Create);
    public static void NullStopEpoch_ArgumentNullException(Func<IEpoch, IEpoch, int, CalendarStepSizeUnit, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetNullEpoch();
        var count = GetValidCount();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, count, unit);
    }

    public static void NullStartAndStopEpochs_ArgumentNullException(ICalendarEpochRangeFactory factory) => NullStartAndStopEpochs_ArgumentNullException(factory.Create);
    public static void NullStartAndStopEpochs_ArgumentNullException(Func<IEpoch, IEpoch, int, CalendarStepSizeUnit, IEpochRange> factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var count = GetValidCount();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, count, unit);
    }

    public static void StopEpochEarlierThanStartEpoch_ArgumentException(ICalendarEpochRangeFactory factory) => StopEpochEarlierThanStartEpoch_ArgumentException(factory.Create);
    public static void StopEpochEarlierThanStartEpoch_ArgumentException(Func<IEpoch, IEpoch, int, CalendarStepSizeUnit, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var count = GetValidCount();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, count, unit);
    }

    public static void StopEpochSameAsStartEpoch_ArgumentException(ICalendarEpochRangeFactory factory) => StopEpochSameAsStartEpoch_ArgumentException(factory.Create);
    public static void StopEpochSameAsStartEpoch_ArgumentException(Func<IEpoch, IEpoch, int, CalendarStepSizeUnit, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = startEpoch;
        var count = GetValidCount();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, count, unit);
    }

    public static void OutOfRangeCounts_ArgumentOutOfRangeException(ICalendarEpochRangeFactory factory, int count) => OutOfRangeCounts_ArgumentOutOfRangeException(factory.Create, count);
    public static void OutOfRangeCounts_ArgumentOutOfRangeException(Func<IEpoch, IEpoch, int, CalendarStepSizeUnit, IEpochRange> factory, int count)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentOutOfRangeException>(factory, startEpoch, stopEpoch, count, unit);
    }

    public static void ForbiddenUnit_ArgumentException(ICalendarEpochRangeFactory factory, CalendarStepSizeUnit unit) => ForbiddenUnit_ArgumentException(factory.Create, unit);
    public static void ForbiddenUnit_ArgumentException(Func<IEpoch, IEpoch, int, CalendarStepSizeUnit, IEpochRange> factory, CalendarStepSizeUnit unit)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();
        var count = GetValidCount();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, count, unit);
    }

    public static void InvalidUnit_InvalidEnumArgumentException(ICalendarEpochRangeFactory factory, CalendarStepSizeUnit unit) => InvalidUnit_InvalidEnumArgumentException(factory.Create, unit);
    public static void InvalidUnit_InvalidEnumArgumentException(Func<IEpoch, IEpoch, int, CalendarStepSizeUnit, IEpochRange> factory, CalendarStepSizeUnit unit)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();
        var count = GetValidCount();

        AnyError_TException<InvalidEnumArgumentException>(factory, startEpoch, stopEpoch, count, unit);
    }

    public static void NullStartAndStopEpochsAndOutOfRangeCount_ArgumentOutOfRangeException(ICalendarEpochRangeFactory factory) => NullStartAndStopEpochsAndOutOfRangeCount_ArgumentOutOfRangeException(factory.Create);
    public static void NullStartAndStopEpochsAndOutOfRangeCount_ArgumentOutOfRangeException(Func<IEpoch, IEpoch, int, CalendarStepSizeUnit, IEpochRange> factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var count = GetOutOfRangeCount();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentOutOfRangeException>(factory, startEpoch, stopEpoch, count, unit);
    }

    public static void NullStartAndStopEpochsAndForbiddenUnit_ArgumentException(ICalendarEpochRangeFactory factory) => NullStartAndStopEpochsAndForbiddenUnit_ArgumentException(factory.Create);
    public static void NullStartAndStopEpochsAndForbiddenUnit_ArgumentException(Func<IEpoch, IEpoch, int, CalendarStepSizeUnit, IEpochRange> factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var count = GetValidCount();
        var unit = GetForbiddenUnit();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, count, unit);
    }

    private static void AnyError_TException<TException>(Func<IEpoch, IEpoch, int, CalendarStepSizeUnit, IEpochRange> factory, IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit) where TException : Exception
    {
        var exception = Record.Exception(() => factory(startEpoch, stopEpoch, count, unit));

        Assert.IsType<TException>(exception);
    }

    public static void Valid_ExactMatch(ICalendarEpochRangeFactory factory, int count, CalendarStepSizeUnit unit) => Valid_ExactMatch(factory.Create, count, unit);
    public static void Valid_ExactMatch(Func<IEpoch, IEpoch, int, CalendarStepSizeUnit, IEpochRange> factory, int count, CalendarStepSizeUnit unit)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        var actual = factory(startEpoch, stopEpoch, count, unit);

        Assert.Equal(startEpoch, actual.StartEpoch.Epoch);
        Assert.Equal(stopEpoch, actual.StopEpoch.Epoch);

        Assert.Equal(EpochSelectionMode.Range, actual.Selection);
        Assert.Equal(EpochFormat.JulianDays, actual.Format);
        Assert.Equal(CalendarType.Gregorian, actual.Calendar);
        Assert.Equal(TimeSystem.UT, actual.TimeSystem);
        Assert.Equal(Time.Zero, actual.Offset);
    }

    private static int GetValidCount() => 1;
    private static int GetOutOfRangeCount() => 0;

    private static CalendarStepSizeUnit GetValidUnit() => CalendarStepSizeUnit.Month;
    private static CalendarStepSizeUnit GetForbiddenUnit() => CalendarStepSizeUnit.Unknown;

    private static IEpoch GetNullEpoch() => null!;
    private static IEpoch GetValidStartEpoch() => new JulianDay(0);
    private static IEpoch GetValidStopEpoch() => new JulianDay(1);
    private static IEpoch GetEarlierStopEpoch() => new JulianDay(-1);
}
