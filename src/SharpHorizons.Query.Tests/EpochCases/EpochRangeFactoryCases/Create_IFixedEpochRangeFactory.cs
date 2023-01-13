namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Tests.QueryCases.EpochCases.IFixedEpochRangeFactoryCases;

using SharpMeasures;

using Xunit;

public class Create_IFixedEpochRangeFactory
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
    [ClassData(typeof(Datasets.InvalidDeltaTimes))]
    public void InvalidDeltaTime_ArgumentException(Time deltaTime) => Executor_Create.InvalidDeltaTime_ArgumentException(GetInstance(), deltaTime);

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeDeltaTimes))]
    public void OutOfRangeDeltaTime_ArgumentOutOfRangeException(Time deltaTime) => Executor_Create.OutOfRangeDeltaTime_ArgumentOutOfRangeException(GetInstance(), deltaTime);

    [Fact]
    public void NullStartAndStopEpochsAndInvalidDeltaTime_ArgumentException() => Executor_Create.NullStartAndStopEpochsAndInvalidDeltaTime_ArgumentException(GetInstance());

    [Theory]
    [ClassData(typeof(Datasets.ValidDeltaTimes))]
    public void Valid_ExactMatch(Time deltaTime) => Executor_Create.Valid_ExactMatch(GetInstance(), deltaTime);

    private static EpochRangeFactory GetInstance() => new();
}
