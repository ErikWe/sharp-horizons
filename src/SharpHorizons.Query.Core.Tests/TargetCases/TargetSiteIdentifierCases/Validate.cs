namespace SharpHorizons.Tests.QueryCases.TargetCases.TargetSiteIdentifierCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTargetSiteIdentifiers))]
    public void Valid_NoException(TargetSiteIdentifier targetSiteIdentifier)
    {
        var exception = Record.Exception(() => TargetSiteIdentifier.Validate(targetSiteIdentifier));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTargetSiteIdentifiers))]
    public void Invalid_ArgumentException(TargetSiteIdentifier targetSiteIdentifier)
    {
        var exception = Record.Exception(() => TargetSiteIdentifier.Validate(targetSiteIdentifier));

        Assert.IsType<ArgumentException>(exception);
    }
}
