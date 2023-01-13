namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Tests.QueryCases.EpochCases.ICalendarEpochRangeFactoryCases;

using Xunit;

public class Create_ICalendarEpochRangeFactory
{
    [Fact]
    public void NullStartEpoch_ArgumentNullException() => Executor_Create.NullStartEpoch_ArgumentNullException(GetInstance());

    [Fact]
    public void NullStopEpoch_ArgumentNullException() => Executor_Create.NullStopEpoch_ArgumentNullException(GetInstance());

    [Fact]
    public void NullStartAndStopEpochs_ArgumentNullException() => Executor_Create.NullStartAndStopEpochs_ArgumentNullException(GetInstance());

    [Fact]
    public void StopEpochEarlierThanStartEpoch_ArgumentException() => Executor_Create.StopEpochEarlierThanStartEpoch_ArgumentException(GetInstance());

    [Fact]
    public void StopEpochSameAsStartEpoch_ArgumentException() => Executor_Create.StopEpochSameAsStartEpoch_ArgumentException(GetInstance());

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeCounts))]
    public void OutOfRangeCounts_ArgumentOutOfRangeException(int count) => Executor_Create.OutOfRangeCounts_ArgumentOutOfRangeException(GetInstance(), count);

    [Theory]
    [ClassData(typeof(Datasets.ForbiddenUnits))]
    public void ForbiddenUnit_ArgumentException(CalendarStepSizeUnit unit) => Executor_Create.ForbiddenUnit_ArgumentException(GetInstance(), unit);

    [Theory]
    [ClassData(typeof(Datasets.InvalidUnits))]
    public void InvalidUnit_InvalidEnumArgumentException(CalendarStepSizeUnit unit) => Executor_Create.InvalidUnit_InvalidEnumArgumentException(GetInstance(), unit);

    [Fact]
    public void NullStartAndStopEpochsAndOutOfRangeCount_ArgumentOutOfRangeException() => Executor_Create.NullStartAndStopEpochsAndOutOfRangeCount_ArgumentOutOfRangeException(GetInstance());

    [Fact]
    public void NullStartAndStopEpochsAndForbiddenUnit_ArgumentException() => Executor_Create.NullStartAndStopEpochsAndForbiddenUnit_ArgumentException(GetInstance());

    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Valid_ExactMatch(int count, CalendarStepSizeUnit unit) => Executor_Create.Valid_ExactMatch(GetInstance(), count, unit);

    private static EpochRangeFactory GetInstance() => new();
}
