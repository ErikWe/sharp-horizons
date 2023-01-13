namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Tests.QueryCases.EpochCases.IAngularEpochRangeFactoryCases;

using SharpMeasures;

using Xunit;

public class Create_IAngularEpochRangeFactory
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
    [ClassData(typeof(Datasets.InvalidDeltaAngles))]
    public void InvalidDeltaAngle_ArgumentException(Angle deltaAngle) => Executor_Create.InvalidDeltaAngle_ArgumentException(GetInstance(), deltaAngle);

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeDeltaAngles))]
    public void OutOfRangeDeltaAngle_ArgumentOutOfRangeException(Angle deltaAngle) => Executor_Create.OutOfRangeDeltaAngle_ArgumentOutOfRangeException(GetInstance(), deltaAngle);

    [Fact]
    public void NullStartAndStopEpochsAndInvalidDeltaAngle_ArgumentException() => Executor_Create.NullStartAndStopEpochsAndInvalidDeltaAngle_ArgumentException(GetInstance());

    [Theory]
    [ClassData(typeof(Datasets.ValidDeltaAngles))]
    public void Valid_ExactMatch(Angle deltaAngle) => Executor_Create.Valid_ExactMatch(GetInstance(), deltaAngle);

    private static EpochRangeFactory GetInstance() => new();
}
