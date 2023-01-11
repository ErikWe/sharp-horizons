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

    [Fact]
    public void Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => (string)default(OriginObjectIdentifier));

        Assert.IsType<ArgumentException>(exception);
    }
}
