namespace SharpHorizons.Tests.QueryCases.OriginCases.OriginObjectIdentifierCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class ToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidOriginObjectIdentifiers))]
    public void Valid_ExactMatchValue(OriginObjectIdentifier originObjectIdentifier)
    {
        var expected = originObjectIdentifier.Value;

        var actual = originObjectIdentifier.ToString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidOriginObjectIdentifiers))]
    public void Invalid_InvalidOperationException(OriginObjectIdentifier originObjectIdentifier)
    {
        var exception = Record.Exception(originObjectIdentifier.ToString);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
