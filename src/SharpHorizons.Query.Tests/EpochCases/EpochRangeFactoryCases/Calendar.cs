namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Tests.QueryCases.EpochCases.ICalendarEpochRangeFactoryCases;

using System;

using Xunit;

public class Calendar
{
    [Fact]
    public void NullStartEpoch_ArgumentNullException() => Executor_Create.NullStartEpoch_ArgumentNullException(GetDelegate());

    [Fact]
    public void NullStopEpoch_ArgumentNullException() => Executor_Create.NullStopEpoch_ArgumentNullException(GetDelegate());

    [Fact]
    public void NullStartAndStopEpochs_ArgumentNullException() => Executor_Create.NullStartAndStopEpochs_ArgumentNullException(GetDelegate());

    [Fact]
    public void StopEpochEarlierThanStartEpoch_ArgumentException() => Executor_Create.StopEpochEarlierThanStartEpoch_ArgumentException(GetDelegate());

    [Fact]
    public void StopEpochSameAsStartEpoch_ArgumentException() => Executor_Create.StopEpochSameAsStartEpoch_ArgumentException(GetDelegate());

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeCounts))]
    public void OutOfRangeCounts_ArgumentOutOfRangeException(int count) => Executor_Create.OutOfRangeCounts_ArgumentOutOfRangeException(GetDelegate(), count);

    [Theory]
    [ClassData(typeof(Datasets.ForbiddenUnits))]
    public void ForbiddenUnit_ArgumentException(CalendarStepSizeUnit unit) => Executor_Create.ForbiddenUnit_ArgumentException(GetDelegate(), unit);

    [Theory]
    [ClassData(typeof(Datasets.InvalidUnits))]
    public void InvalidUnit_InvalidEnumArgumentException(CalendarStepSizeUnit unit) => Executor_Create.InvalidUnit_InvalidEnumArgumentException(GetDelegate(), unit);

    [Fact]
    public void NullStartAndStopEpochsAndOutOfRangeCount_ArgumentOutOfRangeException() => Executor_Create.NullStartAndStopEpochsAndOutOfRangeCount_ArgumentOutOfRangeException(GetDelegate());

    [Fact]
    public void NullStartAndStopEpochsAndForbiddenUnit_ArgumentException() => Executor_Create.NullStartAndStopEpochsAndForbiddenUnit_ArgumentException(GetDelegate());

    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Valid_ExactMatch(int count, CalendarStepSizeUnit unit) => Executor_Create.Valid_ExactMatch(GetDelegate(), count, unit);

    private static Func<IEpoch, IEpoch, int, CalendarStepSizeUnit, IEpochRange> GetDelegate() => new EpochRangeFactory().Calendar;
}
