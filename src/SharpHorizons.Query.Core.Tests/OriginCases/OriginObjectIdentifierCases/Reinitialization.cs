namespace SharpHorizons.Tests.QueryCases.OriginCases.OriginObjectIdentifierCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidOriginObjectIdentifierStrings))]
    public void Valid_ExactMatch(string identifier)
    {
        var actual = InitialOriginObjectIdentifier with { Value = identifier };

        Assert.Equal(identifier, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidOriginObjectIdentifierStrings))]
    public void Invalid_ArgumentException(string name)
    {
        var exception = Record.Exception(() => InitialOriginObjectIdentifier with { Value = name });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => InitialOriginObjectIdentifier with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    private static OriginObjectIdentifier InitialOriginObjectIdentifier => new("Earth");
}
