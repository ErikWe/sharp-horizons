namespace SharpHorizons.Tests.QueryCases.EpochCases.IEpochCollectionFactoryCases;

using SharpHorizons.Query.Epoch;

using Xunit;

public class Create_IEnumerable
{
    [Fact]
    public void Null_ArgumentNullException() => Executor_Create_IEnumerable.Null_ArgumentNullException(GetService());

    [Fact]
    public void Valid_ExactMatch() => Executor_Create_IEnumerable.Valid_ExactMatch(GetService());

    private static IEpochCollectionFactory GetService() => DependencyInjection.GetRequiredService<IEpochCollectionFactory>();
}
