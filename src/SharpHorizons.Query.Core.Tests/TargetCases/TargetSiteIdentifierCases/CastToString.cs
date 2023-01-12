namespace SharpHorizons.Tests.QueryCases.TargetCases.TargetSiteIdentifierCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTargetSiteIdentifiers))]
    public void Valid_ExactMatch(TargetSiteIdentifier targetSiteIdentifier)
    {
        var actual = (string)targetSiteIdentifier;

        Assert.Equal(targetSiteIdentifier.Value, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTargetSiteIdentifiers))]
    public void Invalid_ArgumentException(TargetSiteIdentifier targetSiteIdentifier)
    {
        var exception = Record.Exception(() => (string)targetSiteIdentifier);

        Assert.IsType<ArgumentException>(exception);
    }
}
