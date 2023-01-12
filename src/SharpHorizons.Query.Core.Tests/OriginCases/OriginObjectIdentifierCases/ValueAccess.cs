namespace SharpHorizons.Tests.QueryCases.OriginCases.OriginObjectIdentifierCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class ValueAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidOriginObjectIdentifiers))]
    public void Valid_NoException(OriginObjectIdentifier originObjectIdentifier)
    {
        var exception = Record.Exception(() => originObjectIdentifier.Value);

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidOriginObjectIdentifiers))]
    public void Invalid_InvalidOperationException(OriginObjectIdentifier originObjectIdentifier)
    {
        var exception = Record.Exception(() => originObjectIdentifier.Value);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
