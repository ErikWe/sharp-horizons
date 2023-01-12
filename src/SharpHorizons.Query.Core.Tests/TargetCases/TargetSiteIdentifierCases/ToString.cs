namespace SharpHorizons.Tests.QueryCases.TargetCases.TargetSiteIdentifierCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class ToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTargetSiteIdentifiers))]
    public void Valid_ExactMatchValue(TargetSiteIdentifier targetSiteIdentifier)
    {
        var expected = targetSiteIdentifier.Value;

        var actual = targetSiteIdentifier.ToString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTargetSiteIdentifiers))]
    public void Invalid_InvalidOperationException(TargetSiteIdentifier targetSiteIdentifier)
    {
        var exception = Record.Exception(targetSiteIdentifier.ToString);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
