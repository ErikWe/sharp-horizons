namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Tests.QueryCases.EpochCases.IEpochRangeFactoryCases;

using Xunit;

public class Create_IEpochRangeFactory
{
    [Fact]
    public void NullStartEpoch_ArgumentNullException() => Executor_Create.NullStartEpoch_ArgumentNullException(GetInstance());

    [Fact]
    public void NullStopEpoch_ArgumentNullException() => Executor_Create.NullStopEpoch_ArgumentNullException(GetInstance());

    [Fact]
    public void NullStepSize_ArgumentNullException() => Executor_Create.NullStepSize_ArgumentNullException(GetInstance());

    [Fact]
    public void StopEpochEarlierThanStartEpochAndNullStepSize_ArgumentNullException() => Executor_Create.StopEpochEarlierThanStartEpochAndNullStepSize_ArgumentNullException(GetInstance());

    [Fact]
    public void StopEpochEarlierThanStartEpoch_ArgumentException() => Executor_Create.StopEpochEarlierThanStartEpoch_ArgumentException(GetInstance());

    [Fact]
    public void StopEpochSameAsStartEpoch_ArgumentException() => Executor_Create.StopEpochSameAsStartEpoch_ArgumentException(GetInstance());

    [Fact]
    public void Valid_ExactMatch() => Executor_Create.Valid_ExactMatch(GetInstance());

    private static EpochRangeFactory GetInstance() => new();
}
