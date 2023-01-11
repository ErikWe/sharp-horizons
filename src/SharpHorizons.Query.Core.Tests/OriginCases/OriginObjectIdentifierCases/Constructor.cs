namespace SharpHorizons.Tests.QueryCases.OriginCases.OriginObjectIdentifierCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.ValidOriginObjectIdentifierStrings))]
    public void Valid_ExactMatch(string identifier)
    {
        OriginObjectIdentifier actual = new(identifier);

        Assert.Equal(identifier, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidOriginObjectIdentifierStrings))]
    public void Invalid_ArgumentException(string identifier)
    {
        var exception = Record.Exception(() => new OriginObjectIdentifier(identifier));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new OriginObjectIdentifier(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }
}
