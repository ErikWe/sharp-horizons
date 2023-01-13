namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Tests.QueryCases.EpochCases.IFixedEpochRangeFactoryCases;

using SharpMeasures;

using System;

using Xunit;

public class Fixed
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
    [ClassData(typeof(Datasets.InvalidDeltaTimes))]
    public void InvalidDeltaTime_ArgumentException(Time deltaTime) => Executor_Create.InvalidDeltaTime_ArgumentException(GetDelegate(), deltaTime);

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeDeltaTimes))]
    public void OutOfRangeDeltaTime_ArgumentOutOfRangeException(Time deltaTime) => Executor_Create.OutOfRangeDeltaTime_ArgumentOutOfRangeException(GetDelegate(), deltaTime);

    [Fact]
    public void NullStartAndStopEpochsAndInvalidDeltaTime_ArgumentException() => Executor_Create.NullStartAndStopEpochsAndInvalidDeltaTime_ArgumentException(GetDelegate());

    [Theory]
    [ClassData(typeof(Datasets.ValidDeltaTimes))]
    public void Valid_ExactMatch(Time deltaTime) => Executor_Create.Valid_ExactMatch(GetDelegate(), deltaTime);

    private static Func<IEpoch, IEpoch, Time, IEpochRange> GetDelegate() => new EpochRangeFactory().Fixed;
}
