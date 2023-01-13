namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochCollectionFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Tests.QueryCases.EpochCases.IEpochCollectionFactoryCases;

using Xunit;

public class Create_IEnumerable_IEpochCollectionFactory
{
    [Fact]
    public void Null_ArgumentNullException() => Executor_Create_IEnumerable.Null_ArgumentNullException(GetInstance());

    [Fact]
    public void Valid_ExactMatch() => Executor_Create_IEnumerable.Valid_ExactMatch(GetInstance());

    private static EpochCollectionFactory GetInstance() => new();
}
