namespace SharpHorizons.Tests.QueryCases.EpochCases.ICalendarEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.ComponentModel;

using Xunit;

public class Create
{
    [Fact]
    public void NullStartEpoch_ArgumentNullException()
    {
        var startEpoch = GetInvalidEpoch();
        var stopEpoch = GetValidStopEpoch();
        var count = GetValidCount();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, count, unit);
    }

    [Fact]
    public void NullStopEpoch_ArgumentNullException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetInvalidEpoch();
        var count = GetValidCount();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, count, unit);
    }

    [Fact]
    public void NullStartAndStopEpochs_ArgumentNullException()
    {
        var startEpoch = GetInvalidEpoch();
        var stopEpoch = GetInvalidEpoch();
        var count = GetValidCount();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, count, unit);
    }

    [Fact]
    public void StopEpochEarlierThanStartEpoch_ArgumentException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var count = GetValidCount();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, count, unit);
    }

    [Fact]
    public void StopEpochSameAsStartEpoch_ArgumentException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = startEpoch;
        var count = GetValidCount();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, count, unit);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeCounts))]
    public void OutOfRangeCounts_ArgumentOutOfRangeException(int count)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentOutOfRangeException>(startEpoch, stopEpoch, count, unit);
    }

    [Theory]
    [ClassData(typeof(Datasets.ForbiddenUnits))]
    public void ForbiddenUnit_ArgumentException(CalendarStepSizeUnit unit)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();
        var count = GetValidCount();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, count, unit);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidUnits))]
    public void InvalidUnit_InvalidEnumArgumentException(CalendarStepSizeUnit unit)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();
        var count = GetValidCount();

        AnyError_TException<InvalidEnumArgumentException>(startEpoch, stopEpoch, count, unit);
    }

    [Fact]
    public void NullStartAndStopEpochsAndOutOfRangeCount_ArgumentOutOfRangeException()
    {
        var startEpoch = GetInvalidEpoch();
        var stopEpoch = GetInvalidEpoch();
        var count = GetOutOfRangeCount();
        var unit = GetValidUnit();

        AnyError_TException<ArgumentOutOfRangeException>(startEpoch, stopEpoch, count, unit);
    }

    [Fact]
    public void NullStartAndStopEpochsAndForbiddenUnit_ArgumentException()
    {
        var startEpoch = GetInvalidEpoch();
        var stopEpoch = GetInvalidEpoch();
        var count = GetValidCount();
        var unit = GetForbiddenUnit();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, count, unit);
    }

    private static void AnyError_TException<TException>(IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit) where TException : Exception
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(startEpoch, stopEpoch, count, unit));

        Assert.IsType<TException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Valid_ExactMatch(int count, CalendarStepSizeUnit unit)
    {
        var factory = GetService();

        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        var actual = factory.Create(startEpoch, stopEpoch, count, unit);

        Assert.Equal(startEpoch, actual.StartEpoch.Epoch);
        Assert.Equal(stopEpoch, actual.StopEpoch.Epoch);

        Assert.Equal(EpochSelectionMode.Range, actual.Selection);
        Assert.Equal(EpochFormat.JulianDays, actual.Format);
        Assert.Equal(CalendarType.Gregorian, actual.Calendar);
        Assert.Equal(TimeSystem.UT, actual.TimeSystem);
        Assert.Equal(Time.Zero, actual.Offset);
    }

    private static ICalendarEpochRangeFactory GetService() => DependencyInjection.GetRequiredService<ICalendarEpochRangeFactory>();

    private static int GetValidCount() => 1;
    private static int GetOutOfRangeCount() => 0;

    private static CalendarStepSizeUnit GetValidUnit() => CalendarStepSizeUnit.Month;
    private static CalendarStepSizeUnit GetForbiddenUnit() => CalendarStepSizeUnit.Unknown;

    private static IEpoch GetInvalidEpoch() => null!;
    private static IEpoch GetValidStartEpoch() => new JulianDay(0);
    private static IEpoch GetValidStopEpoch() => new JulianDay(1);
    private static IEpoch GetEarlierStopEpoch() => new JulianDay(-1);
}
