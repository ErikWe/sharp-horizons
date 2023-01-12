namespace SharpHorizons.Tests.QueryCases.OriginCases.OriginObjectIdentifierCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidOriginObjectIdentifiers))]
    public void Valid_ExactMatch(OriginObjectIdentifier originObjectIdentifier)
    {
        var actual = (string)originObjectIdentifier;

        Assert.Equal(originObjectIdentifier.Value, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidOriginObjectIdentifiers))]
    public void Invalid_ArgumentException(OriginObjectIdentifier originObjectIdentifier)
    {
        var exception = Record.Exception(() => (string)originObjectIdentifier);

        Assert.IsType<ArgumentException>(exception);
    }
}
