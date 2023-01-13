namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Tests.QueryCases.EpochCases.IUniformEpochRangeFactoryCases;

using System;

using Xunit;

public class Uniform
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
    [ClassData(typeof(Datasets.OutOfRangeStepCounts))]
    public void OutOfRangeStepCount_ArgumentOutOfRangeException(int stepCount) => Executor_Create.OutOfRangeStepCount_ArgumentOutOfRangeException(GetDelegate(), stepCount);

    [Fact]
    public void NullStartAndStopEpochsAndOutOfRangeStepCount_ArgumentOutOfRangeException() => Executor_Create.NullStartAndStopEpochsAndOutOfRangeStepCount_ArgumentOutOfRangeException(GetDelegate());

    [Theory]
    [ClassData(typeof(Datasets.ValidStepCounts))]
    public void Valid_ExactMatch(int stepCount) => Executor_Create.Valid_ExactMatch(GetDelegate(), stepCount);

    private static Func<IEpoch, IEpoch, int, IEpochRange> GetDelegate() => new EpochRangeFactory().Uniform;
}
