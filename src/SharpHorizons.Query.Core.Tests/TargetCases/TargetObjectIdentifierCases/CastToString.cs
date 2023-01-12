namespace SharpHorizons.Tests.QueryCases.TargetCases.TargetObjectIdentifierCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class CastToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTargetObjectIdentifiers))]
    public void Valid_ExactMatch(TargetObjectIdentifier targetObjectIdentifier)
    {
        var actual = (string)targetObjectIdentifier;

        Assert.Equal(targetObjectIdentifier.Value, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTargetObjectIdentifiers))]
    public void Invalid_ArgumentException(TargetObjectIdentifier targetObjectIdentifier)
    {
        var exception = Record.Exception(() => (string)targetObjectIdentifier);

        Assert.IsType<ArgumentException>(exception);
    }
}
