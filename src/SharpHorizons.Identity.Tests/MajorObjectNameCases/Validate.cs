namespace SharpHorizons.Tests.IdentityCases.MajorObjectNameCases;

using System;

using Xunit;

public class Validate
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNames))]
    public void Valid_NoException(MajorObjectName majorObjectName)
    {
        var exception = Record.Exception(() => MajorObjectName.Validate(majorObjectName));

        Assert.Null(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMajorObjectNames))]
    public void Invalid_ArgumentException(MajorObjectName majorObjectName)
    {
        var exception = Record.Exception(() => MajorObjectName.Validate(majorObjectName));

        Assert.IsType<ArgumentException>(exception);
    }
}
