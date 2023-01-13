namespace SharpHorizons.Tests.QueryCases.EpochCases.IAngularEpochRangeFactoryCases;

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
    [ClassData(typeof(Datasets.InvalidDeltaAngles))]
    public void InvalidDeltaAngle_ArgumentException(Angle deltaAngle) => Executor_Create.InvalidDeltaAngle_ArgumentException(GetService(), deltaAngle);

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeDeltaAngles))]
    public void OutOfRangeDeltaAngle_ArgumentOutOfRangeException(Angle deltaAngle) => Executor_Create.OutOfRangeDeltaAngle_ArgumentOutOfRangeException(GetService(), deltaAngle);

    [Fact]
    public void NullStartAndStopEpochsAndInvalidDeltaAngle_ArgumentException() => Executor_Create.NullStartAndStopEpochsAndInvalidDeltaAngle_ArgumentException(GetService());

    [Theory]
    [ClassData(typeof(Datasets.ValidDeltaAngles))]
    public void Valid_ExactMatch(Angle deltaAngle) => Executor_Create.Valid_ExactMatch(GetService(), deltaAngle);

    private static IAngularEpochRangeFactory GetService() => DependencyInjection.GetRequiredService<IAngularEpochRangeFactory>();
}
