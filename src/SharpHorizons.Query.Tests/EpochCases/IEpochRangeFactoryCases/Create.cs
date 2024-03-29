﻿namespace SharpHorizons.Tests.QueryCases.EpochCases.IEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using Xunit;

public class Create
{
    [Fact]
    public void NullStartEpoch_ArgumentNullException() => Executor_Create.NullStartEpoch_ArgumentNullException(GetService());

    [Fact]
    public void NullStopEpoch_ArgumentNullException() => Executor_Create.NullStopEpoch_ArgumentNullException(GetService());

    [Fact]
    public void NullStepSize_ArgumentNullException() => Executor_Create.NullStepSize_ArgumentNullException(GetService());

    [Fact]
    public void StopEpochEarlierThanStartEpochAndNullStepSize_ArgumentNullException() => Executor_Create.StopEpochEarlierThanStartEpochAndNullStepSize_ArgumentNullException(GetService());

    [Fact]
    public void StopEpochEarlierThanStartEpoch_ArgumentException() => Executor_Create.StopEpochEarlierThanStartEpoch_ArgumentException(GetService());

    [Fact]
    public void StopEpochSameAsStartEpoch_ArgumentException() => Executor_Create.StopEpochSameAsStartEpoch_ArgumentException(GetService());

    [Fact]
    public void Valid_ExactMatch() => Executor_Create.Valid_ExactMatch(GetService());

    private static IEpochRangeFactory GetService() => DependencyInjection.GetRequiredService<IEpochRangeFactory>();
}
