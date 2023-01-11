namespace SharpHorizons.Tests.QueryCases.OriginCases.OriginObjectIdentifierCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class ValueAccess
{
    [Fact]
    public void Invalid_InvalidOperationException()
    {
        var exception = Record.Exception(() => default(OriginObjectIdentifier).Value);

        Assert.IsType<InvalidOperationException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidOriginObjectIdentifiers))]
    public void ValueAccess_Valid_NoException(OriginObjectIdentifier originObjectIdentifier)
    {
        var exception = Record.Exception(() => originObjectIdentifier.Value);

        Assert.Null(exception);
    }
}
