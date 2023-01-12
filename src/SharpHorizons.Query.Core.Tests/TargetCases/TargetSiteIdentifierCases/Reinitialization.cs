namespace SharpHorizons.Tests.QueryCases.TargetCases.TargetSiteIdentifierCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class Reinitialization
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTargetSitedentifierStrings))]
    public void Valid_ExactMatch(string identifier)
    {
        var actual = InitialTargetSiteIdentifier with { Value = identifier };

        Assert.Equal(identifier, actual.Value);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTargetSiteIdentifierStrings))]
    public void Invalid_ArgumentException(string identifier)
    {
        var exception = Record.Exception(() => InitialTargetSiteIdentifier with { Value = identifier });

        Assert.IsType<ArgumentException>(exception);
    }

    [Fact]
    public void Null_ArgumentNullException()
    {
        var exception = Record.Exception(() => InitialTargetSiteIdentifier with { Value = null! });

        Assert.IsType<ArgumentNullException>(exception);
    }

    private static TargetSiteIdentifier InitialTargetSiteIdentifier => new("c: -507, 319, 400");
}
