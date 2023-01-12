namespace SharpHorizons.Tests.QueryCases.TargetCases.TargetObjectIdentifierCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTargetObjectIdentifiers))]
    public void Valid_NoException(TargetObjectIdentifier targetObjectIdentifier)
    {
        var exception = Record.Exception(() => TargetObjectIdentifier.Validate(targetObjectIdentifier));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTargetObjectIdentifiers))]
    public void Invalid_ArgumentException(TargetObjectIdentifier targetObjectIdentifier)
    {
        var exception = Record.Exception(() => TargetObjectIdentifier.Validate(targetObjectIdentifier));

        Assert.IsType<ArgumentException>(exception);
    }
}
