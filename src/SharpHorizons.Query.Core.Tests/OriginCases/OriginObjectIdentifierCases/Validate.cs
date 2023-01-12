namespace SharpHorizons.Tests.QueryCases.OriginCases.OriginObjectIdentifierCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidOriginObjectIdentifiers))]
    public void Valid_NoException(OriginObjectIdentifier originObjectIdentifier)
    {
        var exception = Record.Exception(() => OriginObjectIdentifier.Validate(originObjectIdentifier));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidOriginObjectIdentifiers))]
    public void Invalid_ArgumentException(OriginObjectIdentifier originObjectIdentifier)
    {
        var exception = Record.Exception(() => OriginObjectIdentifier.Validate(originObjectIdentifier));

        Assert.IsType<ArgumentException>(exception);
    }
}
