namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Tests.QueryCases.EpochCases.IAngularEpochRangeFactoryCases;

using SharpMeasures;

using System;

using Xunit;

public class Angular
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
    [ClassData(typeof(Datasets.InvalidDeltaAngles))]
    public void InvalidDeltaAngle_ArgumentException(Angle deltaAngle) => Executor_Create.InvalidDeltaAngle_ArgumentException(GetDelegate(), deltaAngle);

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeDeltaAngles))]
    public void OutOfRangeDeltaAngle_ArgumentOutOfRangeException(Angle deltaAngle) => Executor_Create.OutOfRangeDeltaAngle_ArgumentOutOfRangeException(GetDelegate(), deltaAngle);

    [Fact]
    public void NullStartAndStopEpochsAndInvalidDeltaAngle_ArgumentException() => Executor_Create.NullStartAndStopEpochsAndInvalidDeltaAngle_ArgumentException(GetDelegate());

    [Theory]
    [ClassData(typeof(Datasets.ValidDeltaAngles))]
    public void Valid_ExactMatch(Angle deltaAngle) => Executor_Create.Valid_ExactMatch(GetDelegate(), deltaAngle);

    private static Func<IEpoch, IEpoch, Angle, IEpochRange> GetDelegate() => new EpochRangeFactory().Angular;
}
