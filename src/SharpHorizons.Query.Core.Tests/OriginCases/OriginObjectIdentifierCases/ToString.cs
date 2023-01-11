namespace SharpHorizons.Tests.QueryCases.OriginCases.OriginObjectIdentifierCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class ToString
{
    [Fact]
    public void Invalid_InvalidOperationException()
    {
        var exception = Record.Exception(() => default(OriginObjectIdentifier).ToString());

        Assert.IsType<InvalidOperationException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidOriginObjectIdentifiers))]
    public void Valid_ExactMatchValue(OriginObjectIdentifier originObjectIdentifier)
    {
        var expected = originObjectIdentifier.Value;

        var actual = originObjectIdentifier.ToString();

        Assert.Equal(expected, actual);
    }
}
