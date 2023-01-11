namespace SharpHorizons.Tests.QueryCases.OriginCases.OriginObjectIdentifierCases;

using SharpHorizons.Query.Origin;

using System;

using Xunit;

public class Validation
{
    [Fact]
    public void Invalid_ArgumentException()
    {
        var exception = Record.Exception(() => OriginObjectIdentifier.Validate(default));

        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidOriginObjectIdentifiers))]
    public void Valid_NoException(OriginObjectIdentifier originObjectIdentifier)
    {
        var exception = Record.Exception(() => OriginObjectIdentifier.Validate(originObjectIdentifier));

        Assert.Null(exception);
    }
}
