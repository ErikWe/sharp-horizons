namespace SharpHorizons.Tests.QueryCases.EpochCases.ICalendarEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using Xunit;

public class Create
{
    [Fact]
    public void NullStartEpoch_ArgumentNullException() => Executor_Create.NullStartEpoch_ArgumentNullException(GetService());

    [Fact]
    public void NullStopEpoch_ArgumentNullException() => Executor_Create.NullStopEpoch_ArgumentNullException(GetService());

    [Fact]
    public void NullStartAndStopEpochs_ArgumentNullException() => Executor_Create.NullStartAndStopEpochs_ArgumentNullException(GetService());

    [Fact]
    public void StopEpochEarlierThanStartEpoch_ArgumentException() => Executor_Create.StopEpochEarlierThanStartEpoch_ArgumentException(GetService());

    [Fact]
    public void StopEpochSameAsStartEpoch_ArgumentException() => Executor_Create.StopEpochSameAsStartEpoch_ArgumentException(GetService());

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeCounts))]
    public void OutOfRangeCounts_ArgumentOutOfRangeException(int count) => Executor_Create.OutOfRangeCounts_ArgumentOutOfRangeException(GetService(), count);

    [Theory]
    [ClassData(typeof(Datasets.ForbiddenUnits))]
    public void ForbiddenUnit_ArgumentException(CalendarStepSizeUnit unit) => Executor_Create.ForbiddenUnit_ArgumentException(GetService(), unit);

    [Theory]
    [ClassData(typeof(Datasets.InvalidUnits))]
    public void InvalidUnit_InvalidEnumArgumentException(CalendarStepSizeUnit unit) => Executor_Create.InvalidUnit_InvalidEnumArgumentException(GetService(), unit);

    [Fact]
    public void NullStartAndStopEpochsAndOutOfRangeCount_ArgumentOutOfRangeException() => Executor_Create.NullStartAndStopEpochsAndOutOfRangeCount_ArgumentOutOfRangeException(GetService());

    [Fact]
    public void NullStartAndStopEpochsAndForbiddenUnit_ArgumentException() => Executor_Create.NullStartAndStopEpochsAndForbiddenUnit_ArgumentException(GetService());

    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Valid_ExactMatch(int count, CalendarStepSizeUnit unit) => Executor_Create.Valid_ExactMatch(GetService(), count, unit);

    private static ICalendarEpochRangeFactory GetService() => DependencyInjection.GetRequiredService<ICalendarEpochRangeFactory>();
}
