namespace SharpHorizons.Tests.QueryCases.TargetCases.TargetObjectIdentifierCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTargetObjectIdentifierStrings))]
    public void Valid_ExactMatch(string identifier)
    {
        TargetObjectIdentifier actual = new(identifier);

        Assert.Equal(identifier, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTargetObjectIdentifierStrings))]
    public void Invalid_ArgumentException(string identifier)
    {
        var exception = Record.Exception(() => new TargetObjectIdentifier(identifier));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new TargetObjectIdentifier(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }
}
