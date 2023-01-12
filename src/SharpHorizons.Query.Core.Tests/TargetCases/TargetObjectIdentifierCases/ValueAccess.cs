namespace SharpHorizons.Tests.QueryCases.TargetCases.TargetObjectIdentifierCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class ValueAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTargetObjectIdentifiers))]
    public void Valid_NoException(TargetObjectIdentifier targetObjectIdentifier)
    {
        var exception = Record.Exception(() => targetObjectIdentifier.Value);

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTargetObjectIdentifiers))]
    public void Invalid_InvalidOperationException(TargetObjectIdentifier targetObjectIdentifier)
    {
        var exception = Record.Exception(() => targetObjectIdentifier.Value);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
