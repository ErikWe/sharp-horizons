namespace SharpHorizons.Tests.QueryCases.EpochCases.EpochCollectionFactoryCases;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Tests.QueryCases.EpochCases.IEpochCollectionFactoryCases;

using System;
using System.Collections.Generic;

using Xunit;

public class Create_IEnumerable
{
    [Fact]
    public void Null_ArgumentNullException() => Executor_Create_IEnumerable.Null_ArgumentNullException(GetDelegate());

    [Fact]
    public void Valid_ExactMatch() => Executor_Create_IEnumerable.Valid_ExactMatch(GetDelegate());

    private static Func<IEnumerable<IEpoch>, IEpochCollection> GetDelegate() => new EpochCollectionFactory().Create;
}
