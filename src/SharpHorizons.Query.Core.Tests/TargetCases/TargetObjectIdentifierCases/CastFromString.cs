namespace SharpHorizons.Tests.QueryCases.TargetCases.TargetObjectIdentifierCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class CastFromString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTargetObjectIdentifierStrings))]
    public void Valid_ExactMatch(string identifier)
    {
        var actual = (TargetObjectIdentifier)identifier;

        Assert.Equal(identifier, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTargetObjectIdentifierStrings))]
    public void Invalid_ArgumentException(string identifier)
    {
        var exception = Record.Exception(() => (TargetObjectIdentifier)identifier);

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => (TargetObjectIdentifier)null!);

        Assert.IsType<ArgumentNullException>(exception);
    }
}
