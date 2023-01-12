namespace SharpHorizons.Tests.IdentityCases.MajorObjectNameCases;

using System;

using Xunit;

public class ToString
{
    [Theory]
    [ClassData(typeof(Datasets.ValidMajorObjectNames))]
    public void Valid_ExactMatchValue(MajorObjectName majorObjectName)
    {
        var expected = majorObjectName.Value;

        var actual = majorObjectName.ToString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidMajorObjectNames))]
    public void Invalid_InvalidOperationException(MajorObjectName majorObjectName)
    {
        var exception = Record.Exception(majorObjectName.ToString);

        Assert.IsType<InvalidOperationException>(exception);
    }
}
