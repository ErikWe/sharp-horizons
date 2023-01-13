namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochCollectionFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Tests.QueryCases.EpochCases.IEpochCollectionFactoryCases;

using System;

using Xunit;

public class Create_Params
{
    [Fact]
    public void Null_ArgumentNullException() => Executor_Create_Params.Null_ArgumentNullException(GetDelegate());

    [Fact]
    public void Valid_ExactMatch() => Executor_Create_Params.Valid_ExactMatch(GetDelegate());

    private static Func<IEpoch[], IEpochCollection> GetDelegate() => new EpochCollectionFactory().Create;
}
