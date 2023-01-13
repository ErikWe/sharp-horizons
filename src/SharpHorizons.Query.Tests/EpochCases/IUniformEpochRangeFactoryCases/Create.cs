namespace SharpHorizons.Tests.QueryCases.EpochCases.IUniformEpochRangeFactoryCases;

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
    [ClassData(typeof(Datasets.OutOfRangeStepCounts))]
    public void OutOfRangeStepCount_ArgumentOutOfRangeException(int stepCount) => Executor_Create.OutOfRangeStepCount_ArgumentOutOfRangeException(GetService(), stepCount);

    [Fact]
    public void NullStartAndStopEpochsAndOutOfRangeStepCount_ArgumentOutOfRangeException() => Executor_Create.NullStartAndStopEpochsAndOutOfRangeStepCount_ArgumentOutOfRangeException(GetService());

    [Theory]
    [ClassData(typeof(Datasets.ValidStepCounts))]
    public void Valid_ExactMatch(int stepCount) => Executor_Create.Valid_ExactMatch(GetService(), stepCount);

    private static IUniformEpochRangeFactory GetService() => DependencyInjection.GetRequiredService<IUniformEpochRangeFactory>();
}
