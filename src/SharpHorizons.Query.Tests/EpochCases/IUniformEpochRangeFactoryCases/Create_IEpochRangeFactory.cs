namespace SharpHorizons.Tests.QueryCases.EpochCases.IUniformEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using Xunit;

public class Create_IEpochRangeFactory
{
    [Fact]
    public void NullStartEpoch_ArgumentNullException() => IEpochRangeFactoryCases.Executor_Create.NullStartEpoch_ArgumentNullException(GetService());

    [Fact]
    public void NullStopEpoch_ArgumentNullException() => IEpochRangeFactoryCases.Executor_Create.NullStopEpoch_ArgumentNullException(GetService());

    [Fact]
    public void NullStepSize_ArgumentNullException() => IEpochRangeFactoryCases.Executor_Create.NullStepSize_ArgumentNullException(GetService());

    [Fact]
    public void StopEpochEarlierThanStartEpochAndNullStepSize_ArgumentNullException() => IEpochRangeFactoryCases.Executor_Create.StopEpochEarlierThanStartEpochAndNullStepSize_ArgumentNullException(GetService());

    [Fact]
    public void StopEpochEarlierThanStartEpoch_ArgumentException() => IEpochRangeFactoryCases.Executor_Create.StopEpochEarlierThanStartEpoch_ArgumentException(GetService());

    [Fact]
    public void StopEpochSameAsStartEpoch_ArgumentException() => IEpochRangeFactoryCases.Executor_Create.StopEpochSameAsStartEpoch_ArgumentException(GetService());

    [Fact]
    public void Valid_ExactMatch() => IEpochRangeFactoryCases.Executor_Create.Valid_ExactMatch(GetService());

    private static IUniformEpochRangeFactory GetService() => DependencyInjection.GetRequiredService<IUniformEpochRangeFactory>();
}
