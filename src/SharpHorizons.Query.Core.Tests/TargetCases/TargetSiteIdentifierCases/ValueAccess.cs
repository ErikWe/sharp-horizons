namespace SharpHorizons.Tests.QueryCases.TargetCases.TargetSiteIdentifierCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class ValueAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTargetSiteIdentifiers))]
    public void Valid_NoException(TargetSiteIdentifier targetSiteIdentifier)
    {
        var exception = Record.Exception(() => targetSiteIdentifier.Value);

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTargetSiteIdentifiers))]
    public void Invalid_InvalidOperationException(TargetSiteIdentifier targetSiteIdentifier)
    {
        var exception = Record.Exception(() => targetSiteIdentifier.Value);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
