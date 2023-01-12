namespace SharpHorizons.Tests.QueryCases.TargetCases.TargetObjectIdentifierCases;

using SharpHorizons.Query.Target;

using System;

using Xunit;

public class ToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidTargetObjectIdentifiers))]
    public void Valid_ExactMatchValue(TargetObjectIdentifier targetObjectIdentifier)
    {
        var expected = targetObjectIdentifier.Value;

        var actual = targetObjectIdentifier.ToString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidTargetObjectIdentifiers))]
    public void Invalid_InvalidOperationException(TargetObjectIdentifier targetObjectIdentifier)
    {
        var exception = Record.Exception(targetObjectIdentifier.ToString);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
