namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Tests.QueryCases.EpochCases.IUniformEpochRangeFactoryCases;

using Xunit;

public class Create_IUniformEpochRangeFactory
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
    [ClassData(typeof(Datasets.OutOfRangeStepCounts))]
    public void OutOfRangeStepCount_ArgumentOutOfRangeException(int stepCount) => Executor_Create.OutOfRangeStepCount_ArgumentOutOfRangeException(GetInstance(), stepCount);

    [Fact]
    public void NullStartAndStopEpochsAndOutOfRangeStepCount_ArgumentOutOfRangeException() => Executor_Create.NullStartAndStopEpochsAndOutOfRangeStepCount_ArgumentOutOfRangeException(GetInstance());

    [Theory]
    [ClassData(typeof(Datasets.ValidStepCounts))]
    public void Valid_ExactMatch(int stepCount) => Executor_Create.Valid_ExactMatch(GetInstance(), stepCount);

    private static EpochRangeFactory GetInstance() => new();
}
