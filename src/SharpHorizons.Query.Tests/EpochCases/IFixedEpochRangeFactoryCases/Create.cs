namespace SharpHorizons.Tests.QueryCases.EpochCases.IFixedEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

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
    [ClassData(typeof(Datasets.InvalidDeltaTimes))]
    public void InvalidDeltaTime_ArgumentException(Time deltaTime) => Executor_Create.InvalidDeltaTime_ArgumentException(GetService(), deltaTime);

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeDeltaTimes))]
    public void OutOfRangeDeltaTime_ArgumentOutOfRangeException(Time deltaTime) => Executor_Create.OutOfRangeDeltaTime_ArgumentOutOfRangeException(GetService(), deltaTime);

    [Fact]
    public void NullStartAndStopEpochsAndInvalidDeltaTime_ArgumentException() => Executor_Create.NullStartAndStopEpochsAndInvalidDeltaTime_ArgumentException(GetService());

    [Theory]
    [ClassData(typeof(Datasets.ValidDeltaTimes))]
    public void Valid_ExactMatch(Time deltaTime) => Executor_Create.Valid_ExactMatch(GetService(), deltaTime);

    private static IFixedEpochRangeFactory GetService() => DependencyInjection.GetRequiredService<IFixedEpochRangeFactory>();
}
