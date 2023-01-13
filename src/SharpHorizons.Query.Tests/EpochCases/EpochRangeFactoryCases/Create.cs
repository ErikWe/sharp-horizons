namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Tests.QueryCases.EpochCases.IEpochRangeFactoryCases;

using System;

using Xunit;

public class Create
{
    [Fact]
    public void NullStartEpoch_ArgumentNullException() => Executor_Create.NullStartEpoch_ArgumentNullException(GetDelegate());

    [Fact]
    public void NullStopEpoch_ArgumentNullException() => Executor_Create.NullStopEpoch_ArgumentNullException(GetDelegate());

    [Fact]
    public void NullStepSize_ArgumentNullException() => Executor_Create.NullStepSize_ArgumentNullException(GetDelegate());

    [Fact]
    public void StopEpochEarlierThanStartEpochAndNullStepSize_ArgumentNullException() => Executor_Create.StopEpochEarlierThanStartEpochAndNullStepSize_ArgumentNullException(GetDelegate());

    [Fact]
    public void StopEpochEarlierThanStartEpoch_ArgumentException() => Executor_Create.StopEpochEarlierThanStartEpoch_ArgumentException(GetDelegate());

    [Fact]
    public void StopEpochSameAsStartEpoch_ArgumentException() => Executor_Create.StopEpochSameAsStartEpoch_ArgumentException(GetDelegate());

    [Fact]
    public void Valid_ExactMatch() => Executor_Create.Valid_ExactMatch(GetDelegate());

    private static Func<IEpoch, IEpoch, IStepSize, IEpochRange> GetDelegate() => new EpochRangeFactory().Create;
}
