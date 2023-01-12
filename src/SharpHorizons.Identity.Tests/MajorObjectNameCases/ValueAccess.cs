namespace SharpHorizons.Tests.IdentityCases.MajorObjectNameCases;

using System;

using Xunit;

public class ValueAccess
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNames))]
    public void Valid_NoException(MajorObjectName majorObjectName)
    {
        var exception = Record.Exception(() => majorObjectName.Value);

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMajorObjectNames))]
    public void Invalid_InvalidOperationException(MajorObjectName majorObjectName)
    {
        var exception = Record.Exception(() => majorObjectName.Value);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
