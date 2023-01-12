namespace SharpHorizons.Tests.QueryCases.TargetCases.TargetSiteIdentifierCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class Constructor
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTargetSitedentifierStrings))]
    public void Valid_ExactMatch(string identifier)
    {
        TargetSiteIdentifier actual = new(identifier);

        Assert.Equal(identifier, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTargetSiteIdentifierStrings))]
    public void Invalid_ArgumentException(string identifier)
    {
        var exception = Record.Exception(() => new TargetSiteIdentifier(identifier));

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => new TargetSiteIdentifier(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }
}
